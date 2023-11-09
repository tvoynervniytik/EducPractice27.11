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
    /// Логика взаимодействия для DepartmentPage.xaml
    /// </summary>
    public partial class DepartmentPage : Page
    {
        public static List<Department> departments {  get; set; }
        public static List<Faculty> facultys { get; set; }
        public DepartmentPage()
        {
            InitializeComponent();
            departments = new List<Department>(DBConnection.educPractice.Department.ToList());
            facultys = new List<Faculty>(DBConnection.educPractice.Faculty.ToList());
           
            HeadTb.Text = loginUser.user.Surname;
            this.DataContext = this;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void disciplineSlv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (disciplineSlv.SelectedItem is Department department)
            {
                disciplineSlv.SelectedItem = null;
                NavigationService.Navigate(new DepDisciplinePage(department));
                loginUser.dep = department;
            }
        }
    }
}
