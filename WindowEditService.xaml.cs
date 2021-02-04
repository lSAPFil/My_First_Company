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

namespace Hochumoloka.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowEditService.xaml
    /// </summary>
    public partial class WindowEditService : Window
    {
        public WindowEditService()
        {
            InitializeComponent();
            var service = DataFrame.context.Service.Where(i => i.IdService == DataFrame.idService).FirstOrDefault();
            SName.Text = service.ServiceName;
            SPrice.Text = service.Price.ToString();
            
        }

        private void btnEditServ(object sender, RoutedEventArgs e)
        {
            var price = decimal.Parse(SPrice.Text);
            DataFrame.context.Service.Add(new Service
            {
                ServiceName = SName.Text,
                Price = price

            }) ;
            DataFrame.context.SaveChanges();
            MessageBox.Show($"Сервис {SName.Text} был изменен","Уведомление");
            this.Close();
                

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
