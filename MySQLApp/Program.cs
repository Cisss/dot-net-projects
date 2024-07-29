using MySql.Data.MySqlClient;

namespace MySQLApp;

public class MySqlCreateDatabase
{
    public static MySqlConnection connection = new MySqlConnection("server=localhost;port=5687;database=school;user=root;password=Vergeeten1?;");
    static void Main(string[] args)
    {
        CreateDataBase();
        CreateTable();
        CreateTeachersTable();
    }

    public static void CreateDataBase() {
            try {
                connection.Open();
                Console.WriteLine("Succesfully connected to the server!");

                string cmdText = "CREATE DATABASE IF NOT EXISTS `school`;";
                MySqlCommand cmd = new MySqlCommand(cmdText, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Database Created");

            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
    }

    public static void CreateTable() {
        try {
                connection.Open();
                Console.WriteLine("Succesfully connected to the server!");

                string[] studentNames = {
                    "Amber van der Want",
                    "Marc Bouma",
                    "Francisca van der Want",
                    "Malou de Ruiter",
                    "Milou de juffrouw",
                    "Boris van der Want",
                    "Akke van der Weij",
                    "Andrea Lubberdink",
                    "Nieke de Haan",
                    "Faya Moeilijke Achternaam",
                    "Abia one out of two"
                };

                new MySqlCommand("DROP TABLE students", connection).ExecuteNonQuery();
                Console.WriteLine("Dropped TABLE students");
                string tableCmd = "CREATE TABLE IF NOT EXISTS students (id INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(30), age INT)";
                var cmd = new MySqlCommand(tableCmd, connection);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Created TABLE students");

                for(int i = 0; i < studentNames.Length; i++ ) {
                    int age = new Random().Next(20, 30);
                    string insertCmdText = $"INSERT INTO students (name, age) VALUE ('{studentNames[i]}', {age});";
                    var insertCmd = new MySqlCommand(insertCmdText, connection);
                    insertCmd.ExecuteNonQuery();
                    Console.WriteLine($"-> Inserted Row {i + 1}");
                }
                string queryCmdText = "SELECT * FROM students";
                var queryCmd = new MySqlCommand(queryCmdText, connection);
                using(MySqlDataReader reader = queryCmd.ExecuteReader()) {
                    while(reader.Read()) {
                        var studentId = reader.GetInt32("id");
                        string studentName = reader.GetString("name");
                        int studentAge = reader.GetInt32("age");

                        Console.WriteLine($">> ID: {studentId}, NAME: {studentName}, AGE: {studentAge}");
                    }
                }

                string ScalerCmdText = "SELECT name FROM students WHERE id = 5;";
                var ScalerCmd = new MySqlCommand(ScalerCmdText, connection);
                string selectedStudent = (string) ScalerCmd.ExecuteScalar();
                Console.WriteLine($"The student you where looking for is: {selectedStudent}!");
                connection.Close();

            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
    }

    public static void CreateTeachersTable() {
        try {
            connection.Open();
            // Drop table teachers to avoid duplicate data
            new MySqlCommand("DROP TABLE teachers", connection).ExecuteNonQuery();

            // Create table teachers and insert data
            string teachersCmdText = "CREATE TABLE teachers (id INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(30), age INT, experience FLOAT)";
            var teachersCmd = new MySqlCommand(teachersCmdText, connection);
            teachersCmd.ExecuteNonQuery();
            Console.WriteLine("Teacher table created");
            string teacherCmdText = "INSERT INTO teachers (name, age, experience) VALUES ('John Smith', 35, 5.5); INSERT INTO teachers (name, age, experience) VALUES ('Anna Johnson', 40, 8.2); INSERT INTO teachers (name, age, experience) VALUES ('Robert Davis', 32, 3.1)";
            var teacherCmd = new MySqlCommand(teacherCmdText, connection);
            teacherCmd.ExecuteNonQuery();

            // show teacher data
            string teacherQueryCmdText = "SELECT * FROM teachers";
            var teacherQueryCmd = new MySqlCommand(teacherQueryCmdText, connection);
            using(MySqlDataReader reader = teacherQueryCmd.ExecuteReader()) {
                while(reader.Read()) {
                    var teacherId = reader.GetInt32("id");
                    string teacherName = reader.GetString("name");
                    int teacherAge = reader.GetInt32("age");
                    float teacherExperience = reader.GetFloat("experience");

                    Console.WriteLine($">> id: {teacherId}, name: {teacherName}, age: {teacherAge}, experience in years: {teacherExperience}");
                }
            };

            connection.Close();

        } catch (Exception ex) {
            Console.WriteLine(ex.ToString());
        }
    }
}
