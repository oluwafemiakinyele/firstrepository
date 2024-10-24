using MySql.Data.MySqlClient;
public class EventManager
{
    private static string ConnectionStringWithoutDB = "Server = localhost; User = root; password = Philemon";
    private static string ConnectionString = "Server = localhost; User = root; database = EventDatabase; password = Philemon";
    Event event1 = new Event();
    public static void CreateDB()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionStringWithoutDB))
        {
            connection.Open();
            string query = "Create Database if not exists EventDataBase";

            MySqlCommand command = new MySqlCommand(query, connection);
            var execute = command.ExecuteNonQuery();

            if (execute > 0)
            {
                Console.WriteLine("Database Created Successfully.");
            }
            else
            {
                Console.WriteLine("Unable To Create Database.");
            }
        }
    }
     public static void CreateEventTable()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "create table if not exists EventDatabase.Event(EventId int primary Key not null auto_increment, EventName varchar(255) Not Null, EventDate varchar(255) Not Null, AvailableTickets int Not Null);";

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
   
    public static void CreateEvent(Event event2)
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            Console.WriteLine("Enter event name");
            string eventname = Console.ReadLine();
            Console.WriteLine("Enter event date");
            string Date = Console.ReadLine();
            Console.WriteLine("Enter the number of available tickets");
            int tickets = int.Parse(Console.ReadLine());
            connection.Open();
            MySqlCommand insert = new MySqlCommand($"insert into EventDatabase.Event(EventName,EventDate,AvailableTickets) values('{eventname}','{Date}',{tickets});", connection);
            var execute = insert.ExecuteNonQuery();
            if (execute <= 5 )
            {
                Console.WriteLine("Event created Successfully.");
            }
            else
            {
                Console.WriteLine("Unable To Create Event");
            }
      }
    }
 public static void GetEvents()
    {
        Console.WriteLine("Enter the event");
        string name =Console.ReadLine();
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();

            string selectQuery = $"SELECT Eventid,EventName,EventDate,Availabletickets, From EventDatabase.Event where Eventname = {name}";
            using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Events: ");
                    while (reader.Read())
                    {
                    Console.WriteLine($"Event id: {reader["Eventid"]}, Event name: {reader["Eventname"]},Event date: {reader["Eventdate"]}, Available tickets: {reader["Availabletickets"]}");
                    }
                }
            }
        }
    }
}    