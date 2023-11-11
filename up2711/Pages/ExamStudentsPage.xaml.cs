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
    /// Логика взаимодействия для ExamStudentsPage.xaml
    /// </summary>
    public partial class ExamStudentsPage : Page
    {
        public static List<Discipline> disciplines { get; set; }
        public static List<Exam> exams { get; set; }
        public static List<Student> students { get; set; }
        public ExamStudentsPage(Exam exam)
        {
            InitializeComponent();
            exams = new List<Exam>(DBConnection.educPractice.Exam.Where(x=>x.Id_Discipline==exam.Id_Discipline && x.Date==exam.Date).ToList());
            disciplines = new List<Discipline>(DBConnection.educPractice.Discipline.ToList());
            students = new List<Student>(DBConnection.educPractice.Student.ToList());

            TeacherTb.Text = loginUser.user.Surname;
            DiscNameTb.Text = exam.Discipline.Name;
            DateTb.Text = exam.Date.ToString();
            this.DataContext = this;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ExamsPage());
        }
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Exam ex = new Exam();
            
            var student = studentCb.SelectedItem as Student;
            
            ex.Id_Student = student.Id;
            
            int mark = 0;
            var SelMmark = marksCb.SelectedIndex;
            if (SelMmark != null)
            { 
                if (SelMmark == 0)
                {
                    mark = 2;
                }
                if (SelMmark == 1)
                {
                    mark = 3;
                }
                if (SelMmark == 2)
                {
                    mark = 4;
                }
                if (SelMmark == 4)
                {
                    mark = 5;
                }
            }
            
            ex.Mark = Convert.ToInt32(mark);
            ex.Id_Discipline = loginUser.exam1.Id_Discipline;
            ex.Date = loginUser.exam1.Date;
            ex.Id_Employee = loginUser.exam1.Id_Employee;
            ex.Auditorium = loginUser.exam1.Auditorium;


            DBConnection.educPractice.Exam.Add(ex);
            DBConnection.educPractice.SaveChanges();

            studentSlv.ItemsSource = new List<Exam>(DBConnection.educPractice.Exam.
                Where(x => x.Id_Discipline == loginUser.exam1.Id_Discipline && x.Date == loginUser.exam1.Date).ToList());
        }
        private void delBtn_Click_1(object sender, RoutedEventArgs e)
        {
            var del = studentSlv.SelectedItem as Exam;
            var delL = DBConnection.educPractice.Exam.
                Where(x => del.Id_Discipline == x.Id_Discipline && x.Id_Discipline == loginUser.exam1.Id_Discipline 
                    && x.Date == loginUser.exam1.Date && x.Date == del.Date &&
                    x.Id_Student == del.Id_Student).ToList().FirstOrDefault();
            if (delL != null)
            { 
                MessageBox.Show("yes, " + delL.Student.Surname);

                DBConnection.educPractice.Exam.Remove(delL);
                DBConnection.educPractice.SaveChanges();
                
               
                NavigationService.Navigate(new ExamsPage());
            }
            else MessageBox.Show("no");
        }
    }

}