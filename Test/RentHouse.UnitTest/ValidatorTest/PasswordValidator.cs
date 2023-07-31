using Microsoft.AspNet.Identity;
using RentHouse.Service.Validators.Dtos;
using RentHouse.Service.Validators.Dtos.Apartments;

namespace RentHouse.UnitTest.ValidatorTest;

public class PasswordValidatorTest
{
    [Theory]
    [InlineData("AAaa@@11")]
    [InlineData("AAaa@@1a")]
    [InlineData("AAaa@@1@")]
    [InlineData("AAadhgdkjfgdkfjgkjda@@1@")]
    [InlineData("AAaa@@1@37938t34iteri")]
    [InlineData("Aaaaaa@@1@")]
    [InlineData("AA1a____")]
    [InlineData("AAaa@111")]
    [InlineData("Aaaa@@11")]
    [InlineData("AAAa@@11")]
    public void ShouldReturnCorrect(string pasword)
    {

        var result = PassWordValidator.IsStrongPassword(pasword);
        Assert.True(result.IsValid);
    }


    [Theory]
    [InlineData("AAaa@@@@")]
    [InlineData("AAaa@@Aa")]
    [InlineData("AAaa@@a@")]
    [InlineData("AAaa@@1")]
    [InlineData("AAaa1111")]
    [InlineData("AA@@1222")]
    [InlineData("aaaa@@11")]
    [InlineData("AAAA")]
    public void ShouldReturnwrong(string pasword)
    {
        var result = PassWordValidator.IsStrongPassword(pasword);
        Assert.False(result.IsValid);
    }
}
