using System;
using Temp.Core.DeploymentHistory.Model;
using Temp.Core.DeploymentHistory.Repository;
using Temp.Core.Locations.Model;
using Temp.Core.Locations.Repository;
using Temp.Core.Payments.Model;
using Temp.Core.Payments.Repository;
using Temp.Core.PriceLists.Model;
using Temp.Core.PriceLists.Repository;
using Temp.Core.Sections.Model;
using Temp.Core.Sections.Repository;
using Temp.Core.SpeedingPenalties.Model;
using Temp.Core.SpeedingPenalties.Repository;
using Temp.Core.TollBooths.Model;
using Temp.Core.TollBooths.Repository;
using Temp.Core.TollStations.Model;
using Temp.Core.TollStations.Repository;
using Temp.Core.Users.Model;
using Temp.Core.Users.Repository;

namespace Temp
{
    public enum VehicleType { CLASS_1A, CLASS_1, CLASS_2, CLASS_3, CLASS_4 }

    public enum TollBoothType { MANUAL, AUOTOMATIC }

    public enum UserType { CLERK, STATION_WORKER, MANAGER, ADMINISTRATOR, STATION_BOSS }
}

namespace Temp.Database
{
    public class TollBoothDatabase
    {
        IDeploymentHistoryRepo deploymentHistoryRepo;
        ILocationRepo locationRepo;
        IPaymentRepo paymentRepo;
        IPriceListRepo priceListRepo;
        ISectionRepo sectionRepo;
        ISpeedingPenaltyRepo speedingPenaltyRepo;
        ITollBoothRepo tollBoothRepo;
        ITollStationRepo tollStationRepo;
        IBossRepo bossRepo;
        ITagUserRepo tagUserRepo;
        IUserRepo userRepo;

        public TollBoothDatabase()
        {
            deploymentHistoryRepo = new DeploymentHistoryRepo();
            locationRepo = new LocationRepo();
            paymentRepo = new PaymentRepo();
            priceListRepo = new PriceListRepo();
            sectionRepo = new SectionRepo();
            speedingPenaltyRepo = new SpeedingPenaltyRepo();
            tollBoothRepo = new TollBoothRepo();
            tollStationRepo = new TollStationRepo();
            bossRepo = new BossRepo();
            tagUserRepo = new TagUserRepo();
            userRepo = new UserRepo();
        }

        public IDeploymentHistoryRepo DeploymentHistoryRepo { get => deploymentHistoryRepo; }

        public ILocationRepo LocationRepo { get => locationRepo; }

        public IPaymentRepo PaymentRepo { get => paymentRepo; }

        public IPriceListRepo PriceListRepo { get => priceListRepo; }

        public ISpeedingPenaltyRepo SpeedingPenaltyRepo { get => speedingPenaltyRepo; }

        public ITollStationRepo TollStationRepo { get => tollStationRepo; }

        public IBossRepo BossRepo { get => bossRepo; }

        public ITagUserRepo TagUserRepo { get => tagUserRepo; }

        public IUserRepo UserRepo { get => userRepo; }

        public ISectionRepo SectionRepo { get => sectionRepo; }

        public ITollBoothRepo TollBoothRepo { get => tollBoothRepo; }

        public void printDatabase()
        {
            Console.WriteLine("Deploment Hystory:");
            foreach (DeploymentHistoryRecord deploymentHistoryRecord in deploymentHistoryRepo.DeploymentHistoryRecords)
                Console.WriteLine(deploymentHistoryRecord);
            Console.WriteLine("-------------------------------------------------------------------------------------");

            Console.WriteLine("Locations:");
            foreach (Location location in locationRepo.Locations)
                Console.WriteLine(location);
            Console.WriteLine("-------------------------------------------------------------------------------------");

            Console.WriteLine("Payments:");
            foreach (Payment payment in paymentRepo.Payments)
                Console.WriteLine(payment);
            Console.WriteLine("-------------------------------------------------------------------------------------");

            Console.WriteLine("Price lists:");
            foreach (PriceList priceList in priceListRepo.PriceLists)
                Console.WriteLine(priceList);
            Console.WriteLine("-------------------------------------------------------------------------------------");

            Console.WriteLine("Sections:");
            foreach (Section section in sectionRepo.Sections)
                Console.WriteLine(section);
            Console.WriteLine("-------------------------------------------------------------------------------------");

            Console.WriteLine("Speeding penalties:");
            foreach (SpeedingPenalty speedingPenalty in speedingPenaltyRepo.SpeedingPenalties)
                Console.WriteLine(speedingPenalty);
            Console.WriteLine("-------------------------------------------------------------------------------------");

            Console.WriteLine("Toll booths:");
            foreach (TollBooth tollBooth in tollBoothRepo.TollBooths)
                Console.WriteLine(tollBooth);
            Console.WriteLine("-------------------------------------------------------------------------------------");

            Console.WriteLine("Toll stations:");
            foreach (TollStation tollStation in tollStationRepo.TollStations)
                Console.WriteLine(tollStation);
            Console.WriteLine("-------------------------------------------------------------------------------------");

            Console.WriteLine("Users:");
            foreach (User user in userRepo.Users)
                Console.WriteLine(user);
            Console.WriteLine("-------------------------------------------------------------------------------------");

            Console.WriteLine("Bosses:");
            foreach (Boss boss in bossRepo.Bosses)
                Console.WriteLine(boss);
            Console.WriteLine("-------------------------------------------------------------------------------------");

            Console.WriteLine("Tag Users:");
            foreach (TagUser tagUser in tagUserRepo.TagUsers)
                Console.WriteLine(tagUser);
            Console.WriteLine("-------------------------------------------------------------------------------------");
        }
    }
}
