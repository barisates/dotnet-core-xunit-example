using dotnet_core_xunit.Entities.TestDb;
using Microsoft.EntityFrameworkCore;
using System;

namespace dotnet_core_xunit_test.Mock.Entities
{
    public partial class TestDbContextMock : TestDbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /**
             * At this stage, a copy of the actual database is created as a memory database.
             * You do not need to create a separate test database.
             */
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }
        }
    }
}
