namespace BoardGame
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A general implementation if the IUiElement.
    /// </summary>
    public abstract class UiElement : IUiElement
    {
        /// <summary>
        /// Gets the child elements of the current element.
        /// </summary>
        public ICollection<IUiElement> ChildElements { get; }

        /// <summary>
        /// Initializes a new instance of the UiElement abstarct class.
        /// </summary>
        public UiElement()
        {
            ChildElements = new List<IUiElement>();
        }

        /// <summary>
        /// Displays (write) the element with/without its child elements in the console.
        /// </summary>
        public virtual void Display()
        {
            foreach (var childElement in ChildElements)
            {
                childElement.Display();
            }
        }

        /// <summary>
        /// Stops the console application until a user action (key) is executed.
        /// </summary>
        /// <returns>The long-awaited user action (key).</returns>
        public virtual ConsoleKey WaitForUserAction()
        {
            return Console.ReadKey().Key;
        }

        /// <summary>
        /// Executes a user action (key).
        /// </summary>
        /// <param name="key">The user action.</param>
        /// <returns>true if the user action has been processed completely; otherwise false.</returns>
        public virtual bool ExecuteUserAction(ConsoleKey key)
        {
            foreach (var childElement in ChildElements)
            {
                if (childElement.ExecuteUserAction(key))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
