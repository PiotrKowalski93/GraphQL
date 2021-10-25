using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace CommanderGQL.GraphQL.Commands
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents executable command.");

            descriptor
                .Field(c => c.Platform)
                .ResolveWith<Resolvers>(p => p.GetPlatform(default!, default!))
                .UseDbContext<AppDataContext>()
                .Description("Platform for specific command.");
        }

        public class Resolvers
        {
            public Platform GetPlatform(Command command, [ScopedService] AppDataContext context)
            {
                return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
            }
        }
    }
}
