namespace BoardGame
{
    /// <summary>
    /// Represents a player of a game.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// The name (nickname) of the player.
        /// </summary>
        string Name { get; set; }
    }
}
