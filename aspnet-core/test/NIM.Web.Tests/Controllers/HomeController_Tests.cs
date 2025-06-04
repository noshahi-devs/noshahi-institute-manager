using NIM.Models.TokenAuth;
using NIM.Web.Controllers;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace NIM.Web.Tests.Controllers;

public class HomeController_Tests : NIMWebTestBase
{
    [Fact]
    public async Task Index_Test()
    {
        await AuthenticateAsync(null, new AuthenticateModel
        {
            UserNameOrEmailAddress = "admin",
            Password = "123qwe"
        });

        //Act
        var response = await GetResponseAsStringAsync(
            GetUrl<HomeController>(nameof(HomeController.Index))
        );

        //Assert
        response.ShouldNotBeNullOrEmpty();
    }
}