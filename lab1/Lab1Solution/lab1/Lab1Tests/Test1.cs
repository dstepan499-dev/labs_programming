using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Lab1Console;

namespace Lab1Tests
{

    [DoNotParallelize]
    [TestClass]
    public class VehicleTests
    {
        public TestContext TestContext { get; set; }

        private StringWriter _sw;
        private TextWriter _originalOutput;

        [TestInitialize]
        public void TestInitialize()
        {
            _sw = new StringWriter();
            _originalOutput = Console.Out;
            Console.SetOut(_sw);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Console.SetOut(_originalOutput);
            _sw.Dispose();
        }

        [TestMethod]
        public void Vehicle_DisplayInfo_PrintsCorrectMessage()
        {
            var vehicle = new Vehicle("TestVehicle");
            vehicle.DisplayInfo();
            var result = _sw.ToString();
            Assert.AreEqual($"Vehicle: TestVehicle{Environment.NewLine}", result);
        }

        [TestMethod]
        public void ElectricScooter_DisplayInfo_PrintsCorrectMessage()
        {
            var scooter = new ElectricScooter("TestScooter");
            scooter.DisplayInfo();
            var result = _sw.ToString();
            Assert.AreEqual($"Electric Scooter: TestScooter{Environment.NewLine}", result);
        }

        [TestMethod]
        public void Car_DisplayInfo_PrintsCorrectMessage()
        {
            var car = new Car("TestCar");
            car.DisplayInfo();
            var result = _sw.ToString();
            Assert.AreEqual($"Car: TestCar{Environment.NewLine}", result);
        }

        [TestMethod]
        public void VehicleManager_AddVehicle_IncreasesCount()
        {
            var manager = new VehicleManager();
            var vehicle = new Vehicle("TestVehicle");
            manager.AddVehicle(vehicle);
            Assert.AreEqual(1, manager.VehicleCount);
        }

        [TestMethod]
        public void VehicleManager_RemoveVehicle_DecreasesCount()
        {
            var manager = new VehicleManager();
            var vehicle = new Vehicle("TestVehicle");
            manager.AddVehicle(vehicle);
            manager.RemoveVehicle(0);
            Assert.AreEqual(0, manager.VehicleCount);
        }

        [TestMethod]
        public void VehicleManager_DisplayAllVehicles_ShowsAllVehicles()
        {
            var manager = new VehicleManager();
            manager.AddVehicle(new ElectricScooter("Xiaomi M365"));
            manager.AddVehicle(new Car("Tesla Model 3"));
            manager.DisplayAllVehicles();
            var result = _sw.ToString();

            string expectedOutput = $"Electric Scooter: Xiaomi M365{Environment.NewLine}" +
                                    $"Car: Tesla Model 3{Environment.NewLine}";

            Assert.AreEqual(expectedOutput, result);
        }
    }
}
