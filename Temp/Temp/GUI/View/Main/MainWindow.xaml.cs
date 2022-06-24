using System.Windows;
using Temp.Database;

namespace Temp
{
    public partial class MainWindow : Window
    {
        ServiceBuilder serviceBuilder;

        public MainWindow()
        {
            serviceBuilder = new();

            InitializeComponent();
        }
    }
}
