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
    }
}
