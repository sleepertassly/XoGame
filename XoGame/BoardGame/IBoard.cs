namespace BoardGame
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a board from the huge collection of board games.
    /// </summary>
    public interface IBoard : IUiElement
    {
        /// <summary>
        /// Gets the players of the board game.
        /// </summary>
        IEnumerable<IPlayer> Players { get; }

        /// <summary>
        /// Gets the cells of the board.
        /// </summary>
        IEnumerable<ICell> Cells { get; }

        /// <summary>
        /// Defines the winner of the game.
        /// </summary>
        /// <returns>The player which has won the game or null in case no winer has been declared.</returns>
        IPlayer Winner();
    }
}
