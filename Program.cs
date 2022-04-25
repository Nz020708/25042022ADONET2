using System;
using System.Data.SqlClient;

namespace Ado.net2
{
    class Program
    {
        private const string connString = "Server=DESKTOP-4L8DU14;Database=SCHOOL;Integrated Security=true;";
        static void Main(string[] args)
        {
            Console.WriteLine("Enter num:");
            int value = Convert.ToInt32(Console.ReadLine());
            switch (value)
            {
                case 1:
                    Insert();
                    break;
                case 2:
                    Delete();
                    break;
                case 3:
                    Update();
                    break;
                case 4:
                    SelectAll();
                    break;
                default:
                    Console.WriteLine("BELE SECHIM YOXDUR!");
                    break;
            }
        }
        public static void Insert()
        {
            bool isExist;
            
            try
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();
                SqlConnection connection = new SqlConnection(connString);
                connection.Open();
                string query = $"INSERT INTO GROUPPP VALUES('{name}')";
                SqlCommand command = new SqlCommand(query, connection);
                int result = command.ExecuteNonQuery();
                if (result < 1)
                {
                    Console.WriteLine("ERROR");
                }
                connection.Close();
                isExist = false;
            }
            catch (Exception)
            {
                Console.WriteLine("BELE QRUP MOVCUDDUR!");
                isExist = true;

            }

            do
            {
                Console.WriteLine("Yeniden daxil edin:");
                string name = Console.ReadLine();
                SqlConnection connection = new SqlConnection(connString);
                connection.Open();
                string query = $"INSERT INTO GROUPPP VALUES('{name}')";
                SqlCommand command = new SqlCommand(query, connection);
                int result = command.ExecuteNonQuery();
                if (result < 1)
                {
                    Console.WriteLine("ERROR");
                }
                connection.Close();
                isExist = true;
            }
            while (!isExist);

        }
        public static void Delete()
        {
            
            try
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();
                SqlConnection connection = new SqlConnection(connString);
                connection.Open();
                string query = $"DELETE FROM GROUPPP WHERE NAME=('{name}')";
                SqlCommand command = new SqlCommand(query, connection);
                int result = command.ExecuteNonQuery();
                if (result < 1)
                {
                    Console.WriteLine("ERROR");
                }
                connection.Close();
            }
                

            catch (Exception)
            {
                Console.WriteLine("BELE QRUP MOVCUD DEYIL!");
            }
            finally
            {
                Console.WriteLine("YENIDEN DAXIL EDIN:");
                string name = Console.ReadLine();
                SqlConnection connection = new SqlConnection(connString);
                connection.Open();
                string query = $"DELETE FROM GROUPPP WHERE NAME=('{name}')";
                SqlCommand command = new SqlCommand(query, connection);
                int result = command.ExecuteNonQuery();
                if (result < 1)
                {
                    Console.WriteLine("ERROR");
                }
                connection.Close();
            }
        }
        public static void Update()
        {
            Console.WriteLine("Enter id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new name:");
            string name = Console.ReadLine();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string query = $"UPDATE  GROUPPP SET NAME='{name}' WHERE ID=('{id}')";
            SqlCommand command = new SqlCommand(query, connection);
            int result = command.ExecuteNonQuery();
            if (result < 1)
            {
                Console.WriteLine("ERROR");
            }

        }
        public static void SelectAll()
        {

            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string query = $"SELECT * FROM GROUPPP";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataReader result = command.ExecuteReader();
                while (result.Read())
                {
                    Console.WriteLine(result["name"]);
                }
            }
            connection.Close();
        }
    }
}
