using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Temp.Core.TollStations.Model;
using Temp.Core.Sections.Model;
using Temp.Core.PriceLists.Model;
using Temp.Core.Payments.Model;
using Temp.Database;
using Temp.GUI.Controller.Users;
using Temp.GUI.Controller.TollStations;
using Temp.GUI.Controller.Sections;
using Temp.GUI.Controller.PriceLists;
using Temp.GUI.Controller.Payments;


namespace Temp.GUI.View.ClerkView
{
    /// <summary>
    /// Interaction logic for ClerkWindow.xaml
    /// </summary>
    public partial class ClerkWindow : Window
    {
        ServiceBuilder serviceBuilder;
        TollStationController tollStationController;
        SectionCotroller sectionCotroller;
        PriceListController priceListController;
        PaymentController paymentController;
        TollStation station;
        Payment payment;
        bool speed;
        float distance;
        BrushConverter bc;


        public ClerkWindow(TollStation _station)
        {
            serviceBuilder = new();
            tollStationController = new(serviceBuilder.TollStationService);
            sectionCotroller = new(serviceBuilder.SectionService);
            priceListController = new(serviceBuilder.PriceListService);
            paymentController = new(serviceBuilder.PaymentService);
            bc = new BrushConverter();

            station = _station;
            InitializeComponent();

            ExitStationText.Text = station.Name;

            StationsComboBox.SelectedValuePath = "Key";
            StationsComboBox.DisplayMemberPath = "Value";
            foreach(TollStation tollStation in tollStationController.TollStations)
            {
                StationsComboBox.Items.Add(new KeyValuePair<int, string>(tollStation.Id, tollStation.Name));
            }


            foreach(string name in Enum.GetNames(typeof(VehicleType)))
            {
                VehiclesComboBox.Items.Add(name);
            }
        }

        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            int exitId = station.Id;
            int entranceId = int.Parse(StationsComboBox.SelectedValue.ToString());

            Section section = sectionCotroller.GetSectionByStations(entranceId, exitId);
            distance = section.Distance;

            VehicleType vehicleType = (VehicleType)VehiclesComboBox.SelectedIndex;

            Price price = priceListController.GetPriceBySectionId(section.Id, vehicleType);
    
            PriceText.Text = price.PriceDin.ToString();

            DateTime entraceDT = DateTime.Today;
            int hours = int.Parse(EntranceHourBox.Text);
            int minutes = int.Parse(EntranceMinBox.Text);
            entraceDT = entraceDT.AddHours(hours);
            entraceDT = entraceDT.AddMinutes(minutes);

            DateTime exitDT = DateTime.Now;
            
            Random rnd = new Random();
            int num = rnd.Next(1, 999);
            string plates = "SM" + num + "AA";
               
            int paymentId = paymentController.GenerateId();
            payment = new Payment(paymentId, entraceDT, exitDT, plates, vehicleType, exitId, 1, section.Id);

            

            ChangeText.Text = "";
            SpeedText.Text = "";
            SpeedText.Background = (Brush)bc.ConvertFrom("#ffffff");
        }

        private void ChargeBtn_Click(object sender, RoutedEventArgs e)
        {
            paymentController.Add(payment);

            float price = float.Parse(PriceText.Text);
            float paid = float.Parse(PaidBox.Text);
            float change = paid - price;
            ChangeText.Text = change.ToString();
            
            speed = paymentController.CheckSpeed(payment, distance);


            if(speed == false)
            {
                SpeedText.Text = "Acceptable";
                SpeedText.Background = (Brush)bc.ConvertFrom("#98fb98");
            }
            else
            {
                SpeedText.Text = "Speeding";
                SpeedText.Background = (Brush)bc.ConvertFrom("#ff0000");
            }
        }
    }
}
