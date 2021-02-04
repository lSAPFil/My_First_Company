using Hochumoloka.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using static Hochumoloka.DataFrame;


namespace Hochumoloka.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageClient.xaml
    /// </summary>
    public partial class PageClient : Page
    {
        public PageClient()
        {
            InitializeComponent();
            lvClient.ItemsSource = context.User.ToList();
            List<Role> roles = context.Role.ToList();
            roles.Insert(0, new Role() { RoleName = "Все роли" });
            cmbRole.ItemsSource = roles;
            cmbRole.DisplayMemberPath = "RoleName";
            cmbRole.SelectedIndex = 0;

        }
        public void Filter()
        {
            var list = context.User.Where(i => i.LName.Contains(txbLName.Text))
                                    .Where(i => i.Login.Contains(txbLogin.Text))
                                    .Where(i => i.SName.Contains(txbFName.Text)).ToList();


            if (cmbRole.SelectedIndex == 0)
            {
                lvClient.ItemsSource = list;
            }
            else
            {
                var role = cmbRole.SelectedItem as Role;
                list = list.Where(i => i.Role == role.IdRole).ToList();
                lvClient.ItemsSource = list;
            }

        }

        private void txbLName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void txbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();

        }

        private void txbFName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowAddClient windowaddclient = new WindowAddClient();
            windowaddclient.ShowDialog();
            lvClient.ItemsSource = context.User.ToList();
            Filter();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (lvClient.SelectedItem is User User )
            {
                DataFrame.idClient = User.IdUser;
                WindowEditClient windoweditclient = new WindowEditClient();
                windoweditclient.ShowDialog();
                Filter();
            }
            else
            {
                MessageBox.Show("Выбери шо нибудь пж", "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);          }
          
            lvClient.ItemsSource = context.User.ToList();
            
        }
    }

    
}
