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
using System.Windows.Shapes;

namespace Lupa_i_pupa
{
    /// <summary>
    /// Логика взаимодействия для Lichnoe.xaml
    /// </summary>
    public partial class Lichnoe : Window
    {
        public Lichnoe()
        {
            InitializeComponent();
            this.DataContext = Kit.rk.Personal_visit;
            Cmb1.ItemsSource = Kit.rk.Personal_visit.ToList();
            Cmb2.ItemsSource = Kit.rk.Division.ToList();
            OrgTb.ItemsSource = Kit.rk.Department.ToList();
        }
        public byte[] file;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(FamTb.Text))
                mes += "Напишите ФИО \n";

            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
            Model.Personal_visit dobavleniye = new Model.Personal_visit()
            {
                Fio= FamTb.Text,
                Num_Phone = NumberTb.Text,
                Email = OtchTb.Text,
                Date_of_birth = Convert.ToDateTime(DatePc.Text),
                Passport_seria = SeriyaTb.Text,
                Pasport_nomer = NumberTb.Text,
                Purpose = Cmb1.Text
            };

            Model.Division dobavleniyeDV = new Model.Division()
            {
                Division_name = Cmb2.Text
            };
            Kit.rk.Division.Add(dobavleniyeDV);
            Kit.rk.Personal_visit.Add(dobavleniye);
            Kit.rk.SaveChanges();
            MessageBox.Show("Успех");
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();

            var qwe = openFile.FileName;
            file = File.ReadAllBytes(qwe);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();

            var qwe = openFile.FileName;
            file = File.ReadAllBytes(qwe);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TextTb1.Clear();
            FamTb.Clear();
           
            OtchTb.Clear();
            NumberTb.Clear();
            OtchTb.Clear();
            CommentTb.Clear();
            SeriyaTb.Clear();
            NumberTb.Clear();
        }
    }
}
