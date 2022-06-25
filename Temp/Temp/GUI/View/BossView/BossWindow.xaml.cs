﻿using System;
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
using Temp.GUI.Controller.TollBooths;
using Temp.GUI.Controller.TollStations;

namespace Temp.GUI.View.BossView
{
    /// <summary>
    /// Interaction logic for BossWindow.xaml
    /// </summary>
    public partial class BossWindow : Window
    {
        ServiceBuilder serviceBuilder;
        User boss;
        TollStationController tollStationController;
        DeviceController deviceController;
        TollBoothController tollBoothController;
        TollStation tollStation;

        public BossWindow(ServiceBuilder serviceBuilder, User boss)
        {
            this.serviceBuilder = serviceBuilder;
            this.boss = boss;
            InitializeComponent();
            InitializeControllers();
            tollStation = tollStationController.FindByBoss(boss.Jmbg);
            InitializeTollBoothCb();
            stationLbl.Content = tollStation.Name;
        }

        void InitializeControllers()
        {
            tollStationController = new(serviceBuilder.TollStationService);
            tollBoothController = new(serviceBuilder.TollBoothService);
            deviceController = new(serviceBuilder.DeviceService);
        }

        #region TollBoothState
        
        void DisplayTollBoothData()
        {
            TollBooth tollBooth = tollBoothController.FindById(tollStation.Id, (int)tollBoothCb.SelectedItem);
            tollBoothTypeTb.Text = tollBooth.TollBoothType.ToString();
            if (tollBooth.Malfunctioning) tollBoothStatusTb.Text = "Malfunctioning";
            else tollBoothStatusTb.Text = "In Function";
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
        #endregion

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
            tollBoothController.CheckForFixing(tollBoothController.FindById(tollStation.Id, (int)tollBoothCb.SelectedItem));
            DisplayTollBoothData();
            DisplayDeviceData();
        }
    }
}
