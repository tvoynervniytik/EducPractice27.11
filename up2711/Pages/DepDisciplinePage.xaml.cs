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
    /// Логика взаимодействия для DepDisciplinePage.xaml
    /// </summary>
    public partial class DepDisciplinePage : Page
    {
        public static List<Discipline> disciplines {  get; set; }
        public static List<Discipline> disciplineCb {  get; set; }
        public static List<Department> departments {  get; set; }
        public DepDisciplinePage(Department department)
        {
            InitializeComponent();
            disciplines = new List<Discipline>(DBConnection.educPractice.Discipline.Where(i => i.Id_Department == department.Id).ToList());
            disciplineCb = new List<Discipline>(DBConnection.educPractice.Discipline.ToList());
            departments = new List<Department>(DBConnection.educPractice.Department.ToList());

            DepartmentNameTb.Text = department.Name;
            this.DataContext = this;
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DiscSlv.SelectedItem is Discipline discipline)
            {
                DiscSlv.SelectedItem = null;
                NavigationService.Navigate(new EditDiscDepPage(discipline));
            }
            
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Discipline discipline = new Discipline();

            var discName = discCb.SelectedItem as Discipline;
            discipline.Name = discName.Name;
            discipline.Volume = int.Parse(volumeTb.Text);
            discipline.Id_Department = loginUser.dep.Id;

            DBConnection.educPractice.Discipline.Add(discipline);
            DBConnection.educPractice.SaveChanges();
            
            DiscSlv.ItemsSource = new List<Discipline>(DBConnection.educPractice.Discipline.Where(i => i.Id_Department == loginUser.dep.Id).ToList());
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var del = DiscSlv.SelectedItem as Discipline;
            var delL = DBConnection.educPractice.Discipline.Where(i=> del.Id == i.Id).ToList().FirstOrDefault();

            if (delL != null)
            {
                MessageBox.Show("yes" + delL.Name);

                DBConnection.educPractice.Discipline.Remove(delL);
                DBConnection.educPractice.SaveChanges();

                DiscSlv.ItemsSource = new List<Discipline>(DBConnection.educPractice.Discipline.Where(i=> i.Id_Department == loginUser.dep.Id).ToList());
            }
            else MessageBox.Show("no");
        }
    }
}
