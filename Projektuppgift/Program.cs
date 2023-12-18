namespace Projektuppgift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region CreateMenus
            Menu searchMenu = new Menu(
                new MenuItem("Search by title", () => Console.WriteLine("wip")),
                new MenuItem("Search by date", () => Console.WriteLine("wip")),
                new MenuItem("Search by tags", () => Console.WriteLine("wip"))
            );

            Menu mainMenu = new Menu(
                new MenuItem("say yo", () => Console.WriteLine("yo")),
                new MenuItem("say balls", () => Console.WriteLine("balls")),
                new MenuItem("Search", () => searchMenu.Run())
            );
            #endregion

            mainMenu.Run();
        }
    }
}