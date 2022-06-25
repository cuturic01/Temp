using System.Windows;
using Temp.Core.Users.Model;
using Temp.Core.TollStations.Model;
using Temp.Database;
using Temp.GUI.Controller.Users;
using Temp.GUI.Controller.TollStations;
using Temp.GUI.View.AdministratorView;
using Temp.GUI.View.BossView;
using Temp.GUI.View.ClerkView;
using Temp.GUI.View.ManagerView;
using Temp.GUI.View.StationWorkerView;

namespace Temp
{
    public partial class MainWindow : Window
    {
        ServiceBuilder serviceBuilder;
        UserController userController;
        TollStationController tollStationController;

        public MainWindow()
        {
            serviceBuilder = new();
            userController = new(serviceBuilder.UserService);
            tollStationController = new(serviceBuilder.TollStationService);
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTb.Text;
            string password = passwordTb.Password;

            User user = userController.Login(username, password);
            if (user is null)
            {
                MessageBox.Show("Invalid username or password!");
                passwordTb.Clear();
            }
            else if (user.UserType == UserType.ADMINISTRATOR)
            {
                AdministratorWindow administratorWindow = new();
                administratorWindow.Show();
                Close();
            }
            else if (user.UserType == UserType.BOSS)
            {
                BossWindow bossWindow = new();
                bossWindow.Show();
                Close();
            }
            else if (user.UserType == UserType.CLERK)
            {
                TollStation tollStation = tollStationController.FindByWorkerId(user.Jmbg);
                ClerkWindow clerkWindow = new(tollStation, serviceBuilder);
                clerkWindow.Show();
                Close();
            }
            else if (user.UserType == UserType.MANAGER)
            {
                ManagerWindow managerWindow = new();
                managerWindow.Show();
                Close();
            }
            else if (user.UserType == UserType.STATION_WORKER)
            {
                StationWorkerWindow stationWorkerWindow = new();
                stationWorkerWindow.Show();
                Close();
            }
            
        }
    }
}
