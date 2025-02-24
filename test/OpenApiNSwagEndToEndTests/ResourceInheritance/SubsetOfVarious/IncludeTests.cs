using FluentAssertions;
using JsonApiDotNetCore.AtomicOperations;
using JsonApiDotNetCore.Middleware;
using Microsoft.Extensions.DependencyInjection;
using OpenApiNSwagEndToEndTests.SubsetOfVariousInheritance.GeneratedCode;
using OpenApiTests;
using OpenApiTests.ResourceInheritance;
using OpenApiTests.ResourceInheritance.Models;
using OpenApiTests.ResourceInheritance.SubsetOfVarious;
using TestBuildingBlocks;
using Xunit;
using Xunit.Abstractions;

namespace OpenApiNSwagEndToEndTests.ResourceInheritance.SubsetOfVarious;

public sealed class IncludeTests
    : IClassFixture<IntegrationTestContext<OpenApiStartup<ResourceInheritanceDbContext>, ResourceInheritanceDbContext>>, IDisposable
{
    private readonly IntegrationTestContext<OpenApiStartup<ResourceInheritanceDbContext>, ResourceInheritanceDbContext> _testContext;
    private readonly XUnitLogHttpMessageHandler _logHttpMessageHandler;
    private readonly ResourceInheritanceFakers _fakers = new();

    public IncludeTests(IntegrationTestContext<OpenApiStartup<ResourceInheritanceDbContext>, ResourceInheritanceDbContext> testContext,
        ITestOutputHelper testOutputHelper)
    {
        _testContext = testContext;
        _logHttpMessageHandler = new XUnitLogHttpMessageHandler(testOutputHelper);

        testContext.UseInheritanceControllers(false);

        testContext.ConfigureServices(services =>
        {
            services.AddSingleton<IJsonApiEndpointFilter, SubsetOfVariousEndpointFilter>();
            services.AddSingleton<IAtomicOperationFilter, SubsetOfVariousOperationFilter>();
        });
    }

    [Fact]
    public async Task Can_include_in_primary_resource()
    {
        // Arrange
        District district = _fakers.District.GenerateOne();

        FamilyHome familyHome = _fakers.FamilyHome.GenerateOne();
        familyHome.Rooms.Add(_fakers.LivingRoom.GenerateOne());
        familyHome.Rooms.Add(_fakers.Bedroom.GenerateOne());
        district.Buildings.Add(familyHome);

        Mansion mansion = _fakers.Mansion.GenerateOne();
        mansion.Rooms.Add(_fakers.Kitchen);
        mansion.Rooms.Add(_fakers.Bathroom);
        mansion.Rooms.Add(_fakers.Toilet);
        district.Buildings.Add(mansion);

        Residence residence = _fakers.Residence.GenerateOne();
        residence.Rooms.Add(_fakers.Bedroom.GenerateOne());
        district.Buildings.Add(residence);

        await _testContext.RunOnDatabaseAsync(async dbContext =>
        {
            dbContext.Districts.Add(district);
            await dbContext.SaveChangesAsync();
        });

        using HttpClient httpClient = _testContext.Factory.CreateDefaultClient(_logHttpMessageHandler);
        var apiClient = new SubsetOfVariousInheritanceClient(httpClient);

        var queryString = new Dictionary<string, string?>
        {
            ["include"] = "buildings.rooms"
        };

        // Act
        DistrictCollectionResponseDocument response = await apiClient.GetDistrictCollectionAsync(queryString);

        // Assert
        response.Data.ShouldHaveCount(1);
        response.Data.ElementAt(0).Id.Should().Be(district.StringId);

        response.Included.ShouldHaveCount(9);

        string familyHomeLivingRoomId = familyHome.Rooms.OfType<LivingRoom>().Single().StringId!;
        string familyRoomBedroomId = familyHome.Rooms.OfType<Bedroom>().Single().StringId!;
        string mansionKitchenId = mansion.Rooms.OfType<Kitchen>().Single().StringId!;
        string mansionBathroomId = mansion.Rooms.OfType<Bathroom>().Single().StringId!;
        string mansionToiletId = mansion.Rooms.OfType<Toilet>().Single().StringId!;
        string residenceBedroomId = residence.Rooms.OfType<Bedroom>().Single().StringId!;

        response.Included.OfType<DataInFamilyHomeResponse>().Should().ContainSingle(familyHomeData => familyHomeData.Id == familyHome.StringId).Subject.With(
            familyHomeData =>
            {
                AttributesInFamilyHomeResponse attributes = familyHomeData.Attributes.Should().BeOfType<AttributesInFamilyHomeResponse>().Subject;

                attributes.SurfaceInSquareMeters.Should().Be(familyHome.SurfaceInSquareMeters);
                attributes.NumberOfResidents.Should().Be(familyHome.NumberOfResidents);
                attributes.FloorCount.Should().Be(familyHome.FloorCount);

                RelationshipsInFamilyHomeResponse relationships = familyHomeData.Relationships.Should().BeOfType<RelationshipsInFamilyHomeResponse>().Subject;

                relationships.Rooms.ShouldNotBeNull();
                relationships.Rooms.Data.ShouldHaveCount(2);
                relationships.Rooms.Data.OfType<LivingRoomIdentifierInResponse>().Should().ContainSingle(livingRoom => livingRoom.Id == familyHomeLivingRoomId);
                relationships.Rooms.Data.OfType<BedroomIdentifierInResponse>().Should().ContainSingle(bedroom => bedroom.Id == familyRoomBedroomId);
            });

        response.Included.OfType<DataInMansionResponse>().Should().ContainSingle(mansionData => mansionData.Id == mansion.StringId).Subject.With(mansionData =>
        {
            AttributesInMansionResponse attributes = mansionData.Attributes.Should().BeOfType<AttributesInMansionResponse>().Subject;

            attributes.SurfaceInSquareMeters.Should().Be(mansion.SurfaceInSquareMeters);
            attributes.NumberOfResidents.Should().Be(mansion.NumberOfResidents);
            attributes.OwnerName.Should().Be(mansion.OwnerName);

            RelationshipsInMansionResponse relationships = mansionData.Relationships.Should().BeOfType<RelationshipsInMansionResponse>().Subject;

            relationships.Rooms.ShouldNotBeNull();
            relationships.Rooms.Data.ShouldHaveCount(3);
            relationships.Rooms.Data.OfType<KitchenIdentifierInResponse>().Should().ContainSingle(kitchen => kitchen.Id == mansionKitchenId);
            relationships.Rooms.Data.OfType<BathroomIdentifierInResponse>().Should().ContainSingle(bathroom => bathroom.Id == mansionBathroomId);
            relationships.Rooms.Data.OfType<ToiletIdentifierInResponse>().Should().ContainSingle(toilet => toilet.Id == mansionToiletId);
        });

        response.Included.OfType<DataInResidenceResponse>().Should().ContainSingle(residenceData => residenceData.Id == residence.StringId).Subject.With(
            residenceData =>
            {
                AttributesInResidenceResponse attributes = residenceData.Attributes.Should().BeOfType<AttributesInResidenceResponse>().Subject;

                attributes.SurfaceInSquareMeters.Should().Be(residence.SurfaceInSquareMeters);
                attributes.NumberOfResidents.Should().Be(residence.NumberOfResidents);

                RelationshipsInResidenceResponse relationships = residenceData.Relationships.Should().BeOfType<RelationshipsInResidenceResponse>().Subject;

                relationships.Rooms.ShouldNotBeNull();
                relationships.Rooms.Data.ShouldHaveCount(1);
                relationships.Rooms.Data.OfType<BedroomIdentifierInResponse>().Should().ContainSingle(bedroom => bedroom.Id == residenceBedroomId);
            });

        response.Included.OfType<DataInLivingRoomResponse>().Should().ContainSingle(livingRoom => livingRoom.Id == familyHomeLivingRoomId);
        response.Included.OfType<DataInBedroomResponse>().Should().ContainSingle(livingRoom => livingRoom.Id == familyRoomBedroomId);
        response.Included.OfType<DataInKitchenResponse>().Should().ContainSingle(livingRoom => livingRoom.Id == mansionKitchenId);
        response.Included.OfType<DataInBathroomResponse>().Should().ContainSingle(livingRoom => livingRoom.Id == mansionBathroomId);
        response.Included.OfType<DataInToiletResponse>().Should().ContainSingle(livingRoom => livingRoom.Id == mansionToiletId);
        response.Included.OfType<DataInBedroomResponse>().Should().ContainSingle(livingRoom => livingRoom.Id == residenceBedroomId);
    }

    public void Dispose()
    {
        _logHttpMessageHandler.Dispose();
    }
}
