using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADUser_Toolkit_Console.Workers
{
    class GetUserGroupInfo
    {
        public List<string> GetAdGroupsForUser(string userName, string domainName = null)
        {
            var result = new List<string>();

            if (userName.Contains('\\') || userName.Contains('/'))
            {
                domainName = userName.Split(new char[] { '\\', '/' })[0];
                userName = userName.Split(new char[] { '\\', '/' })[1];
            }

            using (PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, domainName))
            using (UserPrincipal user = UserPrincipal.FindByIdentity(domainContext, userName))
            using (var searcher = new DirectorySearcher(new DirectoryEntry(domainName)))
            {
                searcher.Filter = String.Format("(&(objectCategory=group)(member={0}))", user.DistinguishedName);
                searcher.SearchScope = SearchScope.Subtree;
                searcher.PropertiesToLoad.Add("cn");

                foreach (SearchResult entry in searcher.FindAll())
                    if (entry.Properties.Contains("cn"))
                        result.Add(entry.Properties["cn"][0].ToString());
            }

            return result;
        }
    }
}
