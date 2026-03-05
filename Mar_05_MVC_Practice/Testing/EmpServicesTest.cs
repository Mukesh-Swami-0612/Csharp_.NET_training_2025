using Moq;
using NUnit.Framework;
using Testing.Models;
using Testing.Repositories;
using Testing.Services;
using System.Collections.Generic;

namespace Testing.Tests
{
    public class EmpServicesTest
    {
        private Mock<IEmpRepositories> _mockRepo;
        private EmpServices _service;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IEmpRepositories>();
            _service = new EmpServices(_mockRepo.Object);
        }

        [Test]
        public void GetEmployeeById_ReturnsEmployee()
        {
            var employee = new Employee
            {
                Id = 1,
                Name = "Mukesh",
                Department = "IT",
                Salary = 50000
            };

            _mockRepo.Setup(r => r.GetId(1)).Returns(employee);

            var result = _service.GetEmployeeById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual("Mukesh", result.Name);
        }

        [Test]
        public void GetAllEmployees_ReturnsEmployeeList()
        {
            var employees = new List<Employee>
            {
                new Employee{ Id=1, Name="Mukesh", Department="IT", Salary=50000 },
                new Employee{ Id=2, Name="Rahul", Department="HR", Salary=45000 }
            };

            _mockRepo.Setup(r => r.GetAll()).Returns(employees);

            var result = _service.GetAllEmployees();

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void AddEmployee_CallsRepositoryAdd()
        {
            var employee = new Employee
            {
                Id = 3,
                Name = "Aman",
                Department = "Finance",
                Salary = 40000
            };

            _service.AddEmployee(employee);

            _mockRepo.Verify(r => r.Add(employee), Times.Once);
        }

        [Test]
        public void UpdateEmployee_CallsRepositoryUpdate()
        {
            var employee = new Employee
            {
                Id = 1,
                Name = "Mukesh Updated",
                Department = "IT",
                Salary = 55000
            };

            _service.UpdateEmployee(employee);

            _mockRepo.Verify(r => r.Update(employee), Times.Once);
        }

        [Test]
        public void DeleteEmployee_CallsRepositoryDelete()
        {
            int id = 1;

            _service.DeleteEmployee(id);

            _mockRepo.Verify(r => r.Delete(id), Times.Once);
        }
    }
}