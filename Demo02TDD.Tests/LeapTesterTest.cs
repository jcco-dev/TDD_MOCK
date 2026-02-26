using Demo02TDD.Core;

namespace Demo02TDD.Tests;

[TestClass]
public class LeapTesterTest
{
    [TestMethod]
    [DataRow(400)]
    [DataRow(1200)]
    public void TestLeep_400_ShouldBe_True(int year)
    {
        LeapTester tester = new LeapTester();
        bool res = tester.IsLeap(year);
        Assert.IsTrue(res);
    }
}
