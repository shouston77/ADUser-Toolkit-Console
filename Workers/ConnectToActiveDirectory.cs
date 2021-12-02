/*This class will create an object that connects to the local Active Directory
 * that the computer is a member of
 * The method contained in this class is used to connect to Active Directory 
 * and return a valid domain path
 */
using System.DirectoryServices;

namespace ADUser_Toolkit_Console.Workers
{
    public class ConnectToActiveDirectory
    {
        public string GetCurrentDomainPath()
        {

            DirectoryEntry de = new DirectoryEntry("LDAP://RootDSE");

            return $"LDAP://" + de.Properties["defaultNamingContext"][0].ToString();

        }

    }
}
