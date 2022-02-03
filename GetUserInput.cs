using System;
public class GetUserInput {
    public static void UserInput()
    {
        Console.Clear();
        bool closeApp = false;
        while (closeApp == false) {
            Console.WriteLine("\n\nMAIN MENU");
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("\nType 0 to close the Application");
            Console.WriteLine("Type 1 to View Duration Records");
            Console.WriteLine("Type 2 to Add Record");
            Console.WriteLine("--------------------\n");

            string commandInput = Console.ReadLine();

            switch(commandInput) {
                case "0":
                    Console.WriteLine("\nGoodbye!\n");
                    closeApp = true;
                    break;
                case "1":
                    AccessDB.ViewRecords();
                    break;
                case "2":
                    Validation.Validate();
                    break;
                default:
                    Console.WriteLine("\nInvalid Command. Please type a number from 0 to 2.\n");
                    break;
            }
        }
    }
}