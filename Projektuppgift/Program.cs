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

            Post post1 = new Post ("Post1", new DateTime(2021, 1, 1), "Body1", Tags.Diary);
            Post post2 = new Post ("Post2", new DateTime(2021, 12, 2), "Body2", Tags.Note);
            Post post3 = new Post ("Post3", new DateTime(2022, 3, 3), "Body3", Tags.Quote);
            Post post4 = new Post ("Post4", new DateTime(2022, 3, 4), "Body4", Tags.Poem);
            postManager.Posts.Add(post1);
            postManager.Posts.Add(post2);
            postManager.Posts.Add(post3);
            postManager.Posts.Add(post4);

            mainMenu.Run();

        }
    }
}