/* This class is used to modify a users group memberships in Active Directory
 * It takes a valid username and domainName and then connects to Active
 * Directory
 * After connecting to Active Directory it takes the valid file path of
 * a file that contains Active Directory groups to add to the users 
 * current group memberships 
 */

using System;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

namespace ADUser_Toolkit_Console.Workers
{
    public class ModifyGroupMemberships
    {
        public ModifyGroupMemberships(string distinguishedName, string filePath)
        {
            var myDomain = Domain.GetComputerDomain();
            string bindString = myDomain.ToString();
            bindString = "LDAP://" + bindString;

            string[] groupMemberships = System.IO.File.ReadAllLines(filePath);

            foreach (string group in groupMemberships)
            {
                DirectoryEntry dirEntry = new DirectoryEntry(bindString + group.Substring(6));
                dirEntry.Properties["member"].Add(distinguishedName);
                dirEntry.CommitChanges();

                Console.WriteLine("...new group saved: " + group);
            }
        }
    }
}

