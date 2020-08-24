using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReliableCarDealership.Data;
using ReliableCarDealership.Models;
using ReliableCarDealership.Services;

namespace ReliableCarDealership.Controllers
{
    public class TestDriveController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly ITestDriveService testDriveService;

        public TestDriveController(AppDbContext appDbContext, ITestDriveService testDriveService)
        {
            this.appDbContext = appDbContext;
            this.testDriveService = testDriveService;
        }

        public IActionResult TestDrive()
        {
            //use current user's ID to get testdrive
            var testDrive = testDriveService.GetTestDriveByUserId("00000000-0000-0000-0000-000000000000");           
            return View(testDrive);
        }

        public IActionResult AddtoTestDrive(int carId)
        {
            testDriveService.AddToTestDrive(carId);
            return RedirectToAction("TestDrive");
        }
        public IActionResult Delete (int carId)
        {
            testDriveService.Delete (carId);
            return RedirectToAction("TestDrive");
        }
    }
}
