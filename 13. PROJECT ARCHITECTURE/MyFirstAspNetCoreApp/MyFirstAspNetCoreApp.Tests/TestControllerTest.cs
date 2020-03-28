using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using MyFirstAspNetCoreApp.Controllers;
using MyFirstAspNetCoreApp.Models;
using MyFirstAspNetCoreApp.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyFirstAspNetCoreApp.Tests
{
    public class TestControllerTest
    {
        [Fact]
        public void TestViewModelForIndexForm()
        {
            var mockService = new Mock<IPositionsService>();
            mockService.Setup(x => x.GetAll()).Returns(new List<SelectListItem>
            {
                new SelectListItem{Value="1",Text="Dev" },
                new SelectListItem{Value="2",Text="QA" },
            });

            var controller = new TestController(mockService.Object);
            //var controller = new TestController(new MockPositionService());
            var result = controller.Index();
            Assert.IsType<PartialViewResult>(result);
            var viewResult = result as PartialViewResult;
            Assert.IsType<TestInputModel>(viewResult.Model);
            var viewModel = viewResult.Model as TestInputModel;
            Assert.Equal(2, viewModel.AllTypes.Count());

            mockService.Verify(x => x.GetAll(), Times.Once);
        }

    }

    //public class MockPositionService : IPositionsService
    //{
    //    IEnumerable<SelectListItem> IPositionsService.GetAll()
    //    {
    //        return new List<SelectListItem>
    //        {
    //            new SelectListItem{Value="1",Text="Dev" },
    //            new SelectListItem{Value="2",Text="QA" },
    //        };
    //    }
    //}
}
