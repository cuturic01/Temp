using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows;
using Temp.Core.TollStations.Model;
using Temp.Core.Sections.Model;
using Temp.Core.PriceLists.Model;
using Temp.Core.Payments.Model;
using Temp.Core.SpeedingPenalties.Model;
using Temp.Database;
using Temp.GUI.Controller.TollStations;
using Temp.GUI.Controller.Sections;
using Temp.GUI.Controller.PriceLists;
using Temp.GUI.Controller.Payments;
using Temp.GUI.Controller.SpeedingPenalties;


namespace Temp.GUI.View.ClerkView
{
    public partial class ClerkWindow : Window
    {
        TollStationController tollStationController;
        SectionCotroller sectionCotroller;
        PriceListController priceListController;
        PaymentController paymentController;
        SpeedingPenaltyController speedingPenaltyController;
        
        TollStation station;
        Payment payment;
        float speed;
        BrushConverter bc;


        public ClerkWindow(TollStation _station, ServiceBuilder serviceBuilder)
        {
            tollStationController = new(serviceBuilder.TollStationService);
            sectionCotroller = new(serviceBuilder.SectionService);
            priceListController = new(serviceBuilder.PriceListService);
            paymentController = new(serviceBuilder.PaymentService);
            speedingPenaltyController = new(serviceBuilder.SpeedingPenaltyService);
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

            speed = paymentController.CheckSpeed(payment, section.Distance);
            if(speed < 0)
            {
                SpeedText.Text = "Acceptable";
                SpeedText.Background = (Brush)bc.ConvertFrom("#98fb98");

            }
            else
            {
                SpeedText.Text = "Speeding";
                SpeedText.Background = (Brush)bc.ConvertFrom("#ff0000");
                int penaltyId = speedingPenaltyController.GenerateId();
                SpeedingPenalty penalty = new SpeedingPenalty(penaltyId, paymentId, exitDT, speed);
                speedingPenaltyController.Add(penalty);
            }
            ChangeText.Text = "";
        }

        private void ChargeBtn_Click(object sender, RoutedEventArgs e)
        {
            paymentController.Add(payment);

            float price = float.Parse(PriceText.Text);
            float paid = float.Parse(PaidBox.Text);
            float change = paid - price;

            ChangeText.Text = change.ToString();

        }
    }
}
