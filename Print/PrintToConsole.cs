/* This class is used to print out console messages to the user
 * and take input from the user to direct the flow of the program
 */

using ADUser_Toolkit_Console.Interface;
using System;

namespace ADUser_Toolkit_Console.Print
{
    class PrintToConsole : GetUserInput
    {
        public string GetInput()
        {
            string userInput = Console.ReadLine();
            userInput = userInput.Trim();
            userInput = userInput.ToLower();

            return userInput;
        }
        public string PrintSaveGroupMembershipInfo()
        {
            Console.WriteLine("\nWould you like to save the user's group memberships? Enter y or Y for yes: ");
            string saveGroups = GetInput();
            if (saveGroups == "")
            {
                saveGroups = "y";
            }

            return saveGroups;
        }

        public string FilePathToSaveGroups(string userName)
        {
            Console.Write("Please enter the full file path to save the file: ");
            string filePath = GetInput();
            if (filePath == "")
            {
                filePath = ($"{userName}.txt");
            }

            return filePath;
        }

        public string PrintModifyGroupMembershipInfo()
        {
            Console.WriteLine("\nWould you like to modify the users group memberships? Enter y or Y for yes: ");
            string modifyGroups = GetInput();
            if (modifyGroups == "")
            {
                modifyGroups = "y";
            }

            return modifyGroups;
        }

        public string FilePathToModifyGroupMembership()
        {
            Console.Write("Please enter the file name to read the group memberships from: ");
            string filePath = GetInput();
            if (filePath == "")
            {
                filePath = "default.txt";
            }

            return filePath;
        }

        public object UserNotFoundMessage(string userName)
        {

            Console.WriteLine($"Username   {userName}   was not found! \nPress any key to exit the program.");
            return Console.ReadKey();
        }

        public object EndProgram()
        {
            Console.WriteLine("\nPress any key to exit the program.");
            return Console.ReadKey();
        }
    }
}
