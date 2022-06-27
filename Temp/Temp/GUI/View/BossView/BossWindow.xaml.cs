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
using Temp.Core.Devices.Model;
using Temp.Core.TollBooths.Model;
using Temp.Core.TollStations.Model;
using Temp.Core.Users.Model;
using Temp.Database;
using Temp.GUI.Controller.Devices;
using Temp.GUI.Controller.Payments;
using Temp.GUI.Controller.TollBooths;
using Temp.GUI.Controller.TollStations;

namespace Temp.GUI.View.BossView
{
    
    public partial class BossWindow : Window
    {
        ServiceBuilder serviceBuilder;
        User boss;
        TollStationController tollStationController;
        DeviceController deviceController;
        TollBoothController tollBoothController;
        TollStation tollStation;
        PaymentController paymentController;

        public BossWindow(ServiceBuilder serviceBuilder, User boss)
        {
            this.serviceBuilder = serviceBuilder;
            this.boss = boss;
            InitializeComponent();
            InitializeControllers();
            tollStation = tollStationController.FindByBoss(boss.Jmbg);
            InitializeTollBoothCb();
            stationLbl.Content = tollStation.Name;
            dinIncomeTb.IsEnabled = false;
            eurIncomeTb.IsEnabled = false;
            fromIncomeDp.SelectedDate = DateTime.Now.Date;
            toIncomeDp.SelectedDate = DateTime.Now.Date;
        }

        void InitializeControllers()
        {
            tollStationController = new(serviceBuilder.TollStationService);
            tollBoothController = new(serviceBuilder.TollBoothService);
            deviceController = new(serviceBuilder.DeviceService);
            paymentController = new(serviceBuilder.PaymentService);
        }

        #region TollBoothState
        
        void DisplayTollBoothData()
        {
            TollBooth tollBooth = tollBoothController.FindById(tollStation.Id, (int)tollBoothCb.SelectedItem);
            tollBoothTypeTb.Text = tollBooth.TollBoothType.ToString();
            if (tollBooth.Malfunctioning)
            {
                tollBoothStatusTb.Text = "Malfunctioning";
                enableStationBtn.IsEnabled = true;
            }
            else 
            {
                tollBoothStatusTb.Text = "In Function";
                enableStationBtn.IsEnabled = false;
            } 
        }

        void InitializeDevices()
        {
            deviceCb.Items.Clear();
            TollBooth tollBooth = tollBoothController.FindById(tollStation.Id, (int)tollBoothCb.SelectedItem);
            foreach (int deviceId in tollBooth.Devices)
            {
                deviceCb.Items.Add(deviceId);
            }
            deviceCb.SelectedIndex = 0;
        }

        void DisplayDeviceData()
        {
            if (deviceCb.SelectedIndex != -1)
            {
                Device device = deviceController.FindById((int)deviceCb.SelectedItem);
                deviceTypeTb.Text = device.DeviceType.ToString();
                if (device.Malfunctioning)
                {
                    fixDeviceBtn.IsEnabled = true;
                    deviceLbl.Foreground = new SolidColorBrush(Colors.Red);
                }
                else 
                {
                    fixDeviceBtn.IsEnabled = false;
                    deviceLbl.Foreground = new SolidColorBrush(Colors.Black);
                }    
            }
        }

        void InitializeTollBoothCb()
        {
            List<TollBooth> tollBooths = tollBoothController.GetAllFromStation(tollStation);
            foreach (TollBooth tollBooth in tollBooths)
            {
                tollBoothCb.Items.Add(tollBooth.Number);
            }
            tollBoothCb.SelectedIndex = 0;
        }

        private void tollBoothCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayTollBoothData();
            InitializeDevices();

        }

        private void deviceCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayDeviceData();
        }

        private void fixDeviceBtn_Click(object sender, RoutedEventArgs e)
        {
            deviceController.Fix(deviceController.FindById((int)deviceCb.SelectedItem));
            DisplayTollBoothData();
            DisplayDeviceData();
        }

        private void enableStationBtn_Click(object sender, RoutedEventArgs e)
        {
            tollBoothController.Fix(tollBoothController.FindById(tollStation.Id, (int)tollBoothCb.SelectedItem));
            DisplayTollBoothData();
            DisplayDeviceData();
        }


        #endregion

        #region Report
        private void SearchIncomeBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime from = fromIncomeDp.SelectedDate.Value;
            DateTime to = toIncomeDp.SelectedDate.Value;
            if (from > to)
            {
                MessageBox.Show("Invalid date interval");
                return;
            }

            Tuple<float, float> prices = paymentController.FindSumOfPayments(tollStation.Id, from, to);
            dinIncomeTb.Text = prices.Item1.ToString()+"RSD";
            eurIncomeTb.Text = prices.Item2.ToString()+"EUR";
        }


        #endregion

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
