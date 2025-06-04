using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace NIM.EntityFrameworkCore;

public static class NIMDbContextConfigurer
{
    public static void Configure(DbContextOptionsBuilder<NIMDbContext> builder, string connectionString)
    {
        builder.UseSqlServer(connectionString);
    }

    public static void Configure(DbContextOptionsBuilder<NIMDbContext> builder, DbConnection connection)
    {
        builder.UseSqlServer(connection);
    }
}
