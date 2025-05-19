using D20Tools.Lib.Core.Interfaces;
using D20Tools.Lib.Core.Services;

namespace D20.Test.Core.Services;

public class DiceRollerShould
{
    [Theory]
    [InlineData(1, 6)]
    [InlineData(1, 20)]
    [InlineData(1, 4)]
    [InlineData(2, 6)]
    public void ReturnValuesWithinDiceRange(int diceCount, int diceSides)
    {
        IDiceRoller diceRoller = new DiceRoller();
        int minimumPossibleRoll = diceCount * 1;
        int maximumPossibleRoll = diceCount * diceSides;
        
        int result = diceRoller.Roll(diceCount, diceSides);
        
        Assert.InRange(result, minimumPossibleRoll, maximumPossibleRoll);
    }
    
    [Theory]
    [InlineData(0, 6)]
    [InlineData(-1, 6)]
    public void ThrowExceptionForInvalidDiceCount(int diceCount, int diceSides)
    {
        IDiceRoller diceRoller = new DiceRoller();
        
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => diceRoller.Roll(diceCount, diceSides));
        
        Assert.Equal("diceCount", exception.ParamName);
        Assert.Contains("Number of dice must be greater than 0", exception.Message);
    }
    
    [Theory]
    [InlineData(1, 0)]
    [InlineData(1, -1)]
    public void ThrowExceptionForInvalidDiceSides(int diceCount, int diceSides)
    {
        IDiceRoller diceRoller = new DiceRoller();
        
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => diceRoller.Roll(diceCount, diceSides));
        
        Assert.Equal("diceSides", exception.ParamName);
        Assert.Contains("Number of sides must be greater than 0", exception.Message);
    }
    
    [Theory]
    [InlineData(10001, 6)]
    public void ThrowExceptionForDiceCountExceedingUpperLimit(int diceCount, int diceSides)
    {
        IDiceRoller diceRoller = new DiceRoller();
        
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => diceRoller.Roll(diceCount, diceSides));
        
        Assert.Equal("diceCount", exception.ParamName);
        Assert.Contains("Number of dice rolled cannot exceed 10,000", exception.Message);
    }
    
    [Theory]
    [InlineData(1, 10001)]
    public void ThrowExceptionForDiceSidesExceedingUpperLimit(int diceCount, int diceSides)
    {
        IDiceRoller diceRoller = new DiceRoller();
        
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => diceRoller.Roll(diceCount, diceSides));
        
        Assert.Equal("diceSides", exception.ParamName);
        Assert.Contains("Number of sides must be less than 10,000", exception.Message);
    }
    
}