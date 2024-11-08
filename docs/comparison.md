
## Porównanie

| MSTest v2.x.         | xUnit.net 2.x             | NUnit 3.x            | Comments                                           |
| -------------------- | ------------------------- | -------------------- | -------------------------------------------------- |
| \[TestMethod\]       | \[Fact\]                  | \[Test\]             | Marks a test method.                               |
| \[TestClass\]        | n/a                       | \[TestFixture\]      | Marks a test class.                                |
| \[TestInitialize\]   | Constructor               | `[SetUp]`            | Triggered before every test case.                  |
| \[TestCleanup\]      | IDisposable.Dispose       | \[TearDown\]         | Triggered after every test case.                   |
| \[ClassInitialize\]  | IClassFixture<T>          | \[OneTimeSetUp\]     | One-time triggered method before test cases start. |
| \[ClassCleanup\]     | IClassFixture<T>          | \[OneTimeTearDown\]  | One-time triggered method after test cases end.    |
| \[Ignore\]           | \[Fact(Skip="reason")\]   | \[Ignore("reason")\] | Ignores a test case.                               |
| \[TestProperty\]     | \[Trait\]                 | \[Property\]         | Sets arbitrary metadata on a test.                 |
| \[DataRow\]          | \[Theory\]                | \[Theory\]           | Configures a data-driven test.                     |
| \[TestCategory("")\] | \[Trait("Category", "")\] | \[Category("")\]     | Categorizes the test cases or classes.             |