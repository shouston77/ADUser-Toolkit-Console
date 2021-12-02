/*This class will take the valid userName and domainName and
 * search for all the group memberships the username is a 
 * member of in Active Directory
 */

using System;
using System.Collections;
using System.Collections.Specialized;
using System.DirectoryServices;

namespace ADUser_Toolkit_Console.Workers
{
    public class GetUserGroupMembership
    {
        public StringCollection GetUserGroupMemberships(string userName, string domainName, DirectorySearcher search)
        {
            StringCollection groups = new StringCollection();

            SearchResult result = search.FindOne();

            if (result != null)
            {
                DirectoryEntry objectUser = new DirectoryEntry(result.Path);
                object objectGroups = objectUser.Invoke("Groups");
                foreach (object obj in (IEnumerable)objectGroups)
                {
                    DirectoryEntry objectGroupEntry = new DirectoryEntry(obj);
                    groups.Add(objectGroupEntry.Name);
                    Console.WriteLine($"Group Membership  : {objectGroupEntry.Name}");
                }
            }
            return groups;
        }
    }
}
