using AutoFixture;
using EMS.Controllers;
using EMS.Interface;
using EMS.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using TEMS_UnitTesting;

namespace EMS_UnitTesting.Controller
{
    public class EmployeeControllerTest : ApiUnitTest<EmployeeController>
    {
        private Mock<IEmployeeRepository> mockEmployeeRepository;
        public override void TestSetup()
        {
            mockEmployeeRepository = this.CreateAndInjectMock<IEmployeeRepository>();
            Target = new EmployeeController(mockEmployeeRepository.Object);
        }

        public override void TestTearDown()
        {
            mockEmployeeRepository.VerifyAll();
        }

        [Fact]
        public void GetEmployeeDetailById_Ok()
        {
            //Arrange
            var id = Fixture.Create<int>();
            var emp = Fixture.Create<Employee>();
            emp.Id = id;
            this.mockEmployeeRepository.Setup(c => c.GetEmployeeDetailById(id)).Returns(emp);

            //Act
            var result = Target.GetEmployeeDetailById(id) as ObjectResult;

            //Assert
            Assert.Equal(emp, result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            this.mockEmployeeRepository.Verify(m => m.GetEmployeeDetailById(id), Times.Once);
        }

        [Fact]
        public void GetEmployeeDetailById_NotFound()
        {
            //Arrange
            Employee emp = null;
            var id = Fixture.Create<int>();
            this.mockEmployeeRepository.Setup(c => c.GetEmployeeDetailById(id)).Returns(emp);

            //Act
            var result = Target.GetEmployeeDetailById(id) as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            this.mockEmployeeRepository.Verify(m => m.GetEmployeeDetailById(id), Times.Once);
        }

        [Fact]
        public void GetActiveEmployee_Ok()
        {
            //Arrange
            var emp = Fixture.Create<List<Employee>>();
            this.mockEmployeeRepository.Setup(c => c.GetActiveEmployee()).Returns(emp);

            //Act
            var result = Target.GetActiveEmployee() as ObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(emp, result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            this.mockEmployeeRepository.Verify(m => m.GetActiveEmployee(), Times.Once);
        }

        [Fact]
        public void GetActiveEmployee_NotFound()
        {
            //Arrange
            List<Employee> emp = null;
            this.mockEmployeeRepository.Setup(c => c.GetActiveEmployee()).Returns(emp);

            //Act
            var result = Target.GetActiveEmployee() as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            this.mockEmployeeRepository.Verify(m => m.GetActiveEmployee(), Times.Once);
        }

        [Fact]
        public void DeleteEmployee_Ok()
        {
            //Arrange
            var id = Fixture.Create<int>();
            var emp = Fixture.Create<Employee>();
            emp.Id = id;
            this.mockEmployeeRepository.Setup(c => c.DeleteEmployee(id)).Returns(emp);

            //Act
            var result = Target.DeleteEmployee(id);

            //Assert
            Assert.NotNull(result);
            this.mockEmployeeRepository.Verify(m => m.DeleteEmployee(id), Times.Once);
        }

        [Fact]
        public void DeleteEmployee_NotFound()
        {
            //Arrange
            var id = Fixture.Create<int>();
            Employee emp = null;
            this.mockEmployeeRepository.Setup(c => c.DeleteEmployee(id)).Returns(emp);

            //Act
            var result = Target.DeleteEmployee(id) as StatusCodeResult;
            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            this.mockEmployeeRepository.Verify(m => m.DeleteEmployee(id), Times.Once);
        }

        [Fact]
        public void UpdateEmployeeDetail_Ok()
        {
            //var id = Fixture.Create<int>();
            var emp = Fixture.Create<Employee>();
            //emp.Id = id;
            //this.mockEmployeeRepository.Setup(c => c.GetEmployeeDetailById(id)).Returns(emp);
            this.mockEmployeeRepository.Setup(c => c.UpdateEmployeeDetail(emp)).Returns(emp);

            //Act
            var result = Target.UpdateEmployeeDetail(emp) as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            //mockEmployeeRepository.Verify(c => c.GetEmployeeDetailById(id), Times.Once);
            mockEmployeeRepository.Verify(c => c.UpdateEmployeeDetail(emp), Times.Once);
        }

        [Fact]
        public void UpdateEmployeeDetail_NotFound()
        {
            //Arrange
            Employee emp = null;

            //Act
            var result = Target.UpdateEmployeeDetail(emp) as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public void CreateEmployeeDetail_Ok()
        {
            var emp = Fixture.Create<Employee>();
            this.mockEmployeeRepository.Setup(c => c.CreateEmployeeDetail(emp)).Returns(emp);

            //Act
            var result = Target.CreateEmployeeDetail(emp) as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.True(result.Value != null && result.Value is Employee);
            mockEmployeeRepository.Verify(c => c.CreateEmployeeDetail(emp), Times.Once);
        }

        [Fact]
        public void CreateEmployeeDetail_NotFound()
        {
            //Arrange
            Employee emp = null;

            //Act
            var result = Target.CreateEmployeeDetail(emp) as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}
