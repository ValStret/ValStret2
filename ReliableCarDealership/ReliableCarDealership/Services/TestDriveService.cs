using Microsoft.EntityFrameworkCore;
using ReliableCarDealership.Data;
using ReliableCarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReliableCarDealership.Services
{
    public class TestDriveService : ITestDriveService
    {
        private readonly AppDbContext dbContext;

        public TestDriveService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public TestDrive GetTestDriveById(int Id)
        {
            var testDrive = dbContext.TestDrives
                            .Include(s => s.TestDriveCarsList).ThenInclude(p => p.Car)
                            .FirstOrDefault(m => m.Id == Id);
            return testDrive;
        }

        public TestDrive GetTestDriveByUserId(string userId)
        {
            var testDrive = dbContext.TestDrives
                .Include(s => s.TestDriveCarsList).ThenInclude(p => p.Car)
                            .FirstOrDefault(c => c.UserId == userId);
            return testDrive;
        }

        public TestDrive UpdateTestDriveCar(int carId)
        {
            throw new NotImplementedException();
        }
        public TestDriveCar AddToTestDrive(int carId)
        {
            //code to get the current userId
            var testDrive = GetTestDriveByUserId("00000000-0000-0000-0000-000000000000");
            if (testDrive == null)
            {
                //create new testdrive for current user
                testDrive=CreateTestDrive();
            }

            //Create testdrive car
            TestDriveCar testDriveCar = null;
            if (testDrive.TestDriveCarsList != null)
            {
                testDriveCar = testDrive.TestDriveCarsList.FirstOrDefault(i => i.CarId == carId);
                if (testDriveCar != null)
                {
                    dbContext.Update(testDriveCar);
                    dbContext.SaveChanges();
                }
                else
                {
                    testDriveCar = new TestDriveCar();
                    testDriveCar.CarId = carId;
                    testDriveCar.TestDriveId = testDrive.Id;
                    testDriveCar.TestDriveDate = DateTime.Now;
                    //save ShoppingCatrItem to DB
                    dbContext.Add(testDriveCar);
                    dbContext.SaveChanges();
                }
            }
            return testDriveCar;
        }
        private TestDrive CreateTestDrive()
        {
            var testDrive = new TestDrive();
            testDrive.UserId = Guid.NewGuid().ToString();
            dbContext.Add(testDrive);
            dbContext.SaveChanges();
            return testDrive;
        }

        public TestDriveCar Delete (int carId)
        {
            var testDrive = GetTestDriveByUserId("00000000-0000-0000-0000-000000000000");
            TestDriveCar testDriveCar = null;
            if (testDrive.TestDriveCarsList != null)
            {
                testDriveCar = testDrive.TestDriveCarsList.FirstOrDefault(i => i.CarId == carId);
                {
                    dbContext.Remove(testDriveCar);
                    dbContext.SaveChanges();
                }
            }
            return testDriveCar;
            
        }
    }
}
