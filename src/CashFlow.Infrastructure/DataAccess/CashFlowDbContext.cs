using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;

public class CashFlowDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=localhost;port=3306;database=cashflowdb;Uid=root;password=!12Mai2012";
            //Environment.GetEnvironmentVariable("CONNECTION_STRING");
        var serverVersion = new MySqlServerVersion(new Version(9, 4, 0));
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}