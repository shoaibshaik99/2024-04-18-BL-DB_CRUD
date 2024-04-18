using System.Data.SqlClient;

namespace DB_CRUD
{
    public static class SQLQuery
    {
        public static void InsertQuery(SqlConnection sqlDBConnection)
        {
            Console.WriteLine("Enter a username to add");
            string usrName = Console.ReadLine();

            Console.WriteLine("Enter the age of user");
            int usrAge = Convert.ToInt32(Console.ReadLine());

            string insertQuery = $"INSERT INTO Details(user_name,user_age) VALUES('{usrName}',{usrAge})";
            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlDBConnection);
            insertCommand.ExecuteNonQuery();
        }

        public static void RetrieveQuery(SqlConnection sqlDBConnection)
        {
            string retrieveQuery = "SELECT * FROM Details";
            SqlCommand retrieveCommand = new SqlCommand(retrieveQuery, sqlDBConnection);

            SqlDataReader sqlDataReader = retrieveCommand.ExecuteReader();

            Console.WriteLine("\n*****Start of Table****\n");

            while(sqlDataReader.Read())
            {
                Console.WriteLine();
                Console.Write($"User ID: {sqlDataReader.GetValue(0)}\t");
                Console.Write($"User Name: {sqlDataReader.GetValue(1)}\t");
                Console.WriteLine($"User Age: {sqlDataReader.GetValue(2)}");
                Console.WriteLine();
            }
            sqlDataReader.Close();
            Console.WriteLine("\n*****End of Table****\n");
        }

        public static void UpdateQuery(SqlConnection sqlDBConnection)
        {
            Console.WriteLine("Enter the user ID to update it's details");
            int usrId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the updated name");
            string updName = Console.ReadLine();

            Console.WriteLine("Enter the updated Age");
            int updAge = Convert.ToInt32(Console.ReadLine());

            string updateQuery = $"UPDATE Details SET user_name = '{updName}', user_age = {updAge} WHERE user_id = {usrId}";
            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlDBConnection);
            updateCommand.ExecuteNonQuery();
        }

        public static void DeleteQuery(SqlConnection sqlDBConnection)
        {
            Console.WriteLine("Enter the user Id to delete");
            int delUsrId = Convert.ToInt32(Console.ReadLine());

            string deleteQuery = $"DELETE FROM Details\r\nWHERE user_id = {delUsrId}";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlDBConnection);
            deleteCommand.ExecuteNonQuery();
        }
    }
}