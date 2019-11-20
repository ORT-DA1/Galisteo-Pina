using Data;
using Entities;
using System.Data.Entity;


namespace BusinessLogic
{
    public enum Enviroment
    {
        TEST,
        DEVELOP
    }

    public class ParkingSystemInitializer
    {


        public static IUnitOfWork GetUnitOfWorkToInject(Enviroment enviroment)
        {
            if (enviroment == Enviroment.TEST)
                return new UnitOfWork(new ParkingContext("ParkingContextTest", new DropCreateDatabaseAlways<ParkingContext>()));
            return new UnitOfWork(new ParkingContext("ParkingContext", new DropCreateDatabaseIfModelChanges<ParkingContext>()));
        }

    }
}
