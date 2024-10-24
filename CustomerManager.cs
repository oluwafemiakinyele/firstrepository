using MySql.Data.MySqlClient;

public class CustomerManager
{
    private static string ConnectionString = "Server = localhost; User = root; database = EventDatabase; password = Philemon";

      public static void CreateCustomerTable()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "create table if not exists EventDatabase.Customer(Customerid int primary Key not null auto_increment, Customername varchar(255) Not Null, Customeremail varchar(255) Not Null UNIQUE, Customerpassword varbinary(200) Not Null, CustomerAge int Not Null);";

            MySqlCommand command = new MySqlCommand(query, connection);
            var execute = command.ExecuteNonQuery();

            if (execute == 0)
            {
                Console.WriteLine("Table Created Successfully.");
            }
            else
            {
                Console.WriteLine("Unable To Create Table.");
            }
        }
    }
 public static void CreateUser(Customer customer)
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            Console.WriteLine("Enter Your name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Your email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Your password");
            string password = Console.ReadLine();
            Console.WriteLine("Enter your age");
            int age = int.Parse(Console.ReadLine());
            connection.Open();
            MySqlCommand insert = new MySqlCommand($"insert into EventDatabase.Customer(Customername,Customeremail,Customerpassword,Customerage) values('{customer.CustomerName =name}','{customer.CustomerEmail = email}','{customer.Password = password}','{customer.Age = age}');", connection);
            var execute = insert.ExecuteNonQuery();

            if (execute <= 5 )
            {
                Console.WriteLine("user registered Successfully.");
            }
            else
            {
                Console.WriteLine("Unable To register user");
            }
        }
    }
public static Customer Login()
{
    Console.WriteLine("Email");
    string email = Console.ReadLine();
    Console.WriteLine("Password");
    string password = Console.ReadLine();
    using (MySqlConnection connection = new MySqlConnection(ConnectionString))
    {
        connection.Open();
        string query = $"select Customeremail , Customerpassword from EventDatabase.Customer where Customeremail = {email} and Customerpassword = {password};";
        using(MySqlCommand command = new MySqlCommand(query, connection))
        {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.CustomerEmail = reader.GetString(1);
                        customer.Password = reader.GetString(2);
                        return customer;
                    }
                }

            }
            return null;
    }
}
}