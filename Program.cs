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
        public static void GetFlightDetails()
        {
            Console.Write("Enter flight code: "); string flightCode = Console.ReadLine();
            Console.Write("Enter from city: "); string fromCity = Console.ReadLine();
            Console.Write("Enter to city: "); string toCity = Console.ReadLine();
            Console.Write("Enter duration (hours): "); int duration = int.Parse(Console.ReadLine());
            Console.Write("Enter price: "); double price = double.Parse(Console.ReadLine());
            AddFlight(flightCode, fromCity, toCity, duration, price);
        }
        // Display all flights
        public static void DisplayFlights()
        {
            if (flightCodeList.Count == 0)
            {
                Console.WriteLine("No flights available.");
                return;
            }

            Console.WriteLine("\nAvailable Flights:");
            for (int i = 0; i < flightCodeList.Count; i++)
            {
                Console.WriteLine($"{flightCodeList[i]} | From: {fromCityList[i]} | To: {toCityList[i]} | Departure: {departureTimeList[i]} | Duration: {durationList[i]} hrs");
            }
        }

        // Get departure time from user
        public static DateTime GetUserDateTime()
        {
            Console.Write("Enter year: "); int year = int.Parse(Console.ReadLine());
            Console.Write("Enter month: "); int month = int.Parse(Console.ReadLine());
            Console.Write("Enter day: "); int day = int.Parse(Console.ReadLine());
            Console.Write("Enter time (hh:mm): "); var timeParts = Console.ReadLine().Split(':');
            int hour = int.Parse(timeParts[0]), minute = int.Parse(timeParts[1]);
            return new DateTime(year, month, day, hour, minute, 0);
        }
        // Add a new flight to the system
        public static void AddFlight(string flightCode, string fromCity, string toCity, int duration, double price)
        {
            if (flightCodeList.Contains(flightCode))
            {
                Console.WriteLine("Flight code already exists.");
                return;
            }
            flightCodeList.Add(flightCode);
            fromCityList.Add(fromCity);
            toCityList.Add(toCity);
            departureTimeList.Add(GetUserDateTime());
            durationList.Add(duration);
            ticketsPriceList.Add(price);

            Console.WriteLine("Flight added successfully!");
        }

        // Book a flight
        public static void BookFlight(string passengerName)
        {
            Console.Write("Enter flight code: "); string flightCode = Console.ReadLine();
            int index = flightCodeList.IndexOf(flightCode);
            if (index == -1) { Console.WriteLine("Flight not found."); return; }

            Console.Write("Enter your name: "); passengerName = Console.ReadLine();
            string id = GenerateBookingID(passengerName);
            bookingIDList.Add(id);
            bookedFlightsList.Add(passengerName);
            availableFlightsList.Add(flightCode);

            Console.WriteLine("Do you have a discount code? (Y/N)");
            string response = Console.ReadLine();
            double fare = ticketsPriceList[index];

            if (response.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter discount code: ");
                string code = Console.ReadLine();
                if (code == "discount30") fare = CalculateFare(fare, 1, 30);
            }
            else
            {
                fare = CalculateFare(fare, 1);
            }

            Console.WriteLine($"Booking ID: {id}\nFlight {flightCode} booked successfully for {passengerName}. Fare: {fare:C}");
        }

        // Cancel a booked flight
        public static string CancelFlightBooking(out string passengerName)
        {
            Console.Write("Enter flight code: "); string code = Console.ReadLine();
            int index = flightCodeList.IndexOf(code);
            if (index == -1)
            {
                passengerName = null;
                Console.WriteLine("Flight not found.");
                return null;
            }

            Console.Write("Enter your name: "); passengerName = Console.ReadLine();
            Console.WriteLine($"Booking for {passengerName} on flight {code} canceled.");
            return passengerName;
        }

        // Generate booking ID from name
        public static string GenerateBookingID(string name)
        {
            Random r = new Random();
            return name.Substring(0, 3).ToUpper() + "-" + r.Next(1000, 9999);
        }

        // Calculate fare with discount
        public static double CalculateFare(double basePrice, int tickets, int discount)
        {
            double total = basePrice * tickets;
            return total - (total * discount / 100);
        }

        // Calculate fare without discount
        public static double CalculateFare(double basePrice, int tickets) => basePrice * tickets;

        // Display details of one flight
        public static void DisplayFlightDetails(string code)
        {
            int index = flightCodeList.IndexOf(code);
            if (index == -1)
            {
                Console.WriteLine("Flight not found.");
                return;
            }
            Console.WriteLine($"Flight Code: {flightCodeList[index]}\nFrom: {fromCityList[index]}\nTo: {toCityList[index]}\nDeparture: {departureTimeList[index]}\nDuration: {durationList[index]} hrs");
        }

        // Search for flights going to a destination
        public static void SearchBookingsByDestination(string toCity)
        {
            bool found = false;
            for (int i = 0; i < toCityList.Count; i++)
            {
                if (toCityList[i].Equals(toCity, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Flight Code: {flightCodeList[i]} | From: {fromCityList[i]} | Departure: {departureTimeList[i]} | Duration: {durationList[i]} hrs");
                    found = true;
                }
            }
            if (!found) Console.WriteLine("No flights found to that destination.");
        }

        // Update a flight's departure time
        public static void UpdateFlightDeparture(string code, DateTime newTime)
        {
            int index = flightCodeList.IndexOf(code);
            if (index != -1)
            {
                departureTimeList[index] = newTime;
                Console.WriteLine("Departure time updated.");
            }
            else Console.WriteLine("Flight not found.");
        }

        // Check if flight code exists
        public static bool ValidateFlightCode(string flightCode)
        {
            return flightCodeList.Contains(flightCode);
        }
        // Start the system
        public static void StartSystem()
        {
            DisplayWelcomeMessage();
            while (true)
            {
                int choice = ShowMenu();
                switch (choice)
                {
                    case 1: BookFlight("Default"); break;
                    case 2: CancelFlightBooking(out _); break;
                    case 3: DisplayFlights(); break;
                    case 4: GetFlightDetails(); break;
                    case 5:
                        Console.Write("Enter destination city: ");
                        SearchBookingsByDestination(Console.ReadLine());
                        break;
                    case 6:
                        Console.Write("Enter flight code: ");
                        DisplayFlightDetails(Console.ReadLine());
                        break;
                    case 7:
                        Console.Write("Enter flight code: ");
                        string code = Console.ReadLine();
                        Console.WriteLine("Enter new departure time:");
                        DateTime newTime = GetUserDateTime();
                        UpdateFlightDeparture(code, newTime);
                        break;
                    case 9: Exit(); break;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }


    }

}
