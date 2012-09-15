using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife;

namespace GameOfLifeTest
{
    [TestClass]
    public class GridTest
    {
        /// <summary>
        ///A test for Game Constructor
        ///</summary>
        [TestMethod()]
        public void GridConstructorPositiveTest()
        {
            int rows = 2;
            int columns = 2;
            Grid target = new Grid(rows, columns);
            Assert.AreEqual(target.RowCount, 2);
            Assert.AreEqual(target.ColumnCount, 2);
        }


        /// <summary>
        ///A test for Game Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Grid's Row and Column size must be greater than or equal to zero")]
        public void GridConstructorTest1()
        {
            int rows = -1;
            int columns = 0;
            Grid target = new Grid(rows, columns);

        }

        /// <summary>
        ///A test for Grid's Row
        ///</summary>
        [TestMethod()]
        public void GridRowPositiveTest()
        {
            Row row = new Row();
            Cell cell1 = new Cell(true);
            Cell cell2 = new Cell(true);
            Cell cell3 = new Cell(true);
            Cell cell4 = new Cell(false);

            row.AddCell(cell1);
            row.AddCell(cell2);
            row.AddCell(cell3);
            row.InsertCell(2, cell4, 1);

            Assert.AreEqual(row.Cells[2].IsAlive, false);
        }

        

    }
}