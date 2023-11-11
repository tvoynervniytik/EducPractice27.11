using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using up2711.DB;
using up2711.Functions;

namespace up2711.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public static List<Employee> employees {  get; set; }
        public static List<Department> departments { get; set; }
        public static List<HeadofDepartment> heads {  get; set; }
        public EmployeePage()
        {
            InitializeComponent();
            employees = new List<Employee>(DBConnection.educPractice.Employee.ToList());
            departments = new List<Department>(DBConnection.educPractice.Department.ToList());
            
            EngineerTb.Text = loginUser.user.Surname;
            this.DataContext = this;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
           
            
            int depart = 0;
            var dep = depCb.SelectedIndex;
            if (dep != null)
            { 
                if (dep == 0)
                {
                    depart = 1;
                }
                if (dep == 1)
                {
                    depart = 2;
                }
                if (dep == 2)
                {
                    depart = 3;
                }
                if (dep == 3)
                {
                    depart = 4;
                }
                if (dep == 4)
                {
                    depart = 5;
                }
                if (dep == 5)
                {
                    depart = 6;
                }
            }
            MessageBox.Show(depart.ToString());
            Employee empl = new Employee();
            empl.Id_Department = depart; 
            empl.Surname = FIOTb.Text.Trim();            
            empl.Post = PostCb.Text.Trim();
            empl.Salary = int.Parse(salaryTb.Text);

            DBConnection.educPractice.Employee.Add(empl);
            DBConnection.educPractice.SaveChanges();

            employeeSlv.ItemsSource = new List<Employee>(DBConnection.educPractice.Employee.ToList());
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var del = employeeSlv.SelectedItem as Employee;
            var delL = DBConnection.educPractice.Employee.
                Where(x => x.Id == del.Id).ToList().FirstOrDefault();
            if (delL != null)
            {
                MessageBox.Show("yes, " + delL.Surname);

                DBConnection.educPractice.Employee.Remove(delL);
                DBConnection.educPractice.SaveChanges();

                employeeSlv.ItemsSource = new List<Employee>(DBConnection.educPractice.Employee.ToList());
            }
            else MessageBox.Show("no");
        }
    }
}
