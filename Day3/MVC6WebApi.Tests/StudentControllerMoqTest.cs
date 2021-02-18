using System;
using System.Collections.Generic;
using System.Text;
using MVC6WebApi.Models;
using MVC6WebApi.Controllers;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace MVC6WebApi.Tests
{
    public class StudentControllerMoqTest
    {
        private Mock<IStudentService> studentservice;

        public StudentControllerMoqTest()
        {
            studentservice = new Mock<IStudentService>();
        }

        public StudentController Subject()
        {
            return new StudentController(studentservice.Object);
        }

        [Fact]
        public void Test_AllStudents_data()
        {
            var service = Subject();
            studentservice.Setup(r => r.GetAllStudents()).Returns(
                new List<Student>
                {
                    new Student{ Name="VS", City="Ahmd"},
                    new Student{ Name="VP", City="Bharuch"},
                    new Student{ Name="RP", City="Surat"}
                });

            var Result = service.GetStudents() as List<Student>;
            var items = Assert.IsType<List<Models.Student>>(Result);
            //items.Should().NotBeEmpty();    // True
            //items.Should().BeOfType<List<Student>>("because a is set collection"); // T
            //Assert.Equal(3, items.Count);   // True
            //items.Should().HaveCount(c => c > 2).And.OnlyHaveUniqueItems(x => x.City); // T

            items.Should().SatisfyRespectively(
                first =>
                {
                    first.Sid.Should().Be(1);
                    first.Name.Should().StartWith("v");
                    first.City.Should().NotBeNull();
                },
                second =>
                {
                    second.Sid.Should().Be(2);
                    second.Name.Should().StartWith("p");
                    second.Class.Should().BeGreaterOrEqualTo(2);
                }
                );
        }
    }
}
