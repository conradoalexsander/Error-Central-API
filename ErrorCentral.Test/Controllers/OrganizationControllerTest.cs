using ErrorCentral.API.Controllers;
using ErrorCentral.Application.DTOs;
using ErrorCentral.Test.Tools;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ErrorCentral.Test.Application
{
    public class OrganizationControllerTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Be_Ok_When_Get_By_Id(int id)
        {
            var fakes = new FakeContext();
            var fakeService = fakes.FakeOrganizationService().Object;
            var fakeErrorService = fakes.FakeErrorService().Object;
            var expected = fakes.Mapper.Map<OrganizationDTO>(fakeService.SelectById(id));

            var controller = new OrganizationController(fakeService, fakeErrorService);
            var result = controller.Get(id).Result;

            _ = Assert.IsAssignableFrom<OkObjectResult>(result);
            var actual = (result as OkObjectResult).Value as OrganizationDTO;

            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new OrganizationDTOIdComparer());
        }
    }
}