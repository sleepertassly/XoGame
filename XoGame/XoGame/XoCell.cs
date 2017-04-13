namespace XoGame
{
    using BoardGame;
    using System;

    /// <summary>
    /// Implements a cell of the XO game.
    /// </summary>
    class XoCell : ICell
    {
        /// <summary>
        /// Empty status of the cell.
        /// </summary>
        public const int Empty = 0;

        /// <summary>
        /// Occupied by player 1 status of the cell.
        /// </summary>
        public const int Player1 = 1;

        /// <summary>
        /// Occupied by player 2 status of the cell.
        /// </summary>
        public const int Player2 = 2;

        /// <summary>
        /// The status of the cell.
        /// </summary>
        private int cellStatus;
        public int CellStatus
        {
            get
            {
                return cellStatus;
            }

            set
            {
                if (value < 0 || value > 2)
                {
                    throw new ArgumentException("Invalid cell status!");
                }

                cellStatus = value;
            }
        }

        /// <summary>
        /// Returns a string that represents the cell.
        /// </summary>
        /// <returns>A string that represents the cell.</returns>
        public override string ToString()
        {
            switch (CellStatus)
            {
                case Player1:
                    return "X";
                case Player2:
                    return "O";
                default:
                    return " ";
            }
        }
    }
}
