namespace Projektuppgift
{
    internal class Program
    {
        static void Main(string[] args)
        {

            PostManage postManager = new PostManage();
            #region CreateMenus
            Menu searchMenu = new Menu("Search menu",
                new MenuItem("Search by title", () => postManager.SearchPost("title")),
                new MenuItem("Search by date", () => postManager.SearchPost("date")),
                new MenuItem("Search by tags", () => postManager.SearchPost("tag"))
            );

            Menu mainMenu = new Menu("Main menu",
                new MenuItem("Create post", () => postManager.CreatePost()),
                new MenuItem("Print all posts", () => postManager.PrintPosts()),
                new MenuItem("Delete post", () => postManager.DeletePost()),
                //new MenuItem("Say balls", () => Console.WriteLine("balls")),
                new MenuItem("Search", () => searchMenu.Run())
            );
            #endregion

            postManager.ReadPosts();

            mainMenu.Run();

        }
    }
}