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
    /// Логика взаимодействия для ExamsPage.xaml
    /// </summary>
    public partial class ExamsPage : Page
    {
        public static List<Exam> exams {  get; set; }
        public static List<Employee> employees {  get; set; }
        public static List<Discipline> disciplines { get; set; }
        public static List<Student> students { get; set; }
        public ExamsPage()
        {
            InitializeComponent();
            TeacherTb.Text = loginUser.user.Surname;
            exams = new List<Exam>(DBConnection.educPractice.Exam.ToList());
            employees = new List<Employee>(DBConnection.educPractice.Employee.ToList());
            disciplines = new List<Discipline>(DBConnection.educPractice.Discipline.ToList());

            this.DataContext = this;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void disciplineSlv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (examsSlv.SelectedItem is Exam exam)
            {
                examsSlv.SelectedItem = null;
                NavigationService.Navigate(new ExamStudentsPage(exam));
                loginUser.exam1 = exam;
            }
            
        }
    }
}
