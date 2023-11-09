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

namespace up2711.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditDiscDepPage.xaml
    /// </summary>
    public partial class EditDiscDepPage : Page
    {
        public static List<Discipline> disciplineCb {  get; set; }
        public static Discipline dis {  get; set; }
        public EditDiscDepPage(Discipline discipline)
        {
            InitializeComponent();
            disciplineCb = new List<Discipline>(DBConnection.educPractice.Discipline.ToList());
            dis = discipline;
            ishNameTb.Text = Convert.ToString(discipline.Name) ;
            //ishVolumeTb
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
