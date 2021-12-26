using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniBlog.Core.Domain.Blogs.Entities;
using Zamin.Core.Domain.Toolkits.ValueObjects;
using Zamin.Infra.Data.Sql.Commands;

namespace MiniBlog.Infra.Data.Sql.Commands.Common
{
    public class DescriptionConversion: ValueConverter<Description, string>
    {
        public DescriptionConversion():base(c=>c.Value,c=>Description.FromString(c))
        {

        }
    }

    public class TitleConversion : ValueConverter<Title, string>
    {
        public TitleConversion() : base(c => c.Value, c => Title.FromString(c))
        {

        }
    }
    public class MiniblogCommandDbContext : BaseCommandDbContext
    {
        public DbSet<Blog> MyProperty { get; set; }
        public MiniblogCommandDbContext(DbContextOptions<MiniblogCommandDbContext> options) : base(options)
        {
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {

            configurationBuilder.Properties<Description>().HaveConversion<DescriptionConversion>();
            configurationBuilder.Properties<Title>().HaveConversion<TitleConversion>();
        }
    }
}
