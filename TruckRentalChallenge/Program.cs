using TruckRentalChallenge;

class Program
{
    static void Main(string[] args)
    {
        // Create a new Truck instance with weekday rate of $400, weekend rate of $200, and first twenty minutes rate of $5
        Truck truck = new Truck(50, 400, 200, 5);

        // Calculate the rental price for a truck that gets rented at 3pm on Tuesday and is returned at 2pm on Friday
        truck.StartTime = new DateTime(2023, 7, 25, 15, 0, 0); // 3pm on Tuesday
        truck.EndTime = new DateTime(2023, 7, 28, 14, 0, 0); // 2pm on Friday
        Console.WriteLine($"Scenario 1 rental price: ${truck.CalculatePrice()}");

        // Calculate a rental price for a truck that gets rented at 8 am on a monday and is returned at 4pm on Friday
        truck.StartTime = new DateTime(2023, 7, 24, 8, 0, 0); // 8am on Monday
        truck.EndTime = new DateTime(2023, 7, 28, 16, 0, 0); // 4pm on Friday
        Console.WriteLine($"Scenario 2 rental price: ${truck.CalculatePrice()}");

        // Calculate the rental prrice for a truck that gets rented at 11 am on Saturday and returned at 6pm on a tuesday.
        truck.StartTime = new DateTime(2023, 7, 29, 11, 0, 0); // 11am on Saturday
        truck.EndTime = new DateTime(2023, 8, 1, 18, 0, 0); // 6pm on Tuesday
        Console.WriteLine($"Scenario 3 rental price: ${truck.CalculatePrice()}");

        // Calculate the rental price of a truck that is rented at 4pm on Friday and is returned at 8 am on monday
        truck.StartTime = new DateTime(2023, 7, 28, 16, 0, 0); // 4pm on Friday
        truck.EndTime = new DateTime(2023, 7, 31, 8, 0, 0); // 8am on Monday
        Console.WriteLine($"Scenario 4 rental price: ${truck.CalculatePrice()}");

        // Calculate the rental price of a truck that is rented and returned in 3 hours on a weekday
        truck.StartTime = new DateTime(2023, 7, 25, 9, 0, 0);
        truck.EndTime = new DateTime(2023, 7, 25, 12, 0, 0); 
        Console.WriteLine($"Scenario 5 rental price: ${truck.CalculatePrice()}");

        Console.ReadLine();
    }
}