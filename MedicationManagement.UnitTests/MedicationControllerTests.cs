using FakeItEasy;
using MedicationManagement.Controllers;
using MedicationManagement.DataAccess.Repository;
using MedicationManagement.DataAccess.Repository.IRepository;
using MedicationManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicationManagement.UnitTests
{
    public class MedicationControllerTests
    {
        MedicationController _medicationController;
        IUnitOfWork mockUnitOfWork;
        [SetUp]
        public void Setup()
        {
            mockUnitOfWork = A.Fake<IUnitOfWork>();
            _medicationController = new MedicationController(mockUnitOfWork);
        }

        [Test]
        public async Task GetAll_ReturnsOkResult()
        {
            //Arrange
            var mockData = A.CollectionOfDummy<Medication>(5).AsEnumerable();
            A.CallTo(() => mockUnitOfWork.MedicationRepository.GetAll(null)).Returns(Task.FromResult(mockData));

            //Act
            IActionResult actionResult = await _medicationController.GetAll();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(actionResult as OkObjectResult);
        }

        [Test]
        public async Task GetAll_ReturnsAllItems()
        {
            //Arrange
            var mockData = A.CollectionOfDummy<Medication>(5).AsEnumerable();
            A.CallTo(() => mockUnitOfWork.MedicationRepository.GetAll(null)).Returns(Task.FromResult(mockData));

            //Act
            IActionResult actionResult = await _medicationController.GetAll();

            //Assert
            var result = actionResult as OkObjectResult;
            var medication = result.Value as IEnumerable<Medication>;
            Assert.AreEqual(medication, mockData);
        }

        [Test]
        public async Task EmptyGetAll_ReturnsEmpty()
        {
            //Arrange
            var mockData = A.CollectionOfDummy<Medication>(0).AsEnumerable();
            A.CallTo(() => mockUnitOfWork.MedicationRepository.GetAll(null)).Returns(Task.FromResult(mockData));

            //Act
            IActionResult actionResult = await _medicationController.GetAll();

            //Assert
            var result = actionResult as OkObjectResult;
            var medication = result.Value as IEnumerable<Medication>;
            Assert.AreEqual(medication, mockData);
        }
    }
}