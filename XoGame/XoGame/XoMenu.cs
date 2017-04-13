namespace XoGame
{
    using BoardGame;
    using System;

    /// <summary>
    /// Implements the main menu of the XO game.
    /// </summary>
    class XoMenu : UiElement, IMenu
    {
        /// <summary>
        /// The selected option from the available menu options.
        /// </summary>
        public MenuOptions SelectedOption { get; set; }

        /// <summary>
        /// Executes a user action (key).
        /// </summary>
        /// <param name="key">The user action.</param>
        /// <returns>true if the user action has been processed completely; otherwise false.</returns>
        public override bool ExecuteUserAction(ConsoleKey key)
        {
            if (!base.ExecuteUserAction(key))
            {
                switch (key)
                {
                    case ConsoleKey.N:
                        if (SelectedOption == MenuOptions.StandBy)
                        {
                            SelectedOption = MenuOptions.InGame;
                        }
                        return true;
                    case ConsoleKey.Q:
                        if (SelectedOption == MenuOptions.StandBy)
                        {
                            SelectedOption = MenuOptions.Quit;
                        }
                        return true;
                    case ConsoleKey.Escape:
                        if (SelectedOption == MenuOptions.InGame)
                        {
                            SelectedOption = MenuOptions.StandBy;
                        }
                        break;
                    default:
                        break;
                }
            }

            return false;
        }

        /// <summary>
        /// Displays (write) the element with/without its child elements in the console.
        /// </summary>
        public override void Display()
        {
            Console.WriteLine();
            switch (SelectedOption)
            {
                case MenuOptions.InGame:
                    Console.WriteLine("/////////////////////////////////////////");
                    Console.WriteLine("-----------------------------------------");
                    if (ChildElements != null)
                    {
                        foreach (var childElement in ChildElements)
                        {
                            childElement.Display();
                        }
                    }
                    break;
                case MenuOptions.Quit:
                case MenuOptions.StandBy:
                default:
                    Console.WriteLine("/////////////////////////////////////////");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Press 'Q' for Quit or 'N' for New Game.");
                    break;
            }
        }
    }
}
