using System;
using System.Numerics;

public class Validation {
    public static void Validate() {
        Console.Clear();
        Console.WriteLine("\n\nAdd Records");

        DateTime dt = DateTime.Now.Date;
        string todaysDate = string.Format("{0:dd-MM-yyyy}", dt);

        Console.WriteLine("\n\nTodays date is {0}",todaysDate);

        Console.WriteLine("\n\nWhat time did you start coding? (Hours:Minutes)");

        string inputTimeStart = Console.ReadLine();

        Console.WriteLine("\n\nWhat time did you finish? (Hours:Minutes)");

        string inputTimeFinish = Console.ReadLine();
    
        TimeSpan duration = DateTime.Parse(inputTimeFinish).Subtract(DateTime.Parse(inputTimeStart));

        Console.WriteLine("\n\nOn {0} You did {1} hours of coding.", todaysDate, duration);
        Console.WriteLine("Press 1 to save progress");
        Console.WriteLine("Press 2 to go to main menu");

        string userSelection = Console.ReadLine();

        switch(userSelection) {
            case "1":
            Console.Clear();
            AccessDB.NewRecord(todaysDate, duration);
            break;
            case "2":
            Console.Clear();
            break;
            default:
            Console.WriteLine("select a number between 1 & 2");
            break;
        }
    }
}