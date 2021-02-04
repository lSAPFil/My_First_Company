using Microsoft.Win32;
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
using System.Windows.Shapes;
using static Hochumoloka.DataFrame;
using System.Windows.Media;
using System.IO;

namespace Hochumoloka.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowAddClient.xaml
    /// </summary>
    public partial class WindowAddClient : Window
    {
        private string PhotoImage;
        public WindowAddClient()
        {
            InitializeComponent();
            AddRole.ItemsSource = context.Role.Select(i => i.RoleName).ToList();
        }

        private void BtnAddNew(object sender, RoutedEventArgs e)
        {
            context.User.Add(new User
            {
                Name = LNAME.Text,
                LName = FNAME.Text,
                SName = MNAME.Text,
                Login = LOGIN.Text,
                Password = PASSWORD.Text,
                Role = context.Role.Where(i => i.RoleName == AddRole.SelectedItem.ToString()).Select(i => i.IdRole).FirstOrDefault(),
                image = File.ReadAllBytes(PhotoImage)
            });
            context.SaveChanges();
            MessageBox.Show($"Клиент {LNAME.Text} {FNAME.Text} {MNAME.Text} успешно добавлен", "Сообщение");
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OPD = new OpenFileDialog();
            if(OPD.ShowDialog()==true)
            {
                photoUser.Source = new BitmapImage(new Uri(OPD.FileName));
                PhotoImage = OPD.FileName;
            }
        }
    }
}
