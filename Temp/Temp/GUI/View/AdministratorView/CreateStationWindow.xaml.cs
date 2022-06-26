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
using Temp.Core.DeploymentHistory.Model;
using Temp.Core.Locations.Model;
using Temp.Core.TollStations.Model;
using Temp.Core.Users.Model;
using Temp.Database;
using Temp.GUI.Controller.DeploymentHystory;
using Temp.GUI.Controller.Locations;
using Temp.GUI.Controller.TollStations;
using Temp.GUI.Controller.Users;
using Temp.GUI.Dto;

namespace Temp.GUI.View.AdministratorView
{
    
    public partial class CreateStationWindow : Window
    {
        ServiceBuilder serviceBuilder;
        TollStationController tollStationController;
        BossController bossController;
        LocationController locationController;
        DeploymentHistoryController deploymentHistoryController;

        public CreateStationWindow(ServiceBuilder serviceBuilder)
        {
            this.serviceBuilder = serviceBuilder;
            InitializeComponent();
            InitializeControllers();
            InitializeLocations();
            InitializeBosses();
        }

        void InitializeControllers()
        {
            tollStationController = new(serviceBuilder.TollStationService);
            bossController = new(serviceBuilder.BossService);
            locationController = new(serviceBuilder.LocationService);
            deploymentHistoryController = new(serviceBuilder.DeploymentHisyoryService);
        }

        void InitializeBosses()
        {
            List<Boss> bosses = tollStationController.AvailableBosses();
            foreach (Boss boss in bosses)
            {
                bossesCb.Items.Add(boss.Jmbg);
            }
            bossesCb.SelectedIndex = 0;
        }

        void DIsplayBossData()
        {
            Boss boss = bossController.FindByJmbg((string)bossesCb.SelectedItem);
            bossNameTb.Text = boss.Name + " " + boss.LastName;
        }

        private void bossesCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bossesCb.SelectedIndex != -1)
            {
                DIsplayBossData();
            }
        }

        void InitializeLocations()
        {
            foreach (Location location in locationController.Locations)
            {
                locationCb.Items.Add(location.Zip);
            }
            locationCb.SelectedIndex = 0;
        }

        void DisplayLocationData()
        {
            Location location = locationController.FindByZip((string)locationCb.SelectedItem);
            countryTb.Text = location.Country;
            cityTb.Text = location.Name;
            municipalityTb.Text = location.Municipality;
        }

        private void locationCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (locationCb.SelectedIndex != -1)
            {
                DisplayLocationData();
            }
        }

        void ValidateName()
        {
            if (nameTb.Text.Length < 5 || nameTb.Text.Length > 30)
            {
                throw new Exception("Name must be between 5 and 30 characters");
            }
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidateName();
                TollStationDto tollStationDto = new TollStationDto(tollStationController.GenerateId(), nameTb.Text,
                    (string)bossesCb.SelectedItem, (string)locationCb.SelectedItem);
                tollStationController.Add(tollStationDto);
                Boss boss = bossController.FindByJmbg((string)bossesCb.SelectedItem);
                DeploymentHistoryRecord deploymentHistoryRecord = bossController.PutToStation(tollStationDto.Id, boss);
                deploymentHistoryController.Add(deploymentHistoryRecord);
                MessageBox.Show("Toll station created sucessfully");
                Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
