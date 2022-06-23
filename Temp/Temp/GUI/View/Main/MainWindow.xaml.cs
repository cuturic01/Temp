using System.Windows;
using Temp.Database;

namespace Temp
{
    public partial class MainWindow : Window
    {
        TollBoothDatabase tollStationDatabase;

        public MainWindow()
        {
            tollStationDatabase = new();
            tollStationDatabase.printDatabase();
            InitializeComponent();
        }
    }
}
