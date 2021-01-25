using dotnet_core_xunit_test.Mock.Entities;
using System;

namespace dotnet_core_xunit_test.Fixture
{
    public class ContextFixture : IDisposable
    {
        public TestDbContextMock testDbContextMock;

        public ContextFixture()
        {
            testDbContextMock = new TestDbContextMock();

            // mock data created by https://barisates.github.io/pretend
            testDbContextMock.Users.AddRange(new dotnet_core_xunit.Entities.TestDb.Users[]
            {
                // for delete test
                new dotnet_core_xunit.Entities.TestDb.Users()
                {
                  Id = 685349,
                  Email = "0sgtsw",
                  Password = "jmctby",
                  FullName = "mq8zp2",
                  CreateDate = DateTime.Now,
                  Status = true,
                },
                // for get test
                new dotnet_core_xunit.Entities.TestDb.Users()
                {
                  Id = 454673,
                  Email = "0tec4e",
                  Password = "al9jje",
                  FullName = "jqvlv2",
                  CreateDate = DateTime.Now,
                  Status = true,
                }
            });
            testDbContextMock.SaveChanges();
        }

        // https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1063?view=vs-2019
        #region ImplementIDisposableCorrectly
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // NOTE: Leave out the finalizer altogether if this class doesn't
        // own unmanaged resources, but leave the other methods
        // exactly as they are.
        ~ContextFixture()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (testDbContextMock != null)
                {
                    testDbContextMock.Dispose();
                    testDbContextMock = null;
                }
            }
        }
        #endregion
    }
}
