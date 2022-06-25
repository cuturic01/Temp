using Temp.Core.DeploymentHistory.Service;
using Temp.Core.Devices.Service;
using Temp.Core.Locations.Service;
using Temp.Core.Payments.Service;
using Temp.Core.PriceLists.Service;
using Temp.Core.Sections.Service;
using Temp.Core.SpeedingPenalties.Service;
using Temp.Core.TollBooths.Service;
using Temp.Core.TollStations.Service;
using Temp.Core.Users.Service;

namespace Temp.Database
{
    public class ServiceBuilder
    {
        IDeploymentHisyoryService deploymentHisyoryService;
        IDeviceService deviceService;
        ILocationService locationService;
        IPaymentService paymentService;
        IPriceListService priceListService;
        ISectionService sectionService;
        ISpeedingPenaltyService speedingPenaltyService;
        ITollBoothService tollBoothService;
        ITollStationService tollStationService;
        IBossService bossService;
        ITagUserService tagUserService;
        IUserService userService;

        public ServiceBuilder()
        {
            TollBoothDatabase tollBoothDatabase = new();
            deploymentHisyoryService = new DeploymentHisyoryService(tollBoothDatabase.DeploymentHistoryRepo);
            deviceService = new DeviceService(tollBoothDatabase.DeviceRepo);
            locationService = new LocationService(tollBoothDatabase.LocationRepo);
            paymentService = new PaymentService(tollBoothDatabase.PaymentRepo);
            priceListService = new PriceListService(tollBoothDatabase.PriceListRepo);
            sectionService = new SectionService(tollBoothDatabase.SectionRepo);
            speedingPenaltyService = new SpeedingPenaltyService(tollBoothDatabase.SpeedingPenaltyRepo);
            tollBoothService = new TollBoothService(tollBoothDatabase.TollBoothRepo);
            tollStationService = new TollStationService(tollBoothDatabase.TollStationRepo);
            bossService = new BossService(tollBoothDatabase.BossRepo);
            tagUserService = new TagUserService(tollBoothDatabase.TagUserRepo);
            userService = new UserService(tollBoothDatabase.UserRepo, bossService);
        }

        public IDeploymentHisyoryService DeploymentHisyoryService { get => deploymentHisyoryService; }

        public ILocationService LocationService { get => locationService; }

        public IPaymentService PaymentService { get => paymentService; }

        public IPriceListService PriceListService { get => priceListService; }

        public ISectionService SectionService { get => sectionService; }

        public ISpeedingPenaltyService SpeedingPenaltyService { get => speedingPenaltyService; }

        public ITollBoothService TollBoothService { get => tollBoothService; }

        public ITollStationService TollStationService { get => tollStationService; }

        public IBossService BossService { get => bossService; }

        public ITagUserService TagUserService { get => tagUserService; }

        public IUserService UserService { get => userService; }
    }
}
