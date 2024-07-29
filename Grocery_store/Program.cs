using MySql.Data.MySqlClient;

namespace Grocery_store;

class Program
{
    public static MySqlConnection connection = new MySqlConnection("server=localhost;port=5687;database=store;username=root;password=Vergeeten1?;");
    static void Main(string[] args)
    {
        createProductsTable();
        // insertProductData();
        selectLowQuantity();
        updateStock();
        removeVegetables();
        selectLowQuantity();
    }

    public static void createProductsTable() {
        try {
            connection.Open();
            Console.WriteLine("Connection opened succesfully");
            string createProductsText = "CREATE TABLE IF NOT EXISTS products (id INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(100), category VARCHAR(100), price FLOAT, stock_quantity INT)";
            MySqlCommand createProducts = new MySqlCommand(createProductsText, connection);
            createProducts.ExecuteNonQuery();
            Console.WriteLine("Created table");
            connection.Close();
        } catch (Exception ex) {
            Console.WriteLine($"EXCEPTION: {ex.ToString()}");
        }
    }

    public static void insertProductData(){
        object[,] groceryItemsData = new object[,]
        {
            { "Bananas", "Fruits", 0.99f, 150 },
            { "Apples", "Fruits", 1.49f, 100 },
            { "Carrots", "Vegetables", 0.79f, 200 },
            { "Potatoes", "Vegetables", 1.29f, 180 },
            { "Milk", "Dairy", 2.49f, 80 },
            { "Eggs", "Dairy", 1.99f, 120 },
            { "Bread", "Bakery", 1.99f, 90 },
            { "Chicken", "Meat", 4.99f, 50 },
            { "Rice", "Grains", 3.99f, 120 },
            { "Pasta", "Grains", 1.49f, 150 }
        };
        try {
            connection.Open();

            for (int i = 0; i < 10; i++) {
                string productName = (string)groceryItemsData[i, 0];
                string productCategory = (string)groceryItemsData[i, 1];
                float productPrice = (float)groceryItemsData[i, 2];
                int productQuantity = (int)groceryItemsData[i, 3];

                string insertCmdText = $"INSERT INTO products (name, category, price, stock_quantity) VALUES ('{productName}', '{productCategory}', {productPrice}, {productQuantity});";
                var insertCmd = new MySqlCommand(insertCmdText, connection);
                insertCmd.ExecuteNonQuery();
                Console.WriteLine($"-- Row {i}: name = {productName} inserted");

            }

            connection.Close();
        } catch (Exception ex) {
            Console.WriteLine($"Error: {ex}");
        }

    }

    public static void selectLowQuantity () {
        try {
            connection.Open();
            string lowQuantityQueryText = "SELECT * FROM products WHERE stock_quantity < 100;";
            MySqlCommand lowQuantityQuery = new MySqlCommand(lowQuantityQueryText, connection);

            using(MySqlDataReader reader = lowQuantityQuery.ExecuteReader()) {
                while(reader.Read()){
                    // select where quantity is below 100
                    int id = (int)reader.GetInt32("id");
                    string name = (string)reader.GetString("name");
                    string category = (string)reader.GetString("category");
                    float price = (float)reader.GetFloat("price");
                    int quantity = (int)reader.GetInt32("stock_quantity");

                    Console.WriteLine($"{id}, {name}, {category}, {price}, {quantity}");
                };
            }

            connection.Close();

        } catch (Exception ex) {
            Console.WriteLine($"Error: {ex}");
        }
    }

    public static void updateStock() {
        try {
            connection.Open();
            string updateStatement = "UPDATE products SET stock_quantity = 200 WHERE stock_quantity < 100 ";
            MySqlCommand updateCommand = new MySqlCommand(updateStatement, connection);
            updateCommand.ExecuteNonQuery();
            Console.WriteLine("Succesfully Updated stock!");
            connection.Close();
        } catch (Exception ex) {
            Console.WriteLine($"Error: {ex}");
        }
        connection.Close();
    }

    public static void removeVegetables() {
        try {
            connection.Open();
            string deleteVegetablesStatement = "DELETE FROM products WHERE category = 'Vegetables'";
            MySqlCommand deleteVegetablesCommand = new MySqlCommand(deleteVegetablesStatement, connection);
            deleteVegetablesCommand.ExecuteNonQuery();
            Console.WriteLine("Removed vegetables");
            connection.Close();
        } catch (Exception ex) {
            Console.WriteLine($"Error: {ex}");
        }
    }
}
