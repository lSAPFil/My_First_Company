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
using static Hochumoloka.DataFrame;

namespace Hochumoloka.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowEditClient.xaml
    /// </summary>
    public partial class WindowEditClient : Window
    {
        private string PhotoImage;
        public WindowEditClient()
        {
            InitializeComponent();
            AddRole.ItemsSource = DataFrame.context.Role.Select(i => i.RoleName).ToList();
            var user = DataFrame.context.User.Where(i => i.IdUser == DataFrame.idClient).FirstOrDefault();
          
            LNAME.Text = user.Name;
            FNAME.Text = user.LName;
            MNAME.Text = user.SName;
            LOGIN.Text = user.Login;
            PASSWORD.Text = user.Password;
            AddRole.SelectedItem = DataFrame.context.Role.Where(i => i.IdRole == user.Role).Select(i => i.RoleName).FirstOrDefault();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
            MessageBox.Show($"Клиент {LNAME.Text}  {FNAME.Text}  {MNAME.Text} успешно изменен", "Сообщение");
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OPD = new OpenFileDialog();
            if (OPD.ShowDialog() == true)
            {
                photoUser.Source = new BitmapImage(new Uri(OPD.FileName));
                PhotoImage = OPD.FileName;
            }

        }
    }
}
