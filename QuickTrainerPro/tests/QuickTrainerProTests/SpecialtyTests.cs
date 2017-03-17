using System.Collections.Generic;
using Xunit;
using System.Linq;
using TermProject.Controllers;
using TermProject.Models;

namespace QuickTrainerProTests
{
    public class SpecialtyTests
    {
        [Fact]
        public void CanGetSpecialties()
        {
            //Arrange
            FakeSpecialtyRepository repo = new FakeSpecialtyRepository();
            HomeController controller = new HomeController(repo);

            //Act
            var specialties = controller.Specialties().ViewData.Model as List<Specialty>;

            //Assert
            Assert.Equal(repo.GetAllSpecialties().ToList()[0].Name,
               specialties[0].Name);
        }
    }
}
