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
            priceListService = new PriceListService(tollBoothDatabase.PriceListRepo);
            sectionService = new SectionService(tollBoothDatabase.SectionRepo);
            speedingPenaltyService = new SpeedingPenaltyService(tollBoothDatabase.SpeedingPenaltyRepo);
            tollBoothService = new TollBoothService(tollBoothDatabase.TollBoothRepo, deviceService, tollStationService);
            bossService = new BossService(tollBoothDatabase.BossRepo);
            tollStationService = new TollStationService(tollBoothDatabase.TollStationRepo, bossService,tollBoothService, sectionService);
            paymentService = new PaymentService(tollBoothDatabase.PaymentRepo, priceListService, tollStationService);
            tagUserService = new TagUserService(tollBoothDatabase.TagUserRepo);
            userService = new UserService(tollBoothDatabase.UserRepo, bossService);
            tollBoothService.TollStationService = tollStationService;
        }

        public IDeploymentHisyoryService DeploymentHisyoryService { get => deploymentHisyoryService; }

        public IDeviceService DeviceService { get => deviceService; set => deviceService = value; }

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
        public IDeviceService DeviceService { get => deviceService; set => deviceService = value; }
    }
}
