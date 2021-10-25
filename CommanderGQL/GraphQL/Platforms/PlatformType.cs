using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace CommanderGQL.GraphQL.Platforms
{
    // Type build on the base of Platform Model 
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Any software or service.");
            descriptor.Field(p => p.LicenseKey).Ignore();

            descriptor
                .Field(p => p.Commands)
                .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
                .UseDbContext<AppDataContext>()
                .Description("Avariable commands for the platform.");
        }

        private class Resolvers
        {
            public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDataContext context)
            {
                return context.Commands.Where(p => p.PlatformId == platform.Id);
            }
        }
    }
}
