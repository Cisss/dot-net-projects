using MySql.Data.MySqlClient;
using System.Data;

public class StoredProcedure_1
{
    // Write the connection string here
    public static string connectionString = "host=localhost;port=5687;user=root;password=Vergeeten1?;database=store;";
    public static string procedureCode =
             @"DROP PROCEDURE IF EXISTS SetupTable;
            DROP TABLE IF EXISTS Employees;

            CREATE PROCEDURE `SetupTable` ()
            BEGIN
	            CREATE TABLE IF NOT EXISTS Employees (
		            EmployeeID INT AUTO_INCREMENT PRIMARY KEY,
		            FirstName VARCHAR(50),
		            LastName VARCHAR(50),
		            Age INT,
		            Gender ENUM('Male', 'Female', 'Other'),
		            Department VARCHAR(50),
		            Position VARCHAR(50),
		            Salary DECIMAL(10, 2)
	            );

	            INSERT INTO Employees (FirstName, LastName, Age, Gender, Department, Position, Salary) VALUES
		            ('John', 'Doe', 30, 'Male', 'IT', 'Software Engineer', 60000.00),
		            ('Jane', 'Smith', 35, 'Female', 'HR', 'HR Manager', 70000.00),
		            ('Alice', 'Johnson', 40, 'Female', 'Finance', 'Accountant', 55000.00),
		            ('Bob', 'Jones', 45, 'Male', 'Marketing', 'Marketing Manager', 75000.00),
		            ('Emily', 'Brown', 28, 'Female', 'Sales', 'Sales Representative', 50000.00);

				SELECT FirstName, LastName, Position, Salary FROM Employees ORDER BY Salary DESC LIMIT 3;
            END;";

    public static void Main(string[] args)
    {
        DataReader();
        DataSets();
    }

    public static void DataReader() {
         // 1. Using the '@' character before a string enables us to write it in multiple lines;
        // 2. We don't need to change the DELIMITER when creating a procedure from C# code;

        try {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // A stored procedure can be created by executing it like any other SQL command.
                MySqlCommand createStoredProcedureCmd = new MySqlCommand(procedureCode, connection);
                createStoredProcedureCmd.ExecuteNonQuery();

                // call `SetupTable` and display, name, position and salary of the top three employees.
                string callStoredProcedureStatement = "Call `SetupTable`";
                MySqlCommand callStoredProcedureCmd = new MySqlCommand(callStoredProcedureStatement, connection);
                Console.WriteLine("Name, Position, Salary");
                using(MySqlDataReader reader = callStoredProcedureCmd.ExecuteReader()) {
                    {
                        while (reader.Read()) {
                            string firstName = reader.GetString("FirstName");
                            string lastName = reader.GetString("LastName");
                            string position = reader.GetString("Position");
                            float salary = reader.GetFloat("Salary");

                            Console.WriteLine($"{firstName} {lastName}, {position}, {salary}");
                        }
                    }
                }
            }

        }catch (Exception ex) {
            Console.WriteLine(ex);
        }
        Console.WriteLine("Yes I know, I'm amazing!!!");
    }

    public static void DataSets() {

        using (MySqlConnection connection = new MySqlConnection(connectionString)) {
            string selectEmployeeStatement = "SELECT FirstName, LastName, Position, Salary FROM Employees ORDER BY Salary DESC LIMIT 3;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectEmployeeStatement, connection);
            DataSet store_dataset = new DataSet();
            adapter.Fill(store_dataset);

            DataTable table = store_dataset.Tables[0];

            Console.WriteLine("Again!!!");
            Console.WriteLine("Name, Position, Salary");

            foreach (DataRow row in table.Rows) {
                string firstName = (string)row["FirstName"];
                string lastName = (string)row["LastName"];
                string position = (string)row["Position"];
                decimal salary = (decimal)row["Salary"];

                Console.WriteLine($"{firstName} {lastName}, {position}, {salary}");
            }
            Console.WriteLine("Wow so cool!!!");
        }
    }
}