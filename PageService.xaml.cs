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
using Hochumoloka.Windows;
using static System.Decimal;
using static Hochumoloka.DataFrame;

namespace Hochumoloka.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageService.xaml
    /// </summary>
    public partial class PageService : Page
    {
        decimal minp = 0, maxp = decimal.MaxValue;
        public void Buf(decimal max, decimal min)
        {
            var list = context.Service.Where(i => i.ServiceName.Contains(tbName.Text))
                                        .Where(i => i.Price >= max)
                                        .Where(i => i.Price <= min).ToList();
            ListMain.ItemsSource = list;

        }
        public PageService()
        {
            InitializeComponent();
            ListMain.ItemsSource = context.Service.ToList();
        }

        private void tbName_TextChanged (object sender, TextChangedEventArgs e)
        {
            
            Buf(minp,maxp);
        }

        private void tbMAXPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (tbName.Text.Length > 0)
            {
                maxp = Convert.ToDecimal(tbMAXPrice.Text);
            }
            Buf(minp, maxp);
        }

        private void tbMINPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbName.Text.Length > 0)
            {
                minp = Convert.ToDecimal(tbMINPrice.Text);
            }
            Buf(minp, maxp);
        }

        private void dtAddClick(object sender, RoutedEventArgs e)
        {
            WindowAddService windowaddswevice = new WindowAddService();
            windowaddswevice.Show();
            ListMain.SelectedItem = context.Service.ToList();
            Buf(minp, maxp);
        }

        private void dtEditClick(object sender, RoutedEventArgs e)
        {
            if (ListMain.SelectedItem is Service Service)
            {
                DataFrame.idService = Service.IdService;
                WindowEditService windoweditswevice = new WindowEditService();
                windoweditswevice.Show();
                Buf(minp, maxp);
            }
            else
            {
                MessageBox.Show("Ну, крч, опять наложал, начни уже выбирать строчки, а не бездумно тыкать на кнопку", "Задолбал, соре");

            }
        }
    }
}
