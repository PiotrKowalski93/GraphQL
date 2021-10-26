using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        // Uses dbContext and returns it to the pool
        [UseDbContext(typeof(AppDataContext))]
        // Work the graph to use 'child' objects
        //[UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDataContext context)
        {
            return context.Platforms;
        }

        [UseDbContext(typeof(AppDataContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommand([ScopedService] AppDataContext context)
        {
            return context.Commands;
        }
    }
}
