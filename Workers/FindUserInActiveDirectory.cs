/* This class is used to find an active user in Active Directory
 * and find specific attributes from that user account
 * If the user account is not found a message will be displayed
 * to the user and the program will terminate
*/
using ADUser_Toolkit_Console.Print;
using System.DirectoryServices;

namespace ADUser_Toolkit_Console.Workers
{
    public class FindUserInActiveDirectory
    {
        private string _foundAttribute;

        public string FindUser(string userName, string attribute, DirectorySearcher search)
        {
            string requiredProperties = attribute;
            _foundAttribute = null;

            SearchResult result = search.FindOne();

            if (result != null)
            {
                foreach (object myCollection in result.Properties[requiredProperties])
                {
                    _foundAttribute = myCollection.ToString();
                }
            }
            else
            {
                PrintToConsole printToConsole = new PrintToConsole();
                printToConsole.UserNotFoundMessage(userName);
                System.Environment.Exit(0);
            }
            return _foundAttribute;
        }
    }
}
