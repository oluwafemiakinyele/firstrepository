using MySql.Data.MySqlClient;

public class Ticket
{
    private static string ConnectionString = "Server = localhost; User = root; database = EventDatabase; password = Philemon";

    public int Ticketid {get; set;}
    public double Ticketprice {get; set;}
    public int Customerid {get; set;}
    public int Eventid {get; set;}

    public static void Booktickets()
    {
        Console.WriteLine("Which Event are you booking for");
        string event1 = Console.ReadLine();
        Console.WriteLine("How many tickets");
        int bookedTickets = int.Parse(Console.ReadLine());
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
              connection.Open();
            string query = $"SELECT Eventid,EventName,EventDate,Availabletickets, From EventDatabase.Event where Eventname ={event1}";
        using (MySqlConnection connection1 = new MySqlConnection(ConnectionString))
        {
             using(MySqlCommand command1 = new MySqlCommand(query, connection1))
        {
            using(MySqlDataReader reader = command1.ExecuteReader())
            {
                if(reader.Read())
                    {
                        Event event12 = new Event();
                        event12.Eventname = reader. GetString(1);
                        event12.AvailableTickets = reader.GetInt32(3);
                    }
            }
        }
        }
            string query1 = "UPDATE StudentDataBase.staff SET name = 'Goodness' where id = 1";

            MySqlCommand command = new MySqlCommand(query1, connection);
            var execute = command.ExecuteNonQuery();

            if (execute > 0)
            {
                Console.WriteLine("Updated Successfully.");
            }
            else
            {
                Console.WriteLine("Unable To Update.");
            }
        }
    }
} 