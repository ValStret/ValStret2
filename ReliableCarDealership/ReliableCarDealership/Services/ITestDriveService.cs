using ReliableCarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReliableCarDealership.Services
{
    public interface ITestDriveService
    {
        public TestDrive GetTestDriveById(int Id);
        public TestDrive GetTestDriveByUserId(string userId);
        public TestDrive UpdateTestDriveCar(int carId);
        public TestDriveCar AddToTestDrive(int carId);
        public TestDriveCar Delete (int carId);

    }
}
