using RentHouse.Service.Validators.Dtos;

namespace RentHouse.UnitTest.ValidatorTest;

public class PhoneNumberValidatorTest
{
    [Theory]
    [InlineData("+998999222600")]
    [InlineData("+998939222600")]
    [InlineData("+998949222600")]
    [InlineData("+998959222600")]
    [InlineData("+998779222600")]
    [InlineData("+998339222600")]
    [InlineData("+998559222600")]
    
    public void ShouldReturnCorrect(string phone)
    {
        
        var result = PhoneNumberValidator.IsValid(phone);
        Assert.True(result);
    }

    [Theory]
    [InlineData("+9989222600")]
    [InlineData("+9985592226003")]
    [InlineData("+99855922260S")]
    [InlineData("+99855922260!")]
    [InlineData("+99855922 260")]
    [InlineData("-998559222600")]
    [InlineData("+9985E9222600")]
    [InlineData("+9985592226003333")]


    public void ShouldReturnWrong(string phoneS) 
    {
        var result = PhoneNumberValidator.IsValid(phoneS);
        Assert.False(result);
    }
}
