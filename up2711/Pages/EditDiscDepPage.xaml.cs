using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Логика взаимодействия для EditDiscDepPage.xaml
    /// </summary>
    public partial class EditDiscDepPage : Page
    {
        public static List<Discipline> disciplineCb {  get; set; }
        public static Discipline dis {  get; set; }
        Discipline contextDis;
        public EditDiscDepPage(Discipline discipline)
        {
            InitializeComponent();
            dis = discipline;
            disciplineCb = new List<Discipline>(DBConnection.educPractice.Discipline.ToList());
            contextDis = discipline;
            loginUser.dis = discipline;
            ishNameTb.Text = Convert.ToString(discipline.Name) ;
            discVolumeTb.Text = Convert.ToString(discipline.Volume) ;
            
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var error = string.Empty;
            var val = new ValidationContext(contextDis);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            if (Validator.TryValidateObject(contextDis, val, results, true))
            {
                foreach (var result in results)
                {
                    error += $"{result.ErrorMessage}\n";
                }
            }
            if (!string.IsNullOrWhiteSpace(error)) 
            {
                MessageBox.Show(error);
                return;
            }
            if (contextDis.Id == 0)
                DBConnection.educPractice.Discipline.Add(contextDis);
                DBConnection.educPractice.SaveChanges();
            NavigationService.GoBack();
        }
    }
}
