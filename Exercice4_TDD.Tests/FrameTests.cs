using Exercice4_TDD.Core;

namespace Exercice4_TDD.Tests;

[TestClass]
public class FrameTests
{
    [TestMethod]
    public void Roll_SimpleFrame_FirstRoll_CheckScore()
    {
        // Arrange: 1er roll = 4
        var gen = new FakeGenerateur(4);
        var frame = new Frame(gen, lastFrame: false);

        // Act
        bool canContinue = frame.MakeRoll();

        // Assert
        Assert.AreEqual(4, frame.Score);
        Assert.IsTrue(canContinue); // après 1 roll normal, on peut rejouer
    }

    [TestMethod]
    public void Roll_SimpleFrame_SecondRoll_CheckScore()
    {
        // Arrange: 1er=4, 2e=3
        var gen = new FakeGenerateur(4, 3);
        var frame = new Frame(gen, lastFrame: false);

        // Act
        frame.MakeRoll();
        bool canContinue = frame.MakeRoll();

        // Assert
        Assert.AreEqual(7, frame.Score);
        Assert.IsFalse(canContinue); // après 2 rolls standard -> stop
    }

    [TestMethod]
    public void Roll_SimpleFrame_SecondRoll_FirstRollStrick_ReturnFalse()
    {
        var gen = new FakeGenerateur(10, 3); // 3 ne doit pas être consommé
        var frame = new Frame(gen, lastFrame: false);

        bool afterFirst = frame.MakeRoll();
        bool afterSecond = frame.MakeRoll(); // doit refuser

        Assert.AreEqual(10, frame.Score);
        Assert.IsFalse(afterSecond);
    }

    [TestMethod]
    public void Roll_SimpleFrame_MoreRolls_ReturnFalse()
    {
        var gen = new FakeGenerateur(3, 4, 2);
        var frame = new Frame(gen, lastFrame: false);

        frame.MakeRoll();
        frame.MakeRoll();
        bool third = frame.MakeRoll();

        Assert.IsFalse(third);
        Assert.AreEqual(7, frame.Score); // 3+4
    }

    [TestMethod]
    public void Roll_LastFrame_SecondRoll_FirstRollStrick_ReturnTrue()
    {
        var gen = new FakeGenerateur(10, 3);
        var frame = new Frame(gen, lastFrame: true);

        frame.MakeRoll();                 // strike
        bool canContinue = frame.MakeRoll(); // 2e roll autorisé

        Assert.IsTrue(canContinue);
    }

    [TestMethod]
    public void Roll_LastFrame_SecondRoll_FirstRollStrick_CheckScore()
    {
        var gen = new FakeGenerateur(10, 3);
        var frame = new Frame(gen, lastFrame: true);

        frame.MakeRoll();
        frame.MakeRoll();

        Assert.AreEqual(13, frame.Score);
    }

    [TestMethod]
    public void Roll_LastFrame_ThirdRoll_FirstRollStrick_ReturnTrue()
    {
        var gen = new FakeGenerateur(10, 3, 4);
        var frame = new Frame(gen, lastFrame: true);

        frame.MakeRoll();
        frame.MakeRoll();
        bool canContinue = frame.MakeRoll();

        Assert.IsTrue(canContinue); // après le 3e, selon ton énoncé, encore autorisé jusqu'à max 4
    }

    [TestMethod]
    public void Roll_LastFrame_ThirdRoll_FirstRollStrick_CheckScore()
    {
        var gen = new FakeGenerateur(10, 3, 4);
        var frame = new Frame(gen, lastFrame: true);

        frame.MakeRoll();
        frame.MakeRoll();
        frame.MakeRoll();

        Assert.AreEqual(17, frame.Score);
    }

    [TestMethod]
    public void Roll_LastFrame_ThirdRoll_Spare_ReturnTrue()
    {
        var gen = new FakeGenerateur(6, 4, 2);
        var frame = new Frame(gen, lastFrame: true);

        frame.MakeRoll();
        frame.MakeRoll();
        bool canContinue = frame.MakeRoll(); // autorisé car spare

        Assert.IsTrue(canContinue);
    }

    [TestMethod]
    public void Roll_LastFrame_ThirdRoll_Spare_CheckScore()
    {
        var gen = new FakeGenerateur(6, 4, 2);
        var frame = new Frame(gen, lastFrame: true);

        frame.MakeRoll();
        frame.MakeRoll();
        frame.MakeRoll();

        Assert.AreEqual(12, frame.Score);
    }

    [TestMethod]
    public void Roll_LastFrame_FourthRoll_ReturnFalse()
    {
        var gen = new FakeGenerateur(10, 3, 4, 1, 1);
        var frame = new Frame(gen, lastFrame: true);

        frame.MakeRoll(); // 1
        frame.MakeRoll(); // 2
        frame.MakeRoll(); // 3
        frame.MakeRoll(); // 4
        bool fifth = frame.MakeRoll(); // 5 -> interdit

        Assert.IsFalse(fifth);
    }
}
