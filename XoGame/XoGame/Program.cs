namespace XoGame
{
    using BoardGame;

    class Program
    {
        static void Main(string[] args)
        {
            IMenu menu = new XoMenu();
            menu.ChildElements.Add(new XoBoard());
            while (menu.SelectedOption != MenuOptions.Quit)
            {
                menu.Display();
                menu.ExecuteUserAction(menu.WaitForUserAction());
            }
        }
    }
}
