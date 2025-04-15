namespace airLineByLists
{
    internal class Program
    {
        // Lists to store flight and booking details
        static List<string> flightCodeList = new List<string>();
        static List<string> fromCityList = new List<string>();
        static List<string> toCityList = new List<string>();
        static List<DateTime> departureTimeList = new List<DateTime>();
        static List<int> durationList = new List<int>();
        static List<string> availableFlightsList = new List<string>();
        static List<string> bookedFlightsList = new List<string>();
        static List<string> passengerNameList = new List<string>();
        static List<double> ticketsPriceList = new List<double>();
        static List<string> bookingIDList = new List<string>();

        static void Main(string[] args)
        {
            try { StartSystem(); }
            catch (Exception ex) { Console.WriteLine($"An error occurred: {ex.Message}"); }
        }
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|Welcome to the Airline Reservation System!|");
            Console.WriteLine("--------------------------------------------");
        }
        public static int ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("If you are a user press 1, if admin press 2:");
                if (!int.TryParse(Console.ReadLine(), out int userType)) continue;

                if (userType == 1)
                {
                    Console.WriteLine("1. Book Flight\n2. Cancel Flight\n3. View Flights\n5. Search Flights\n6. View Flight Details\n9. Exit");
                }
                else if (userType == 2)
                {
                    Console.WriteLine("1. Book Flight\n2. Cancel Flight\n3. View Flights\n4. Add Flight\n5. Search Flights\n6. View Flight Details\n7. Update Departure\n9. Exit");
                }
                else
                {
                    Console.WriteLine("Invalid user type.");
                    continue;
                }

                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice)) return choice;
            }


        }// Exit the system
        public static void Exit()
        {
            Console.WriteLine("Thank you for using the Airline Reservation System. Goodbye!");
            Environment.Exit(0);
        }


    }
}
