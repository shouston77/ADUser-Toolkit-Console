/* This class take a valid userName and domainName and makes a connection to
 * Active Directory
 * Once the connection is made the path to all the usernames current group
 * memberships in Active Directrory are saved to a txt file
 */

using System;
using System.Collections;
using System.Collections.Specialized;
using System.DirectoryServices;
using System.IO;
using System.Linq;

namespace ADUser_Toolkit_Console.Workers
{
    public class SaveGroupMemberships
    {
        public SaveGroupMemberships(DirectorySearcher search, string filePath)
        {
            StringCollection groups = new StringCollection();

            SearchResult result = search.FindOne();

            if (null != result)
            {
                DirectoryEntry obUser = new DirectoryEntry(result.Path);
                object obGroups = obUser.Invoke("Groups");
                foreach (object ob in (IEnumerable)obGroups)
                {
                    DirectoryEntry obGpEntry = new DirectoryEntry(ob);
                    groups.Add(obGpEntry.Path);
                }
            }
            File.WriteAllLines(filePath, groups.Cast<string>());
            Console.WriteLine($"Group memberhships have been saved to the following file: {filePath}.");
        }
    }

}