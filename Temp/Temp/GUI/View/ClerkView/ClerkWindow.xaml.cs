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
using Temp.GUI.Controller.Devices;
using Temp.Core.Devices.Model;
using Temp.GUI.Controller.TollBooths;

namespace Temp.GUI.View.ClerkView
{
    public partial class ClerkWindow : Window
    {
        TollStationController tollStationController;
        SectionCotroller sectionCotroller;
        PriceListController priceListController;
        PaymentController paymentController;
        SpeedingPenaltyController speedingPenaltyController;
        DeviceController deviceController;
        TollBoothController tollBoothController;
        
        TollStation station;
        Payment payment;
        float speed;
        BrushConverter bc;

        Dictionary<string, bool> rampStatusDisplay;
        Dictionary<string, Device> rampDisplay;
        Dictionary<string, bool> deviceStatusDisplay;
        Dictionary<string, Device> deviceDisplay; 

        public ClerkWindow(TollStation _station, ServiceBuilder serviceBuilder)
        {
            tollStationController = new(serviceBuilder.TollStationService);
            sectionCotroller = new(serviceBuilder.SectionService);
            priceListController = new(serviceBuilder.PriceListService);
            paymentController = new(serviceBuilder.PaymentService);
            speedingPenaltyController = new(serviceBuilder.SpeedingPenaltyService);
            deviceController = new(serviceBuilder.DeviceService);
            tollBoothController = new(serviceBuilder.TollBoothService);
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

            InitializeRampStatusComboBox();
            RampStatusBtn.IsEnabled = false;
            InitializeRamps();

            InitializeDeviceStatusComboBox();
            DeviceStatusBtn.IsEnabled = false;
            InitializeDevices();
        }

        private void InitializeRampStatusComboBox()
        {
            rampStatusDisplay = new Dictionary<string, bool>();
            rampStatusDisplay.Add("Functioning", false);
            rampStatusDisplay.Add("Malfunctioning", true);

            RampStatusComboBox.Items.Add("Functioning");
            RampStatusComboBox.Items.Add("Malfunctioning");
        }

        private void InitializeRamps()
        {
            RampStatusList.Items.Clear();
            rampDisplay = new Dictionary<string, Device>();
            foreach (int boothNum in station.TollBooths)
            {
                Device ramp = tollBoothController.FindBoothRamp(station.Id, boothNum);
                string functioning = "functioning";
                if (ramp.Malfunctioning)
                    functioning = "malfunctioning";
                string display = "booth: " + boothNum + ", " + ramp.Name + " - " + functioning;
                RampStatusList.Items.Add(display);
                rampDisplay.Add(display, ramp);
            }
        }

        private void InitializeDeviceStatusComboBox()
        {
            deviceStatusDisplay = new Dictionary<string, bool>();
            deviceStatusDisplay.Add("Functioning", false);
            deviceStatusDisplay.Add("Malfunctioning", true);

            DeviceStatusComboBox.Items.Add("Functioning");
            DeviceStatusComboBox.Items.Add("Malfunctioning");
        }

        private void InitializeDevices()
        {
            DeviceStatusList.Items.Clear();
            deviceDisplay = new Dictionary<string, Device>();
            foreach (int boothNum in station.TollBooths)
            {
                List<Device> devices = tollBoothController.DevicesByBooth(station.Id, boothNum);
                foreach (Device device in devices)
                {
                    if (device.DeviceType != DeviceType.RAMP)
                    {
                        string functioning = "functioning";
                        if (device.Malfunctioning)
                            functioning = "malfunctioning";
                        string display = "booth: " + boothNum + ", " + device.Name + " - " + functioning;
                        DeviceStatusList.Items.Add(display);
                        deviceDisplay.Add(display, device);
                    }
                }
            }
        }

        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StationsComboBox.SelectedValue == null ||  VehiclesComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Enter all parametars");
                return;
            }

            int exitId = station.Id;
            int entranceId = int.Parse(StationsComboBox.SelectedValue.ToString());

            Section section = sectionCotroller.GetSectionByStations(entranceId, exitId);

            VehicleType vehicleType = (VehicleType)VehiclesComboBox.SelectedIndex;

            Price price = priceListController.GetPriceBySectionId(section.Id, vehicleType);

    
            PriceText.Text = price.PriceDin.ToString();

            try{
                int.Parse(EntranceHourBox.Text);
                int.Parse(EntranceMinBox.Text);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }


            DateTime entraceDT = DateTime.Today;
            int hours = int.Parse(EntranceHourBox.Text);
            int minutes = int.Parse(EntranceMinBox.Text);
            entraceDT = entraceDT.AddHours(hours);
            entraceDT = entraceDT.AddMinutes(minutes);

            DateTime exitDT = DateTime.Now;
            
            Random rnd = new Random();
            int num = rnd.Next(1, 999);
            string plates = "SM" + num + "AA";

            PlatesText.Text = plates;
               
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

        private void RampStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            Device ramp = rampDisplay[RampStatusList.SelectedItem.ToString()];
            bool malfunctioning = rampStatusDisplay[RampStatusComboBox.SelectedItem.ToString()];
            deviceController.SetMalfunctionig(ramp.Id, malfunctioning);

            MessageBox.Show("Ramp status updated");
            InitializeRamps();
        }

        private void RampStatusList_SelectionChanged(object sender, 
            System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (RampStatusList.SelectedIndex != -1)
            {
                RampStatusBtn.IsEnabled = true;
                Device ramp = rampDisplay[RampStatusList.SelectedItem.ToString()];
                if (ramp.Malfunctioning)
                {
                    RampStatusComboBox.SelectedItem = "Malfunctioning";
                    return;
                }
                RampStatusComboBox.SelectedItem = "Functioning";
            }
        }

        private void DeviceStatusList_SelectionChanged(object sender, 
            System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (DeviceStatusList.SelectedIndex != -1)
            {
                DeviceStatusBtn.IsEnabled = true;
                Device device = deviceDisplay[DeviceStatusList.SelectedItem.ToString()];
                if (device.Malfunctioning)
                {
                    DeviceStatusComboBox.SelectedItem = "Malfunctioning";
                    return;
                }
                DeviceStatusComboBox.SelectedItem = "Functioning";
            }
        }

        private void DeviceStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            Device device = deviceDisplay[DeviceStatusList.SelectedItem.ToString()];
            bool malfunctioning = deviceStatusDisplay[DeviceStatusComboBox.SelectedItem.ToString()];
            deviceController.SetMalfunctionig(device.Id, malfunctioning);

            MessageBox.Show("Device status updated");
            InitializeDevices();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Log out?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MainWindow main = new MainWindow();
                main.Show();
            }
            else e.Cancel = true;
        }
    }
}
