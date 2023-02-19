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

namespace Ezhednevnik
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string date;
        List <Zametka> zametki = new List<Zametka>();
        List<Zametka> today_zametki = new List<Zametka>();
        int current_zam;
        public MainWindow()
        {
            InitializeComponent();
            zametki = Work_with_file.My_Deserialize<List<Zametka>>("Zametki.json");
        }
        private void Show_zam()
        {
            today_zametki.Clear();
            foreach (Zametka i in zametki)
            {
                if (i.date == date)
                {
                    today_zametki.Add(i);
                    Zam_list.Items.Add(i.name);
                }
            }
        }

        private void Adding_Click(object sender, RoutedEventArgs e)
        {
            Zametka new_zam = new Zametka(Name_zam.Text, Description.Text, Date_pic.Text);
            zametki.Add(new_zam);
            Work_with_file.My_Serialize(zametki, "Zametki.json");
            Zam_list.Items.Add(new_zam.name);
            today_zametki.Add(new_zam);
            Name_zam.Text = "";
            Description.Text = "";
        }

        private void Editing_Click(object sender, RoutedEventArgs e) 
        {
            Zametka z_for_edit = today_zametki[current_zam];
            foreach(Zametka i in zametki)
            {
                if(i.name == z_for_edit.name & i.description == z_for_edit.description & i.date == z_for_edit.date)
                {
                    i.name = Name_zam.Text;
                    i.description = Description.Text;
                    today_zametki[current_zam].name = Name_zam.Text;
                    today_zametki[current_zam].description = Description.Text;
                }
            }
            Work_with_file.My_Serialize(zametki, "Zametki.json");
            Name_zam.Text = "";
            Description.Text = "";
            foreach (Zametka i in today_zametki)
            {
                Zam_list.Items.Remove(i.name);
            }
            Show_zam();
        }

        private void Deleting_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Zam_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            current_zam = Zam_list.SelectedIndex;
            if(current_zam != -1)
            {
                Name_zam.Text = today_zametki[current_zam].name;
                Description.Text = today_zametki[current_zam].description;
            }
            
        }

        private void Date_pic_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Work_with_file.My_Serialize(zametki, "Zametki.json");
            date = Date_pic.Text;
            Name_zam.Text = "";
            Description.Text = "";
            foreach (Zametka i in today_zametki)
            {
                Zam_list.Items.Remove(i.name);
            }
            Show_zam();
        }
    }
}
