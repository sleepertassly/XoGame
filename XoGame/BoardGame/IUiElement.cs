namespace BoardGame
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a UI (User Interface) element of a console application.
    /// </summary>
    public interface IUiElement
    {
        /// <summary>
        /// Gets the child elements of the current element.
        /// </summary>
        ICollection<IUiElement> ChildElements { get; }

        /// <summary>
        /// Displays (write) the element with/without its child elements in the console.
        /// </summary>
        void Display();

        /// <summary>
        /// Stops the console application until a user action (key) is executed.
        /// </summary>
        /// <returns>The long-awaited user action.</returns>
        ConsoleKey WaitForUserAction();

        /// <summary>
        /// Executes a user action (key).
        /// </summary>
        /// <param name="key">The user action.</param>
        /// <returns>true if the user action has been processed completely; otherwise false.</returns>
        bool ExecuteUserAction(ConsoleKey key);
    }
}
