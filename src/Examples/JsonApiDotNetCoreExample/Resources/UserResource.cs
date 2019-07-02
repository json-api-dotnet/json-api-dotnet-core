using System.Collections.Generic;
using System.Linq;
using JsonApiDotNetCore.Models;
using JsonApiDotNetCoreExample.Models;
using JsonApiDotNetCore.Internal.Query;
using JsonApiDotNetCore.Internal;
using JsonApiDotNetCore.Internal.Contracts;

namespace JsonApiDotNetCoreExample.Resources
{
    public class UserResource : ResourceDefinition<User>
    {
        public UserResource(IResourceGraph graph) : base(graph) { }

        protected override List<AttrAttribute> OutputAttrs()
            => Remove(user => user.Password);

        public override QueryFilters GetQueryFilters()
        {
          return new QueryFilters
          {
            { "first-character", (users, queryFilter) => FirstCharacterFilter(users, queryFilter) }
          };
        }

        private IQueryable<User> FirstCharacterFilter(IQueryable<User> users, FilterQuery filterQuery)
        {
          switch(filterQuery.Operation)
          {
            case "lt":
              return users.Where(u => u.Username[0] < filterQuery.Value[0]);
            default:
              return users.Where(u => u.Username[0] == filterQuery.Value[0]);
          }
        }
    }
}
