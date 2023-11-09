using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using up2711.DB;

namespace up2711.Functions
{
    internal class AuthorizationFunc
    {
        public static ObservableCollection<Employee> employees { get; set; }
        public static Employee AuthorizationEmpl(string login, string password)
        {
            employees = new ObservableCollection<Employee>(DBConnection.educPractice.Employee.ToList());
            var userExists = employees.Where(i => i.Login == login && i.Password == password).FirstOrDefault();

            if (userExists != null)
            {
                return userExists;
            }
            else
            {
                return userExists;
            }
        }
    }
}
