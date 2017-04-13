namespace BoardGame
{
    /// <summary>
    /// Represents a menu of a console application.
    /// </summary>
    public interface IMenu : IUiElement
    {
        /// <summary>
        /// The selected option from the available menu options.
        /// </summary>
        MenuOptions SelectedOption { get; set; }
    }
}
