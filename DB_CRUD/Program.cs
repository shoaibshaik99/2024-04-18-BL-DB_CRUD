using System.Data.SqlClient;
using System.Diagnostics;

namespace DB_CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=Laptop\\SQLEXPRESS;Initial Catalog=LocalDB;Integrated Security=True";
            SqlConnection sqlDBConnection = new SqlConnection(connectionString);
            sqlDBConnection.Open();

            bool loopIsActive = true;

            while (loopIsActive)
            {
                Console.WriteLine("\nSelect an operation to perform on Details table in LocalDB Database" +
                "\n1. Insert Data Into Table" +
                "\n2. View Data Table" +
                "\n3. Alter data into table" +
                "\n4. Delete record from table" +
                "\n5. Exit Program");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //Insert Op
                        SQLQuery.InsertQuery(sqlDBConnection);
                        break;
                    case 2:
                        //Retrieve Op
                        SQLQuery.RetrieveQuery(sqlDBConnection);
                        break;
                    case 3:
                        //Update Op
                        SQLQuery.RetrieveQuery(sqlDBConnection);
                        SQLQuery.UpdateQuery(sqlDBConnection);
                        SQLQuery.RetrieveQuery(sqlDBConnection);
                        break;
                    case 4:
                        //Delete Op
                        SQLQuery.RetrieveQuery(sqlDBConnection);
                        SQLQuery.DeleteQuery(sqlDBConnection);
                        SQLQuery.RetrieveQuery(sqlDBConnection);
                        break;
                    case 5:
                        loopIsActive = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }
            }
            
            sqlDBConnection.Close();
        }
    }
}
