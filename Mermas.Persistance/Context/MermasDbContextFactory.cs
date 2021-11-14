using Microsoft.EntityFrameworkCore;

namespace Mermas.Persistance.Configurations
{
    public class MermasDbContextFactory : DesignTimeDbContextFactoryBase<MermasDbContext>
    {
        protected override MermasDbContext CreateNewInstance(DbContextOptions<MermasDbContext> options)
        {
            return new MermasDbContext(options);
        }
    }
}
