using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

class Program {

    static string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    public static void Main(String[] args)
    {
        while (true) {
            Console.WriteLine("STUDENT REGISTRATION SYSTEM" +
                          "\n1 is CREATE New Student" +
                          "\n2 is READ all Students" +
                          "\n3 is UPDATE the Student" +
                          "\n4 is DELETE the Student");
            Console.WriteLine("Enter your Choice:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter the student name to Register:");
                    string name = Console.ReadLine();
                    CreateStudent(name);
                    break;
                case "2":
                    ReadStudent();
                    break;
                case "3":
                    Console.WriteLine("Enter the student id you want to change");
                    int studentIDupdate = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the new name");
                    string newName = Console.ReadLine();
                    UpdateStudent(studentIDupdate, newName);
                    break;
                case "4":
                    Console.WriteLine("Enter the student you want to delete");
                    int studentIDdelete = int.Parse(Console.ReadLine());
                    DeleteStudent(studentIDdelete);
                    break;


            }
        


        }
        //









    }
    public static void DeleteStudent(int StudentID)
    {
        using (SqlConnection sql_conn = new SqlConnection(connString))
        {
            try
            {
                sql_conn.Open();

                string query = "DELETE FROM Students WHERE StudentID = @StudentID";
                SqlCommand sqlCommand = new SqlCommand(query, sql_conn);

                sqlCommand.Parameters.AddWithValue("@StudentID", StudentID);
                

                sqlCommand.ExecuteNonQuery();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }


    public static void UpdateStudent(int StudentID, string newName)
    {
        using (SqlConnection sql_conn = new SqlConnection(connString))
        {
            try
            {
                sql_conn.Open();

                string query = "UPDATE Students SET StudentName =@Name WHERE StudentID =@StudentID";
                SqlCommand sqlCommand = new SqlCommand(query, sql_conn);

                sqlCommand.Parameters.AddWithValue("@StudentID", StudentID);
                sqlCommand.Parameters.AddWithValue("@Name", newName);

                sqlCommand.ExecuteNonQuery();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
    public static void ReadStudent()
    {
        using (SqlConnection sql_conn = new SqlConnection(connString))
        {
            try
            {
                sql_conn.Open();

                string query = "SELECT * FROM Students";
                SqlCommand sqlCommand = new SqlCommand(query, sql_conn);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader["StudentName"]);
                
                }
                reader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        
        }
    }
    public static void CreateStudent(string name) {

        using (SqlConnection sql_conn = new SqlConnection(connString)) {
            try
            {
                sql_conn.Open();
                Console.WriteLine("Connection is Successful");

                string query = "INSERT INTO Students (StudentName) VALUES (@StudentName)";

                SqlCommand sqlCommand = new SqlCommand(query, sql_conn);
                sqlCommand.Parameters.AddWithValue("@StudentName", name);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
            

    }
}