using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Lupa_i_pupa
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = Kit.rk.Group_visit;
            Cmb1.ItemsSource = Kit.rk.Group_visit.ToList();
            Cmb2.ItemsSource = Kit.rk.Division.ToList();
            OrgTb.ItemsSource = Kit.rk.Department.ToList();
            dfg.ItemsSource = Kit.rk.Group_visit.ToList();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextTb1.Clear();
            FamTb.Clear();
            NameTb.Clear();
            OtchTb.Clear();
            PhoneTb.Clear();
            EmailTb.Clear();
            CommentTb.Clear();
            SeriyaTb.Clear();
            NumberTb.Clear();
        }
        public byte[] file;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void dobBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(FamTb.Text))
                mes += "Напишите Фамилию \n";
            if (string.IsNullOrWhiteSpace(NameTb.Text))
                mes += "Напишите имя\n";
            if (string.IsNullOrWhiteSpace(OtchTb.Text))
                mes += "Напишите Отчество\n";

            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }

            Model.Group_visit dobavleniye = new Model.Group_visit()
            {
                Familiya = FamTb.Text,
                Name = NameTb.Text,
                Otchestvo = OtchTb.Text,
                Num_Phone = PhoneTb.Text,
                Email = EmailTb.Text,
                Date_of_birth = Convert.ToDateTime(DatePc.Text),
                Passport_seria = SeriyaTb.Text,
                Pasport_nomer = NumberTb.Text,
                Purpose = CommentTb.Text
                
            };

            Kit.rk.Group_visit.Add(dobavleniye);

            Kit.rk.SaveChanges();
            MessageBox.Show("Успех");
            dfg.ItemsSource = Kit.rk.Group_visit.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();

            var qwe = openFile.FileName;
            file = File.ReadAllBytes(qwe);
        }
    }
    
}
