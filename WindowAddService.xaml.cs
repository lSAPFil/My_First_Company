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

namespace Hochumoloka.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowAddService.xaml
    /// </summary>
    public partial class WindowAddService : Window
    {
        public WindowAddService()
        {
            InitializeComponent();
        }

        private void btnAddNewServ (object sender, RoutedEventArgs e)
        {

            var price = decimal.Parse(SPrice.Text);

           
           
                context.Service.Add(new Service
                {
                    ServiceName = SName.Text,
                    Price = price
                });



                context.SaveChanges();
                MessageBox.Show($"Сервис {SName.Text} успешно добавлен", "Сообщение");
               this.Close();
            


            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
