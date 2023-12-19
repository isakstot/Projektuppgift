namespace Projektuppgift
{
    internal class Program
    {
        static void Main(string[] args)
        {

            PostManage postManager = new PostManage();
            #region CreateMenus
            Menu searchMenu = new Menu(
                new MenuItem("Search by title", () => postManager.SearchPost("title")),
                new MenuItem("Search by date", () => postManager.SearchPost("date")),
                new MenuItem("Search by tags", () => postManager.SearchPost("tag"))
            );

            Menu mainMenu = new Menu(
                new MenuItem("Create post", () => postManager.CreatePost()),
                new MenuItem("Print all posts", () => postManager.PrintPosts()),
                new MenuItem("Delete post", () => postManager.DeletePost()),
                new MenuItem("Say balls", () => Console.WriteLine("balls")),
                new MenuItem("Search", () => searchMenu.Run())
            );
            #endregion

            mainMenu.Run();
        }
    }
}