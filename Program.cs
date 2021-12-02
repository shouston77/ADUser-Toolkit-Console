using ADUser_Toolkit_Console.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADUser_Toolkit_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectToActiveDirectory connectToActiveDirectory = new ConnectToActiveDirectory();
            connectToActiveDirectory.GetCurrentDomainPath();

            var ldap = connectToActiveDirectory.GetCurrentDomainPath();
            Console.WriteLine(ldap);
        }
    }
}
