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

    }
}
