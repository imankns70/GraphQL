using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        // multi thread
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        // load navigation
        //[UseProjection]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }

        // multi thread
        [UseDbContext(typeof(AppDbContext))]
        // load navigation
        //[UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }


    }
}
