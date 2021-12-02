/* This class is used to print to the console the information
 * built from the User class
 * After printing the attributes for the given user account
 * the class will then create objects to the GetUserGroupMemberhips
 * class and print the given usernames found group memberhips
 * The class will then create an object to the SaveGroupMemberships
 * class and then the ModifyGroupMemberships class
 */

using ADUser_Toolkit_Console.Users;
using System;

namespace ADUser_Toolkit_Console.Print
{
    public class PrintUser
    {
        public void PrintUserInfo(string userName, string domainName)
        {
            User user = new User(userName, domainName);

            Console.WriteLine($"\nFirst Name        : {user.GetUserFirstName()} ");
            Console.WriteLine($"Middle Name       : {user.GetUserMiddleName()}");
            Console.WriteLine($"Last Name         : {user.GetUserLastName()}");
            Console.WriteLine($"Company           : {user.GetUserCompany()}");
            Console.WriteLine($"Department        : {user.GetUserDepartment()}");
            Console.WriteLine($"Title             : {user.GetUserTitle()}");
            Console.WriteLine($"Telephone Number  : {user.GetUserTelephoneNumber()}");
            Console.WriteLine($"Email             : {user.GetUserEmailAddress()}");
            Console.WriteLine();
        }
    }
}
