/* This is used to retrieve the username to check against the Active Directory
 * with input from the user
 */

using ADUser_Toolkit_Console.Interface;
using ADUser_Toolkit_Console.Print;
using System;

namespace ADUser_Toolkit_Console.Workers
{
    public class GetUserNameToManage : GetUserInput
    {
        public string GetInput()
        {

            Console.Write("Please enter the username to find: ");
            string userName = Console.ReadLine().Trim();

            if (userName == "")
            {
                Console.WriteLine("You did not enter a username to find would you like to try again? Enter y or Y for yes: ");
                string response = Console.ReadLine().Trim().ToLower();
                if (response == "y")
                {
                    Console.Write("Please enter the username to find: ");
                    userName = Console.ReadLine().Trim().ToLower();
                }
                else
                {
                    PrintToConsole printToConsole = new PrintToConsole();
                    printToConsole.UserNotFoundMessage(userName);
                    System.Environment.Exit(1);
                }
            }

            return userName;
        }
    }
}
