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
using Temp.Core.PriceLists.Model;
using Temp.Core.Sections.Model;
using Temp.Core.TollStations.Model;
using Temp.Database;
using Temp.GUI.Controller.PriceLists;
using Temp.GUI.Controller.Sections;
using Temp.GUI.Controller.TollStations;

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
        
        public AdministratorWindow(ServiceBuilder serviceBuilder)
        {
            this.serviceBuilder = serviceBuilder;
            InitializeComponent();
            InitializeControllers();
            InitializeCb();
        }


        #region PriceList
        void InitializeControllers()
        {
            sectionCotroller = new (serviceBuilder.SectionService);
            tollStationController = new(serviceBuilder.TollStationService);
            priceListController = new(serviceBuilder.PriceListService);
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
    }
}
