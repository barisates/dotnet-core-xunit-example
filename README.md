# dotnet-core-xunit-example
**Unit Test in .NET Core Web Api with xUnit.**

In this example, we have a simple Web Api developed with .Net Core which performs database operations. Our Web API consists of the following endpoints;

> `UserDto.User GetUser(int id);` get user with id in database

> `UserDto.User AddUser(UserDto.User user);` add user to database

> `UserDto.User DeleteUser(int id;` delete user with id from database

When testing these endpoints, we actually write **functional tests**. In this way, we can manage test processes more realistically.

Our tests use **memory database** when testing our endpoints and our live data is not affected by the testing process.

When developing a test, we use the library **[xUnit.net](https://github.com/xunit/xunit "xUnit.net")**.

### xUnit

 xUnit is an open-source unit testing tool for the .Net Framework and offers **.NET Core support**. Compared to other unit testing frameworks, it stands out with its ease of development and its approach to behaviors like *SetUp, TearDown, OneTimeSetup*.

**[Comparing xUnit.net to other frameworks.](https://xunit.net/docs/comparisons.html "Comparing xUnit.net to other frameworks.")**

**SetUp (before each test)**
XUnit uses constructors for test setup operations. You don't need to use a separate attirubute as in NUnit, MSTest frameworks.

**TearDown (after each test)**
XUnit uses IDisposable classes for teardown operations.

**Implementing SetUp and Teardown Method in XUnit;**

```csharp
public class TruthTests : IDisposable
{
    public TruthTests()
    {
	// It will work before each test.
	// NUnit: [SetUp]
	// MSTest: [TestInitialize]
    }
    
    public void Dispose()
    {
	// It will work after each test.
	// NUnit: [TearDown]
	// MSTest: [TestCleanup]
    }

    [Fact]
    public void Test1()
    {
	// Your Test
    }
}
```

**OneTimeSetup (share context between tests)**

We use xUnit's IClassFixture feature to create shared contexts, such as Databases. With the fixture, we can share a single object instance between all tests.

For more; [xUnit.net Documentation](https://xunit.net/#documentation "xUnit.net Documentation")
- [Running Tests in Parallel](https://xunit.net/docs/running-tests-in-parallel "Running Tests in Parallel")
- [Shared Context between Tests](https://xunit.net/docs/shared-context "Shared Context between Tests")