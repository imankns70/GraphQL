using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderGQL.GraphQL.Platforms
{
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represent any software or service that has a command line interface.");

            descriptor
                .Field(a => a.LicenceKey).Ignore();

            descriptor
                .Field(p => p.Commands)
                .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("this is the list of avaliable commands for this platform");

            
        }
        private class Resolvers
        {
            public IQueryable<Command> GetCommands(Platform platform,[ScopedService] AppDbContext context)
            {
                return context.Commands.Where(a => a.PlatformId == platform.Id);
            }
        }
    }
}
