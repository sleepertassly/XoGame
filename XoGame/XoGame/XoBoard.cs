namespace XoGame
{
    using BoardGame;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implements the board of the XO game.
    /// </summary>
    class XoBoard : UiElement, IBoard
    {
        /// <summary>
        /// The player who is currently playing on the board.
        /// </summary>
        private IPlayer currentPlayer;

        /// <summary>
        /// Gets the players of the board game.
        /// </summary>
        public IEnumerable<IPlayer> Players { get; private set; }


        /// <summary>
        /// Gets the cells of the board.
        /// </summary>
        private XoCell[] cells;
        public IEnumerable<ICell> Cells
        {
            get
            {
                return cells;
            }
        }

        /// <summary>
        /// Initializes a new instance of the XoBoard class.
        /// </summary>
        public XoBoard()
        {
            Players = new IPlayer[2]
            {
                new Player() { Name = "Player 1" },
                new Player() { Name = "Player 2" }
            };

            currentPlayer = Players.First();

            cells = Enumerable.Range(0, 9)
                              .Select(x => new XoCell() { CellStatus = XoCell.Empty })
                              .ToArray();
        }

        /// <summary>
        /// Displays (write) the XoBoard in the console.
        /// </summary>
        public override void Display()
        {
            Console.WriteLine(" {0} | {1} | {2}\t\t 7 | 8 | 9", cells[0], cells[1], cells[2]);
            Console.WriteLine("---|---|---\t\t---|---|---");
            Console.WriteLine(" {0} | {1} | {2} \t\t 4 | 5 | 6", cells[3], cells[4], cells[5]);
            Console.WriteLine("---|---|---\t\t---|---|---");
            Console.WriteLine(" {0} | {1} | {2} \t\t 1 | 2 | 3", cells[6], cells[7], cells[8]);
            Console.WriteLine();
            Console.Write("{0}", currentPlayer.Name);
            if (GameOver())
            {
                Console.WriteLine(" has won!");
                Console.WriteLine("Press 'N' for New Game or 'Esc' for exit.");
            }
            else
            {
                Console.WriteLine(":\nPress '1-9' to play a cell or 'Esc' for exit.");
            }
        }

        /// <summary>
        /// Executes a user action (key).
        /// </summary>
        /// <param name="key">The user action.</param>
        /// <returns>true if the user action has been processed completely; otherwise false.</returns>
        public override bool ExecuteUserAction(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    return PlayCell(6);
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    return PlayCell(7);
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    return PlayCell(8);
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    return PlayCell(3);
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    return PlayCell(4);
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    return PlayCell(5);
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    return PlayCell(0);
                case ConsoleKey.D8:
                case ConsoleKey.NumPad8:
                    return PlayCell(1);
                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    return PlayCell(2);
                case ConsoleKey.N:
                    ClearBoard();
                    break;
                case ConsoleKey.Escape:
                default:
                    break;
            }

            return false;
        }

        /// <summary>
        /// Defines the winner of the game.
        /// </summary>
        /// <returns>The player which has won the game or null in case no winer has been declared.</returns>
        public IPlayer Winner()
        {
            if (cells[0].CellStatus != XoCell.Empty
                && ((cells[0].CellStatus == cells[1].CellStatus && cells[1].CellStatus == cells[2].CellStatus)
                 || (cells[0].CellStatus == cells[3].CellStatus && cells[3].CellStatus == cells[6].CellStatus)))
            {
                return cells[0].CellStatus == XoCell.Player1 ? Players.ElementAt(0) : Players.ElementAt(1);
            }

            if (cells[4].CellStatus != XoCell.Empty
                && ((cells[0].CellStatus == cells[4].CellStatus && cells[4].CellStatus == cells[8].CellStatus)
                 || (cells[1].CellStatus == cells[4].CellStatus && cells[4].CellStatus == cells[7].CellStatus)
                 || (cells[2].CellStatus == cells[4].CellStatus && cells[4].CellStatus == cells[6].CellStatus)
                 || (cells[3].CellStatus == cells[4].CellStatus && cells[4].CellStatus == cells[5].CellStatus)))
            {
                return cells[4].CellStatus == XoCell.Player1 ? Players.ElementAt(0) : Players.ElementAt(1);
            }

            if (cells[8].CellStatus != XoCell.Empty
                && ((cells[2].CellStatus == cells[5].CellStatus && cells[5].CellStatus == cells[8].CellStatus)
                 || (cells[6].CellStatus == cells[7].CellStatus && cells[7].CellStatus == cells[8].CellStatus)))
            {
                return cells[3].CellStatus == XoCell.Player1 ? Players.ElementAt(0) : Players.ElementAt(1);
            }

            return null;
        }

        /// <summary>
        /// Clears the board.
        /// </summary>
        private void ClearBoard()
        {
            currentPlayer = Players.First();
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i].CellStatus = XoCell.Empty;
            }
        }

        /// <summary>
        /// Occupies a cell on the board; 
        /// currentPlayer is the activ player.
        /// </summary>
        /// <param name="index">The index of the cell to be occupied.</param>
        /// <returns>false if the cell is not playable by the current player; true if the cell has been played</returns>
        private bool PlayCell(int index)
        {
            if (index < 0 || index > 8)
            {
                throw new ArgumentException("The argument '{0}' must be between 1-9.", "index");
            }

            if (cells[index].CellStatus == XoCell.Empty && !GameOver())
            {
                if (currentPlayer == Players.ElementAt(0))
                {
                    cells[index].CellStatus = XoCell.Player1;
                }
                else
                {
                    cells[index].CellStatus = XoCell.Player2;
                }

                if (!GameOver())
                {
                    currentPlayer = Players.First(x => x != currentPlayer);
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the game is over or not.
        /// </summary>
        /// <returns>true if the game is over;otherwise false.</returns>
        private bool GameOver()
        {
            return Winner() != null;
        }
    }
}
