using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Cell corners are different possible corners of cell in grid of any size
    /// Every cell corner has distinct reachable adjacent cells which can be traversed
    /// </summary>
    enum CellCornersEnum
    {
        TopLeftCorner,
        TopRightCorner,
        BottomLeftCorner,
        BottomRightCorner,
        TopSide,
        BottomSide,
        LeftSide,
        RightSide,
        Center,
        OuterTopSide,
        OuterRightSide,
        OuterBottomSide,
        OuterLeftSide,
        None
    }
    /// <summary>
    /// structure to hold x and y indices of grid cell
    /// </summary>
    struct CoOrdinates
    {
        public int X;
        public int Y;
        public CoOrdinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    
    static class HelperFactory
    {

        // Dictionary to hold list of reachable cells co-ordinates for specified cell corner
        public static Dictionary<CellCornersEnum, List<CoOrdinates>> ReachableCells;
        /// <summary>
        /// initialize all reachable cells in Dictionary(Key=> CellCornersEnum, Value => List of Reachable cell co-ordinates
        /// </summary>
        public static void InitializeReachableCells()
        {
            CellCornersEnum innerCell;
            ReachableCells = new Dictionary<CellCornersEnum, List<CoOrdinates>>();

            // Add Reachable adjacent cell co-ordinates for Top Left corner cell into Dictionary with TopLeftCorner CellCornersEnum as key
            innerCell = CellCornersEnum.TopLeftCorner;
            List<CoOrdinates> TopLeftCoOrdinateList = new List<CoOrdinates>();
            TopLeftCoOrdinateList.Add(new CoOrdinates(0, 1));
            TopLeftCoOrdinateList.Add(new CoOrdinates(1, 1));
            TopLeftCoOrdinateList.Add(new CoOrdinates(1, 0));
            ReachableCells.Add(innerCell, TopLeftCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for Top right corner cell into Dictionary with TopRightCorner CellCornersEnum as key
            innerCell = CellCornersEnum.TopRightCorner;
            List<CoOrdinates> TopRightCoOrdinateList = new List<CoOrdinates>();
            TopRightCoOrdinateList.Add(new CoOrdinates(1, 0));
            TopRightCoOrdinateList.Add(new CoOrdinates(1, -1));
            TopRightCoOrdinateList.Add(new CoOrdinates(0, -1));
            ReachableCells.Add(innerCell, TopRightCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for bottom left corner cell into Dictionary with BottomLeftCorner CellCornersEnum as key
            innerCell = CellCornersEnum.BottomLeftCorner;
            List<CoOrdinates> BottomLeftCoOrdinateList = new List<CoOrdinates>();
            BottomLeftCoOrdinateList.Add(new CoOrdinates(-1, 0));
            BottomLeftCoOrdinateList.Add(new CoOrdinates(-1, 1));
            BottomLeftCoOrdinateList.Add(new CoOrdinates(0, 1));
            ReachableCells.Add(innerCell, BottomLeftCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for bottom right corner cell into Dictionary with BottomRightCorner CellCornersEnum as key
            innerCell = CellCornersEnum.BottomRightCorner;
            List<CoOrdinates> BottomRightCoOrdinateList = new List<CoOrdinates>();
            BottomRightCoOrdinateList.Add(new CoOrdinates(0, -1));
            BottomRightCoOrdinateList.Add(new CoOrdinates(-1, -1));
            BottomRightCoOrdinateList.Add(new CoOrdinates(-1, 0));
            ReachableCells.Add(innerCell, BottomRightCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for top side cell into Dictionary with BottomRightCorner TopSide as key
            innerCell = CellCornersEnum.TopSide;
            List<CoOrdinates> TopSideCoOrdinateList = new List<CoOrdinates>();
            TopSideCoOrdinateList.Add(new CoOrdinates(0, 1));
            TopSideCoOrdinateList.Add(new CoOrdinates(1, 1));
            TopSideCoOrdinateList.Add(new CoOrdinates(1, 0));
            TopSideCoOrdinateList.Add(new CoOrdinates(1, -1));
            TopSideCoOrdinateList.Add(new CoOrdinates(0, -1));
            ReachableCells.Add(innerCell, TopSideCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for bottom side cell into Dictionary with BottomRightCorner BottomSide as key
            innerCell = CellCornersEnum.BottomSide;
            List<CoOrdinates> BottomSideCoOrdinateList = new List<CoOrdinates>();
            BottomSideCoOrdinateList.Add(new CoOrdinates(0, -1));
            BottomSideCoOrdinateList.Add(new CoOrdinates(-1, -1));
            BottomSideCoOrdinateList.Add(new CoOrdinates(-1, 0));
            BottomSideCoOrdinateList.Add(new CoOrdinates(-1, 1));
            BottomSideCoOrdinateList.Add(new CoOrdinates(0, 1));
            ReachableCells.Add(innerCell, BottomSideCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for left side cell into Dictionary with BottomRightCorner LeftSide as key
            innerCell = CellCornersEnum.LeftSide;
            List<CoOrdinates> LeftSideCoOrdinateList = new List<CoOrdinates>();
            LeftSideCoOrdinateList.Add(new CoOrdinates(-1, 0));
            LeftSideCoOrdinateList.Add(new CoOrdinates(-1, 1));
            LeftSideCoOrdinateList.Add(new CoOrdinates(0, 1));
            LeftSideCoOrdinateList.Add(new CoOrdinates(1, 1));
            LeftSideCoOrdinateList.Add(new CoOrdinates(1, 0));
            ReachableCells.Add(innerCell, LeftSideCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for right side cell into Dictionary with BottomRightCorner RightSide as key
            innerCell = CellCornersEnum.RightSide;
            List<CoOrdinates> RightSideCoOrdinateList = new List<CoOrdinates>();
            RightSideCoOrdinateList.Add(new CoOrdinates(1, 0));
            RightSideCoOrdinateList.Add(new CoOrdinates(1, -1));
            RightSideCoOrdinateList.Add(new CoOrdinates(0, -1));
            RightSideCoOrdinateList.Add(new CoOrdinates(-1, -1));
            RightSideCoOrdinateList.Add(new CoOrdinates(-1, 0));
            ReachableCells.Add(innerCell, RightSideCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for Center cell into Dictionary with BottomRightCorner Center as key
            innerCell = CellCornersEnum.Center;
            List<CoOrdinates> CenterCoOrdinateList = new List<CoOrdinates>();
            CenterCoOrdinateList.Add(new CoOrdinates(-1, 0));
            CenterCoOrdinateList.Add(new CoOrdinates(-1, 1));
            CenterCoOrdinateList.Add(new CoOrdinates(0, 1));
            CenterCoOrdinateList.Add(new CoOrdinates(1, 1));
            CenterCoOrdinateList.Add(new CoOrdinates(1, 0));
            CenterCoOrdinateList.Add(new CoOrdinates(1, -1));
            CenterCoOrdinateList.Add(new CoOrdinates(0, -1));
            CenterCoOrdinateList.Add(new CoOrdinates(-1, -1));
            ReachableCells.Add(innerCell, CenterCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for outer top side cell into Dictionary with BottomRightCorner OuterTopSide as key
            innerCell = CellCornersEnum.OuterTopSide;
            List<CoOrdinates> OuterTopSideCoOrdinateList = new List<CoOrdinates>();
            OuterTopSideCoOrdinateList.Add(new CoOrdinates(1, -1));
            OuterTopSideCoOrdinateList.Add(new CoOrdinates(1, 0));
            OuterTopSideCoOrdinateList.Add(new CoOrdinates(1, 1));
            ReachableCells.Add(innerCell, OuterTopSideCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for outer right side cell into Dictionary with BottomRightCorner OuterRightSide as key
            innerCell = CellCornersEnum.OuterRightSide;
            List<CoOrdinates> OuterRightSideCoOrdinateList = new List<CoOrdinates>();
            OuterRightSideCoOrdinateList.Add(new CoOrdinates(-1, -1));
            OuterRightSideCoOrdinateList.Add(new CoOrdinates(0, -1));
            OuterRightSideCoOrdinateList.Add(new CoOrdinates(1, -1));
            ReachableCells.Add(innerCell, OuterRightSideCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for outer bottom side cell into Dictionary with BottomRightCorner OuterBottomSide as key
            innerCell = CellCornersEnum.OuterBottomSide;
            List<CoOrdinates> OuterBottomSideCoOrdinateList = new List<CoOrdinates>();
            OuterBottomSideCoOrdinateList.Add(new CoOrdinates(-1, -1));
            OuterBottomSideCoOrdinateList.Add(new CoOrdinates(-1, 0));
            OuterBottomSideCoOrdinateList.Add(new CoOrdinates(-1, 1));
            ReachableCells.Add(innerCell, OuterBottomSideCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for outer left side cell into Dictionary with BottomRightCorner OuterLeftSide as key
            innerCell = CellCornersEnum.OuterLeftSide;
            List<CoOrdinates> OuterLeftSideCoOrdinateList = new List<CoOrdinates>();
            OuterLeftSideCoOrdinateList.Add(new CoOrdinates(-1, 1));
            OuterLeftSideCoOrdinateList.Add(new CoOrdinates(0, 1));
            OuterLeftSideCoOrdinateList.Add(new CoOrdinates(1, 1));
            ReachableCells.Add(innerCell, OuterLeftSideCoOrdinateList);

        }

        /// <summary>
        /// Return the cell corner enum for a co-ordinate with respect to grid 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="coOrdinates"></param>
        /// <returns>returns CellCornersEnum</returns>
        public static CellCornersEnum GetCellCorner(Grid grid, CoOrdinates coOrdinates)
        {
            if ((coOrdinates.X < -1 || coOrdinates.X > grid.RowCount) || (coOrdinates.Y < -1 || coOrdinates.Y > grid.ColumnCount))
            {
                throw new ArgumentOutOfRangeException("Invalid Index value: must be greater than or equal to minus one and less than or equal to Row count");
            }
            CellCornersEnum enumCellCorner = CellCornersEnum.None;
            if (coOrdinates.X == 0 && coOrdinates.Y == 0)
                enumCellCorner = CellCornersEnum.TopLeftCorner;
            else if (coOrdinates.X == 0 && coOrdinates.Y == grid.ColumnCount - 1)
                enumCellCorner = CellCornersEnum.TopRightCorner;
            else if (coOrdinates.X == grid.RowCount - 1 && coOrdinates.Y == 0)
                enumCellCorner = CellCornersEnum.BottomLeftCorner;
            else if (coOrdinates.X == grid.RowCount - 1 && coOrdinates.Y == grid.ColumnCount - 1)
                enumCellCorner = CellCornersEnum.BottomRightCorner;
            else if (coOrdinates.X == 0 && (coOrdinates.Y > 0 && coOrdinates.Y < grid.ColumnCount - 1))
                enumCellCorner = CellCornersEnum.TopSide;
            else if (coOrdinates.X == grid.RowCount - 1 && (coOrdinates.Y > 0 && coOrdinates.Y < grid.ColumnCount - 1))
                enumCellCorner = CellCornersEnum.BottomSide;
            else if ((coOrdinates.X > 0 && coOrdinates.X < grid.RowCount - 1) && coOrdinates.Y == 0)
                enumCellCorner = CellCornersEnum.LeftSide;
            else if ((coOrdinates.X > 0 && coOrdinates.X < grid.RowCount - 1) && coOrdinates.Y == grid.ColumnCount - 1)
                enumCellCorner = CellCornersEnum.RightSide;
            else if ((coOrdinates.X > 0 && coOrdinates.X < grid.RowCount - 1) && (coOrdinates.Y > 0 && coOrdinates.Y < grid.ColumnCount - 1))
                enumCellCorner = CellCornersEnum.Center;
            else if (coOrdinates.X == -1 && (coOrdinates.Y > 0 && coOrdinates.Y < grid.ColumnCount - 1))
                enumCellCorner = CellCornersEnum.OuterTopSide;
            else if ((coOrdinates.X > 0 && coOrdinates.X < grid.RowCount - 1) && coOrdinates.Y == grid.ColumnCount)
                enumCellCorner = CellCornersEnum.OuterRightSide;
            else if (coOrdinates.X == grid.RowCount && (coOrdinates.Y > 0 && coOrdinates.Y < grid.ColumnCount - 1))
                enumCellCorner = CellCornersEnum.OuterBottomSide;
            else if ((coOrdinates.X > 0 && coOrdinates.X < grid.RowCount - 1) && coOrdinates.Y == -1)
                enumCellCorner = CellCornersEnum.OuterLeftSide;
            return enumCellCorner;
        }        
        
        
        
        /// <summary>
        /// Used to display the grid in console
        /// </summary>
        public static void Display(Grid grid)
        {
            foreach (Row row in grid.GridObj)
            {
                foreach (Cell cell in row.Cells)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(cell.ToString());
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Copy Source grid cells to target grid cells
        /// </summary>
        /// <param name="sourceGrid"></param>
        /// <param name="targetGrid"></param>
        public static void Copy(Grid sourceGrid, Grid targetGrid)
        {
            MatchGridStructure(sourceGrid, targetGrid);
            targetGrid.ReInitialize();
            AssignCellValues(sourceGrid, targetGrid);
        }

        /// <summary>
        /// Set target grid schema similar to source grid schema 
        /// </summary>
        /// <param name="sourceGrid"></param>
        /// <param name="targetGrid"></param>
        private static void MatchGridStructure(Grid source, Grid target)
        {
            while (target.RowCount < source.RowCount)
            {
                Row newRow = new Row();
                for (int k = 0; k < target.ColumnCount; k++)
                {
                    Cell newCell = new Cell(false);
                    newRow.AddCell(newCell);
                }
                target.AddRow(newRow);
            }
            while (target.ColumnCount < source.ColumnCount)
            {
                Cell cell = new Cell(false);
                for (int k = 0; k < target.RowCount; k++)
                {
                    target[k].AddCell(cell);
                }
                target.ColumnCount += 1;
            }

        }

        /// <summary>
        /// Used to assign Source grid cell values to target grid cell values
        /// </summary>
        /// <param name="sourceGrid"></param>
        /// <param name="targetGrid"></param>
        private static void AssignCellValues(Grid source, Grid target)
        {
            for (int i = 0; i < source.RowCount; i++)
            {
                for (int j = 0; j < source.ColumnCount; j++)
                {
                    target[i, j].IsAlive = source[i, j].IsAlive;
                }
            }
        }
        
    }
}
