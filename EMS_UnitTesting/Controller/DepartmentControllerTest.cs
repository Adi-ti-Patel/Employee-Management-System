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
    public  class DepartmentControllerTest : ApiUnitTest<DepartmentController>
    {
        private Mock<IDepartmentRepository> mockDepartmentRepository;
        public override void TestSetup()
        {
            mockDepartmentRepository = this.CreateAndInjectMock<IDepartmentRepository>();
            Target = new DepartmentController(mockDepartmentRepository.Object);
        }

        public override void TestTearDown()
        {
            mockDepartmentRepository.VerifyAll();
        }


        [Fact]
        public void GetDepartments_Ok()
        {
            //Arrange
            //var id = Fixture.Create<int>();
            var dept = Fixture.Create<List<Department>>();
            this.mockDepartmentRepository.Setup(c => c.GetDepartments()).Returns(dept);

            //Act
            var result = Target.GetDepartments() as ObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(dept, result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            this.mockDepartmentRepository.Verify(m => m.GetDepartments(), Times.Once);
        }

        [Fact]
        public void GetDepartments_NotFound()
        {
            //Arrange
            List<Department> dept = null;
            this.mockDepartmentRepository.Setup(c => c.GetDepartments()).Returns(dept);

            //Act
            var result = Target.GetDepartments() as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            //Assert.Equal(product, result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            this.mockDepartmentRepository.Verify(m => m.GetDepartments(), Times.Once);
        }

        [Fact]
        public void GetActiveDepartments_Ok()
        {
            //Arrange
            //var id = Fixture.Create<int>();
            var dept = Fixture.Create<List<Department>>();
            //product.Id = id;
            this.mockDepartmentRepository.Setup(c => c.GetActiveDepartments()).Returns(dept);

            //Act
            var result = Target.GetActiveDepartments() as ObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(dept, result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            this.mockDepartmentRepository.Verify(m => m.GetActiveDepartments(), Times.Once);
        }

        [Fact]
        public void GetActiveDepartments_NotFound()
        {
            //Arrange
            List<Department> dept = null;
            this.mockDepartmentRepository.Setup(c => c.GetActiveDepartments()).Returns(dept);

            //Act
            var result = Target.GetActiveDepartments() as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            //Assert.Equal(product, result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            this.mockDepartmentRepository.Verify(m => m.GetActiveDepartments(), Times.Once);
        }

        [Fact]
        public void GetDepartmentDetailById_Ok()
        {
            //Arrange
            var id = Fixture.Create<int>();
            var dept = Fixture.Create<Department>();
            dept.Id = id;
            this.mockDepartmentRepository.Setup(c => c.GetDepartmentDetailById(id)).Returns(dept);

            //Act
            var result = Target.GetDepartmentDetailById(id) as ObjectResult;

            //Assert
            //Assert.NotNull(result);
            Assert.Equal(dept, result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            this.mockDepartmentRepository.Verify(m => m.GetDepartmentDetailById(id), Times.Once);
        }

        [Fact]
        public void GetDepartmentDetailById_NotFound()
        {
            //Arrange
            Department dept = null;
            var id = Fixture.Create<int>();
            this.mockDepartmentRepository.Setup(c => c.GetDepartmentDetailById(id)).Returns(dept);

            //Act
            var result = Target.GetDepartmentDetailById(id) as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            //Assert.Equal(product, result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            this.mockDepartmentRepository.Verify(m => m.GetDepartmentDetailById(id), Times.Once);
        }

        [Fact]
        public void GetAllEmployeeByDepartment_Ok()
        {
            //Arrange
            var id = Fixture.Create<int>();
            var emp = Fixture.Create<List<Employee>>();
            //emp. = id;
            this.mockDepartmentRepository.Setup(c => c.GetAllEmployeeByDepartment(id)).Returns(emp);

            //Act
            var result = Target.GetAllEmployeeByDepartment(id) as ObjectResult;

            //Assert
            //Assert.NotNull(result);
            Assert.Equal(emp, result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            this.mockDepartmentRepository.Verify(m => m.GetAllEmployeeByDepartment(id), Times.Once);
        }

        [Fact]
        public void GetAllEmployeeByDepartment_NotFound()
        {
            //Arrange
            List<Employee> emp = null;
            var id = Fixture.Create<int>();
            this.mockDepartmentRepository.Setup(c => c.GetAllEmployeeByDepartment(id)).Returns(emp);

            //Act
            var result = Target.GetAllEmployeeByDepartment(id) as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            //Assert.Equal(product, result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            this.mockDepartmentRepository.Verify(m => m.GetAllEmployeeByDepartment(id), Times.Once);
        }

        [Fact]
        public void DeleteDepartment_Ok()
        {
            //Arrange
            var id = Fixture.Create<int>();
            var dept = Fixture.Create<Department>();
            dept.Id = id;
            this.mockDepartmentRepository.Setup(c => c.DeleteDepartment(id)).Returns(dept);

            //Act
            var result = Target.DeleteDepartment(id);

            //Assert
            Assert.NotNull(result);
            this.mockDepartmentRepository.Verify(m => m.DeleteDepartment(id), Times.Once);
        }

        [Fact]
        public void DeleteDepartment_NotFound()
        {
            //Arrange
            var id = Fixture.Create<int>();
            Department dept = null;
            this.mockDepartmentRepository.Setup(c => c.DeleteDepartment(id)).Returns(dept);

            //Act
            var result = Target.DeleteDepartment(id) as StatusCodeResult;
            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            this.mockDepartmentRepository.Verify(m => m.DeleteDepartment(id), Times.Once);
        }
    }
}
