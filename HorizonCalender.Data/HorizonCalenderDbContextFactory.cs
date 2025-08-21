

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HorizonCalender.Data;

public sealed class HorizonCalenderDbContextFactory : IDesignTimeDbContextFactory<HorizonCalenderDbContext>
{
    // Only used for EF Core migrations in .NET Aspire.
    // You can temporarily set a valid connection string here 
    // when running `dotnet ef database update` outside of Aspire.
    private const string ConnectionString = "";
    
    public HorizonCalenderDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HorizonCalenderDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);

        return new HorizonCalenderDbContext(optionsBuilder.Options);
    }
}