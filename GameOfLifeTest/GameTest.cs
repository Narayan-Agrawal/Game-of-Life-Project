using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife;

namespace GameOfLifeTest
{
    [TestClass]
    public class GameTest
    {
        /// <summary>
        ///A Postive test for Game Constructor
        ///</summary>
        [TestMethod()]
        public void GameConstructorPositiveTest()
        {
            int rows = 2;
            int columns = 2;
            Game target = new Game(rows, columns);
            Assert.AreEqual(target.RowCount, 2);
            Assert.AreEqual(target.ColumnCount, 2);
        }

        /// <summary>
        ///A Negative test for Game Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Size of Grid's Row and Column must be greater than or equal to zero")]
        public void GameConstructorTest1()
        {
            int rows = -1;
            int columns = 0;
            Game target = new Game(rows, columns);
        }

        /// <summary>
        ///A Negative test for Game Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Grid's Row and Column size must be greater than zero")]
        public void GameConstructorTest2()
        {
            int rows = 0;
            int columns = -1;
            Game target = new Game(rows, columns);
        }

        /// <summary>
        ///A Negatvie test for Game Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Grid's Row and Column size must be greater than zero")]
        public void GameConstructorTest3()
        {
            int rows = 0;
            int columns = 0;
            Game target = new Game(rows, columns);
        }

        /// <summary>
        ///A test for FlipGridCell
        ///</summary>
        [TestMethod()]
        public void FlipGridCellPositiveTest()
        {
            int rows = 2;
            int columns = 3;
            Game target = new Game(rows, columns);
            int x = 1;
            int y = 2;
            target.FlipGridCell(x, y);
            Assert.AreEqual(target.InputGrid[1, 2].IsAlive, true);
        }

        /// <summary>
        ///A test for FlipGridCell
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Argument out of bound")]
        public void FlipGridCellTest1()
        {
            int rows = 1;
            int columns = 0;
            Game target = new Game(rows, columns);
            int x = 0;
            int y = 0;
            target.FlipGridCell(x, y);
        }

        // <summary>
        ///A test for FlipGridCell
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Argument out of bound")]
        public void FlipGridCellTest2()
        {
            int rows = 0;
            int columns = 1;
            Game target = new Game(rows, columns);
            int x = 1;
            int y = 1;
            target.FlipGridCell(x, y);
        }

        // <summary>
        ///A test for FlipGridCell
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Argument out of bound")]
        public void FlipGridCellTest3()
        {
            int rows = 2;
            int columns = 3;
            Game target = new Game(rows, columns);
            int x = 3;
            int y = 3;
            target.FlipGridCell(x, y);
        }



        /// <summary>
        ///A test for validating MaxGeneration value
        ///</summary>
        [TestMethod()]
        public void MaxGenerationTest()
        {
            int rows = 2;
            int columns = 2;

            Game target = new Game(rows, columns);
            target.MaxGenerations = 2;
            Assert.AreEqual(target.MaxGenerations, 2);
        }

        /// <summary>
        ///A default test for Init
        ///</summary>
        [TestMethod()]
        public void InitDefaultValueTest()
        {
            int rows = 2;
            int columns = 2;

            Game myGame = new Game(rows, columns);
            myGame.Init();
            Assert.AreEqual(myGame.InputGrid[0, 0].IsAlive, false);
            Assert.AreEqual(myGame.InputGrid[0, 1].IsAlive, false);
            Assert.AreEqual(myGame.InputGrid[1, 0].IsAlive, false);
            Assert.AreEqual(myGame.InputGrid[1, 1].IsAlive, false);
        }

        /// <summary>
        ///A Block pattern test for Init
        ///</summary>
        [TestMethod()]
        public void InitBlockPatternTest()
        {
            int rows = 2;
            int columns = 2;
            Game target = new Game(rows, columns);
            target.FlipGridCell(0, 0);
            target.FlipGridCell(0, 1);
            target.FlipGridCell(1, 0);
            target.FlipGridCell(1, 1);
            target.MaxGenerations = 100;// This pattern remains unchanged for infinite generation, testing it for 100 generations
            target.Init();
            Assert.AreEqual(target.InputGrid[0, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[0, 1].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 1].IsAlive, true);
        }

        /// <summary>
        ///A boat pattern test for Init
        ///</summary>
        [TestMethod()]
        public void InitBoatPatternTest()
        {
            int rows = 3;
            int columns = 3;
            Game target = new Game(rows, columns);
            target.FlipGridCell(0, 0);
            target.FlipGridCell(0, 1);
            target.FlipGridCell(1, 0);
            target.FlipGridCell(1, 2);
            target.FlipGridCell(2, 1);
            target.Init();
            Assert.AreEqual(target.InputGrid[0, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[0, 1].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 2].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 2].IsAlive, true);
            Assert.AreEqual(target.InputGrid[2, 1].IsAlive, true);
        }

    }
}
