/* This class is user to build the user information found
 * in Active Directory for the given username that is
 * entered into the program
 * It stores user account attributes and is used to get
 * and set those found attributes
 * If the attribute is not found the class will store
 * it as an empty string
 */

using ADUser_Toolkit_Console.Workers;
using System.DirectoryServices;

namespace ADUser_Toolkit_Console.Users
{
    public class User
    {
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _company;
        private string _department;
        private string _title;
        private string _telephoneNumber;
        private string _emailAddress;
        private string _distinguishedName;

        private string _userName;
        private string _domainName;
        DirectorySearcher _search;

        FindUserInActiveDirectory findUserInActiveDirectory = new FindUserInActiveDirectory();

        public User(string userName, string domainName)
        {
            SetUserName(userName);
            SetDomainPath(domainName);
            SetSearchResult();
            SetUserFisrtName();
            SetUserMiddleName();
            SetUserLastName();
            SetUserCompany();
            SetUserDepartment();
            SetUserTitle();
            SetUserTelephoneNumber();
            SetUserEmailAddress();
            SetUserDistinguishedName();
        }

        public void SetUserName(string userName)
        {
            _userName = userName;
        }

        public void SetDomainPath(string domainName)
        {
            _domainName = domainName;
        }

        static public DirectorySearcher GetSearchResult(string userName, string domainName)
        {
            DirectoryEntry objectEntry = new DirectoryEntry(domainName);
            DirectorySearcher search = new DirectorySearcher(objectEntry, "(sAMAccountName=" + userName + ")");

            return search;
        }

        public void SetSearchResult()
        {
            _search = GetSearchResult(_userName, _domainName);
        }

        static public string GetUserDistinguishedName(string userName, string domainName)
        {
            string attribute = "distinguishedName";

            FindUserInActiveDirectory findUserInActiveDirectory = new FindUserInActiveDirectory();

            DirectoryEntry objectEntry = new DirectoryEntry(domainName);
            DirectorySearcher search = new DirectorySearcher(objectEntry, "(sAMAccountName=" + userName + ")");

            string distinguishedName = findUserInActiveDirectory.FindUser(userName, attribute, search);

            return distinguishedName;
        }

        public void SetUserDistinguishedName()
        {
            string attribute = "distinguishedName";
            _distinguishedName = findUserInActiveDirectory.FindUser(_userName, attribute, _search);
        }

        public string GetUserFirstName()
        {
            return _firstName;
        }

        public void SetUserFisrtName()
        {
            string attribute = "givenName";
            _firstName = findUserInActiveDirectory.FindUser(_userName, attribute, _search);
        }

        public string GetUserMiddleName()
        {
            return _middleName;
        }

        public void SetUserMiddleName()
        {
            string attribute = "initials";
            _middleName = findUserInActiveDirectory.FindUser(_userName, attribute, _search);
        }

        public string GetUserLastName()
        {
            return _lastName;
        }

        public void SetUserLastName()
        {
            string attribute = "sn";
            _lastName = findUserInActiveDirectory.FindUser(_userName, attribute, _search);
        }

        public string GetUserCompany()
        {
            return _company;
        }

        public void SetUserCompany()
        {
            string attribute = "company";
            _company = findUserInActiveDirectory.FindUser(_userName, attribute, _search);
        }

        public string GetUserDepartment()
        {
            return _department;
        }

        public void SetUserDepartment()
        {
            string attribute = "department";
            _department = findUserInActiveDirectory.FindUser(_userName, attribute, _search);
        }

        public string GetUserTitle()
        {
            return _title;
        }

        public void SetUserTitle()
        {
            string attribute = "title";
            _title = findUserInActiveDirectory.FindUser(_userName, attribute, _search);
        }

        public string GetUserTelephoneNumber()
        {
            return _telephoneNumber;
        }

        public void SetUserTelephoneNumber()
        {
            string attribute = "telephoneNumber";
            _telephoneNumber = findUserInActiveDirectory.FindUser(_userName, attribute, _search);
        }

        public string GetUserEmailAddress()
        {
            return _emailAddress;
        }

        public void SetUserEmailAddress()
        {
            string attribute = "mail";
            _emailAddress = findUserInActiveDirectory.FindUser(_userName, attribute, _search);
        }
    }
}
