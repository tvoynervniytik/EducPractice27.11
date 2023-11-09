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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static Employee currentUser;
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTb.Text.Trim();
            string password = passwordTb.Password.Trim();

            currentUser = AuthorizationFunc.AuthorizationEmpl(login, password);
            loginUser.user = currentUser;
            if (currentUser != null)
            {
                MessageBox.Show(currentUser.Post);
                if (currentUser.Post == "преподаватель")
                {
                    NavigationService.Navigate(new ExamsPage());
                }
                if (currentUser.Post == "зав. кафедрой")
                {
                    NavigationService.Navigate(new DepartmentPage());
                }
                if (currentUser.Post == "инженер")
                {
                    NavigationService.Navigate(new EmployeePage());
                }
            }
                    
            else
                MessageBox.Show("All's wrong");
        }

        private void guestBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DisciplinePage());
        }
    }
}
