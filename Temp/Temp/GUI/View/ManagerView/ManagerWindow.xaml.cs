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
using Temp.Core.Locations.Model;
using Temp.Core.TollStations.Model;
using Temp.Database;
using Temp.GUI.Controller.Locations;
using Temp.GUI.Controller.Payments;
using Temp.GUI.Controller.TollStations;

namespace Temp.GUI.View.ManagerView
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        ServiceBuilder serviceBuilder;
        PaymentController paymentController;
        TollStationController tollStationController;
        private LocationController locationController;
        public ManagerWindow(ServiceBuilder serviceBuilder)
        {
            this.serviceBuilder = serviceBuilder;
            InitializeComponent();
            InitializeControllers();

            fromIncomeDp.SelectedDate = DateTime.Now.Date;
            toIncomeDp.SelectedDate = DateTime.Now.Date;

        }

        public void InitializeControllers()
        {
            paymentController = new(serviceBuilder.PaymentService);
            tollStationController = new(serviceBuilder.TollStationService);
            locationController = new(serviceBuilder.LocationService);
        }

        private void SearchIncomeBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime from = fromIncomeDp.SelectedDate.Value;
            DateTime to = toIncomeDp.SelectedDate.Value;
            if (from > to)
            {
                MessageBox.Show("Invalid date interval");
                return;
            }
            tollStationsIncomeLb.Items.Clear();
            Tuple<float, float> prices = paymentController.FindSumOfPayments(from, to);
            dinIncomeTb.Text = prices.Item1.ToString() + "RSD";
            eurIncomeTb.Text = prices.Item2.ToString() + "EUR";

            foreach (TollStation tollStation in tollStationController.TollStations)
            {
                Tuple<float, float> price = paymentController.FindSumOfPayments(tollStation.Id, from, to);
                Location location = locationController.FindByZip(tollStation.LocationZip);
                tollStationsIncomeLb.Items.Add(price.Item1+"RSD"+"\t"+price.Item2+"EUR"+"\t"+ tollStation.Id + "-" + location.Municipality);
            }
        }
    }
}
