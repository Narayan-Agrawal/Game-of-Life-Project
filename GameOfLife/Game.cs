using System;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Game
    {
        private Grid _inputGrid;
        private Grid _outputGrid;
        public Grid InputGrid { get { return _inputGrid; } }  
        public Grid OutputGrid { get { return _outputGrid; } } 
         
        // Task for changing all existing Cell life Status whether dead or alive       
        private Task CellStatusUpdateTask;
        //Task for expanding output gird if the game rule is satisfied
        private Task GridGrowthUpdateTask;
        // MaxGeneration is used to restrict generations of grid changes
        public int MaxGenerations = 1; //deafult as 1

        // Get number of rows in grid
        public int RowCount { get { return InputGrid.RowCount; } }
        // Get or Set number of columns in grid
        public int ColumnCount { get { return InputGrid.ColumnCount; } }


        /// <summary>
        /// Create input and output grids by using rows and column count and initialize reachable cells.
        /// Reachable Cells are cells which can be traversed from inner grid cells or outer grid cells i.e. virtual cells used for expanding grid
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public Game(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0) throw new ArgumentOutOfRangeException("Size of Row and Column for the Grid must be greater than zero");
            _inputGrid = new Grid(rows, columns);
            _outputGrid = new Grid(rows, columns);
            HelperFactory.InitializeReachableCells();
        }

        /// <summary>
        /// Toggle state of input grid cells from live to dead or vice-verca
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void FlipGridCell(int x, int y)
        {            
            if (_inputGrid.RowCount <= x || _inputGrid.ColumnCount <= y) throw new ArgumentOutOfRangeException("Argument out of bound");
            _inputGrid.FlipCell(x, y);

        }

        /// <summary>
        /// Initialize the Game of lide
        /// </summary>
        public void Init()
        {
            Start();
        }
        /// <summary>
        /// Start Game of Life
        /// </summary>
        private void Start()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("************Welcome in the Game of Life***********");
            Console.ResetColor();

            int currentGeneration = 0;
            HelperFactory.Display(_inputGrid);
            do
            {
                currentGeneration++;
                // Process current generation for next generation
                ProcessGeneration();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Generation: "+currentGeneration);
                Console.ResetColor();
                // Display the input grid
                HelperFactory.Display(_inputGrid);
                // increment generation count                
            } while (currentGeneration < MaxGenerations);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("************This game is presented by Narayan Agrawal(09971427451)***********");
            Console.ResetColor();
        }
        /// <summary>
        /// Process current generation for next generation
        /// </summary>
        private void ProcessGeneration()
        {            
            SetNextGeneration();
            WaitForCompletion();
            FlipGridState();
        }

        /// <summary>
        /// Handles tasks for setting next generation
        /// </summary>
        private void SetNextGeneration()
        {
            // Generate next state of the Grid if last generate state process is completed
            if ((CellStatusUpdateTask == null) || (CellStatusUpdateTask != null && CellStatusUpdateTask.IsCompleted))
            {
                CellStatusUpdateTask = ChangeCellsState();
                // ensure that Output grid existing cells are updated. 
                //Otherwise it may result in unpredictable result in output grid if row or column is added in parallel
                CellStatusUpdateTask.Wait();  
            }
            if ((GridGrowthUpdateTask == null) || (GridGrowthUpdateTask != null && GridGrowthUpdateTask.IsCompleted))
            {
                GridGrowthUpdateTask = ChangeGridState();
            }
        }
        /// <summary>
        /// WaitForCompletion ensures that previous generation tasks are completed
        /// </summary>
        private void WaitForCompletion()
        {            
            if (GridGrowthUpdateTask != null)
            {
                GridGrowthUpdateTask.Wait();
            }
        }

        /// <summary>
        /// Set output grid to input grid by Deep Copy output grid into input grid
        /// </summary>
        private void FlipGridState()
        {
            HelperFactory.Copy(_outputGrid, _inputGrid);
            _outputGrid.ReInitialize();
        }

        /// <summary>
        /// Change state of all input cells into output cells Simultaneously using Parallel For
        /// </summary>
        /// <returns>returns EvaluateCellTask</returns>
        private Task ChangeCellsState()
        {
            return Task.Factory.StartNew(() =>
            Parallel.For(0, _inputGrid.RowCount, x =>
            {
                Parallel.For(0, _inputGrid.ColumnCount, y =>
                {
                    GameRules.ChangeCellsState(_inputGrid, _outputGrid, new CoOrdinates(x, y));
                });
            }));
        }
        /// <summary>
        /// Change state of grid if required
        /// </summary>
        /// <returns>returns EvaluateGridGrowthTask</returns>
        private Task ChangeGridState()
        {
            return Task.Factory.StartNew(delegate()
                {
                    GameRules.ChangeGridState(_inputGrid, _outputGrid);
                }
            );
        }
    }
}
