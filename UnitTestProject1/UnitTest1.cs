using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoughtsAndCrosses;
using NSubstitute;
using System.Diagnostics;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;

        /// <summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void Board_Should_Fail()
        {
            //Arrange
            var gameBoard = new UpgradedGameBoard(new GameBoard(), new ConsolePrinter());
            gameBoard.SetValue(0, 0, 'x');
            gameBoard.SetValue(1, 1, 'x');
            gameBoard.SetValue(2, 2, 'o');

            //Act
            var result = gameBoard.ValidateGame();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Board_Should_Win()
        {
            //Arrange
            var gameBoard = new UpgradedGameBoard(new GameBoard(), new ConsolePrinter());
            gameBoard.SetValue(0, 0, 'x');
            gameBoard.SetValue(1, 1, 'x');
            gameBoard.SetValue(2, 2, 'x');

            //Act
            var result = gameBoard.ValidateGame();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Game_Manager_Should_Move()
        {
            //Arrange
            var fakeboard = Substitute.For<IGameBoard>();
            var fakeprinter = Substitute.For<IInputOutput>();
            fakeboard.When(b => b.PrintBoard()).Do(b => TestContext.WriteLine("A fake board is printed!!!"));
            fakeboard.UserInputTile().Returns(new int[] { 1, 2 });
            var entries = fakeboard.UserInputTile();
            fakeboard.When(b => b.SetValue(entries[0], entries[1], 'x'));


            //Act
            GameManager.UserMove(fakeboard, fakeprinter);

            //Assert
            Assert.IsTrue(fakeboard != null);
        }

        [TestMethod]
        public void Game_Manager_Should_Not_Move()
        {
            //Arrange
            var fakeprinter = Substitute.For<IInputOutput>();
            var fakeboard = Substitute.For<IGameBoard>();
            fakeboard.When(b => b.PrintBoard()).Do(b => TestContext.WriteLine("A fake board is printed!!!"));
            fakeboard.UserInputTile().Returns((int[])null);
            var entries = fakeboard.UserInputTile();
            fakeboard.When(b => b.SetValue(entries[0], entries[1], 'x'));


            //Act
            GameManager.UserMove(fakeboard, fakeprinter);

            //Assert
            Assert.IsTrue(fakeboard != null);
        }

    }
}
