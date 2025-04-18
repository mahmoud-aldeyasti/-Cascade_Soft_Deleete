using Save_Changes_interceptors.Data.Helper;

namespace Save_Changes_interceptors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBaseHelper.CreateOrRecreateDataBase();

            DataBaseHelper.PopulateDatabase(); 

            Console.WriteLine( " Before Deleting First Blog: " );

            DataBaseHelper.ShowBlogs(); 

            DataBaseHelper.ShowPosts();

            DataBaseHelper.DeleteFirstBlog(); 

            Console.WriteLine( " After Deleting First Blog: let's see blogs and posts records" );

            DataBaseHelper.ShowBlogs(); 

            DataBaseHelper.ShowPosts();


        }
    }
}
