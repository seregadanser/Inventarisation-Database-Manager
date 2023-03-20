using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Models.DBModels;
using DB_course.Repositories;
using DB_course.Models;
using Xunit;
using Moq;
using DB_course.Repositories.DBRepository;

namespace DB_course.Tests
{
    public class UnLoginTests
    {
        [Fact]
        public void LoginFirst()
        {
            // Arrange
            List<Person> a = new List<Person>();
            a.Add(new Person() { Password = "1234", Login = "vas", NumberOfCome = 0 });
            var ui = new Mock<IUnitOfWork>();
            ui.Setup(a => a.personRepository.Get(It.IsAny<string>())).Returns(a);
            UnLoginModel m = new UnLoginModel(ui.Object);
            // Act
            State ac = m.Check("vas", "1234");
            // Assert
            Assert.Equal(State.FIRST, ac);
        }
        [Fact]
        public void LoginUnsucces()
        {
            // Arrange
            List<Person> a = new List<Person>();
            a.Add(new Person() { Password = "1234", Login = "vas", NumberOfCome = 0 });
            var ui = new Mock<IUnitOfWork>();
            ui.Setup(a => a.personRepository.Get(It.IsAny<string>())).Returns(a);
            UnLoginModel m = new UnLoginModel(ui.Object);
            // Act
            State ac = m.Check("vas", "134");
            // Assert
            Assert.Equal(State.INVALID, ac);
        }
        [Fact]
        public void LoginNotFound()
        {
            // Arrange
            var ui = new Mock<IUnitOfWork>();
            ui.Setup(a => a.personRepository.Get(It.IsAny<string>())).Returns(new List<Person>());
            UnLoginModel m = new UnLoginModel(ui.Object);
            // Act
            Action act = () => m.Check("vas", "134");
            // Assert
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Person not found", exception.Message);
        }
    }


    public class AHRAdminModelTests
    {
        [Fact]
        public void AddPerson_ValidPerson_CreatesPerson()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork =  new Mock<IUnitOfWork>(); 

            AHRAdminModel adminModel = new HRAdminModel(mockUnitOfWork.Object); 

            var person = new Person { Name = "John", SecondName = "Doe", Position = "Developer", DateOfBirthday = new DateTime(1985, 1, 1) };

            // Act
            Action act = () => adminModel.AddPerson(person);

            // Assert
           Assert.Throws<ValidationExeption>(act);
 

        }

        [Fact]
        public void RemovePerson_ExistingId_DeletesPerson()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.Setup(a => a.personRepository).Returns(new Mock<IRepository<Person>>().Object);

            AHRAdminModel adminModel = new HRAdminModel(mockUnitOfWork.Object);

            var existingId = "123";

            // Act
            adminModel.RemovePerson(existingId);

            // Assert
            mockUnitOfWork.Verify(x => x.personRepository.Delete(existingId), Times.Once);
            mockUnitOfWork.Verify(x => x.personRepository.Save(), Times.Once);
        }

        //[Fact]
        //public void UpdatePerson_ExistingIdAndValidPerson_UpdatesPerson()
        //{
        //    // Arrange
        //    var existingId = "123";
        //    var updatedPerson = new Person { Name = "Jane", SecondName = "Doe", Position = "Manager", DateOfBirthday = new DateTime(1990, 1, 1) };
        //    mockUnitOfWork.Object.PersonRepository.Setup(x => x.Get(existingId)).Returns(new[] { new Person { Id = existingId, Name = "John", SecondName = "Doe", Position = "Developer", DateOfBirthday = new DateTime(1985, 1, 1) } });

        //    // Act
        //    adminModel.UpdatePerson(existingId, updatedPerson);

        //    // Assert
        //    mockUnitOfWork.Object.PersonRepository.Verify(x => x.Update(It.IsAny<Person>()), Times.Once);
        //    mockUnitOfWork.Object.PersonRepository.Verify(x => x.Save(), Times.Once);
        //}

    }
}
