﻿using CommanderGQL.Data;
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
        public IQueryable<Platform> GetPlatforms([ScopedService] AppDataContext context)
        {
            return context.Platforms;
        }
    }
}
