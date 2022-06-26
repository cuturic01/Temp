using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Temp.Core.Locations.Model;
using Temp.Core.PriceLists.Model;
using Temp.Core.Sections.Model;
using Temp.Core.TollBooths.Model;
using Temp.Core.TollStations.Model;
using Temp.Database;
using Temp.GUI.Controller.Locations;
using Temp.GUI.Controller.PriceLists;
using Temp.GUI.Controller.Sections;
using Temp.GUI.Controller.TollBooths;
using Temp.GUI.Controller.TollStations;
using Temp.GUI.Dto;

namespace Temp.GUI.View.AdministratorView
{
    /// <summary>
    /// Interaction logic for AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        ServiceBuilder serviceBuilder;
        SectionCotroller sectionCotroller;
        TollStationController tollStationController;
        PriceListController priceListController;
        LocationController locationController;
        TollBoothController tollBoothController;
        private Dictionary<int, TollStation> indexedTollStations;
        private Dictionary<int, TollBooth> indexedTollBooths;


        public AdministratorWindow(ServiceBuilder serviceBuilder)
        {
            this.serviceBuilder = serviceBuilder;
            indexedTollBooths = new();
            indexedTollStations = new();
            InitializeComponent();
            InitializeControllers();
            InitializeCb();
            InitializeTollBoothCb();
            InitilaizeTollBoothType();
            InitializeTollBoothLb();
        }


        #region PriceList
        void InitializeControllers()
        {
            sectionCotroller = new (serviceBuilder.SectionService);
            tollStationController = new(serviceBuilder.TollStationService);
            priceListController = new(serviceBuilder.PriceListService);
            locationController = new(serviceBuilder.LocationService);
            tollBoothController = new(serviceBuilder.TollBoothService);
        }

        void InitializeCb()
        {
            foreach (Section section in sectionCotroller.Sections)
            {
                sectionCb.Items.Add(section.Id);
            }

            sectionCb.SelectedIndex = 0;
        }

        void DisplaySectionData(int sectionId)
        {
            Section section = sectionCotroller.FindById(sectionId);
            TollStation entranceStation = tollStationController.FindById(section.EntranceStation);
            TollStation exitStation = tollStationController.FindById(section.ExitStation);
            entryTb.Text = entranceStation.Name;
            exitTb.Text = exitStation.Name;
        }

        void DisplayPrices(int sectionId)
        {
            priceInformationLb.Items.Clear();
            List<Price> prices = priceListController.GetPricesBySection(sectionId);
            foreach (Price price in prices)
            {
                priceInformationLb.Items.Add("Vechile type: " + price.VehicleType1 + ", EUR: " 
                    + price.PriceEur + ", RSD: " + price.PriceDin);
            }
        }

        private void sectionCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sectionCb.SelectedIndex != -1)
            {
                DisplaySectionData((int)sectionCb.SelectedItem);
                DisplayPrices((int)sectionCb.SelectedItem);
                DisplayPriceListDate();
            }
            
        }

        private void DisplayPriceListDate()
        {
            PriceList activePriceList = priceListController.GetActive(DateTime.Today);

            startDateLbl.Content = activePriceList.StartDate.ToString("dd.MM.yyyy.");
        }
        #endregion

        #region TollBooths

        private void InitializeTollBoothCb()
        {
            int index = 0;
            foreach (TollStation tollStation in tollStationController.TollStations)
            {
                Location location=locationController.FindByZip(tollStation.LocationZip);
                stationIdCb.Items.Add(tollStation.Id + "-" + location.Municipality);
                indexedTollStations.Add(index,tollStation);
                index++;
            }

            stationIdCb.SelectedIndex = 0;
        }

        private void InitilaizeTollBoothType()
        {
            TollBoothTypeCb.ItemsSource = Enum.GetValues(typeof(TollBoothType));
            TollBoothTypeCb.SelectedIndex = 0;
        }

        private void InitializeTollBoothLb()
        {
            tollBoothsLb.Items.Clear();
            indexedTollBooths.Clear();
            int index = 0;
            foreach (TollBooth tollBooth in tollBoothController.TollBooths)
            {
                string functioning = "In function";
                if (tollBooth.Malfunctioning)
                    functioning = "Not in function";
                tollBoothsLb.Items.Add(tollBooth.TollStationId.ToString() + "|" + tollBooth.Number.ToString() + "|" +
                                       tollBooth.TollBoothType.ToString().ToLower() + "|" +
                                       functioning);
                indexedTollBooths.Add(index, tollBooth);
                index++;
            }
        }


        #endregion

        private void createTollBothBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (stationIdCb.SelectedIndex != -1 && TollBoothTypeCb.SelectedIndex != -1 && tollBoothNumberTb.Text != "")
                {
                    int number = Convert.ToInt32(tollBoothNumberTb.Text);
                    bool malfunctioning = malfunctioningTollBoothCh.IsChecked == true;
                    TollBoothDto tollBoothDto = new(indexedTollStations[stationIdCb.SelectedIndex].Id, number,
                        (TollBoothType)TollBoothTypeCb.SelectedItem, malfunctioning, null);
                    tollBoothController.Add(tollBoothDto);
                }
            }
            catch
            {
                MessageBox.Show("Number is not valid!");
            }
            
        }


        private void deselectBtn_Click(object sender, RoutedEventArgs e)
        {
            tollBoothsLb.SelectedIndex = -1;
        }

        private void tollBoothsLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tollBoothsLb.SelectedIndex == -1)
            {
                stationIdCb.IsEnabled = true;
            }
            else
            {
                stationIdCb.IsEnabled = false;
                TollBooth tollBooth = indexedTollBooths[tollBoothsLb.SelectedIndex];
                TollStation tollStation = tollStationController.FindById(tollBooth.TollStationId);
                Location location = locationController.FindByZip(tollStation.LocationZip);
                stationIdCb.SelectedItem = tollBooth.TollStationId + "-" + location.Municipality;
                TollBoothTypeCb.SelectedItem = tollBooth.TollBoothType;
                tollBoothNumberTb.Text = tollBooth.Number.ToString();
                malfunctioningTollBoothCh.IsChecked = true;
            }
        }

        private void UpdateTollBoothBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
