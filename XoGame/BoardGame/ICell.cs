namespace BoardGame
{
    /// <summary>
    /// Represents a cell of a board game.
    /// </summary>
    public interface ICell
    {
        /// <summary>
        /// The status of the cell.
        /// </summary>
        int CellStatus { get; set; }
    }
}
