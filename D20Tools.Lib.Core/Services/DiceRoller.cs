using D20Tools.Lib.Core.Interfaces;

namespace D20Tools.Lib.Core.Services;

public class DiceRoller : IDiceRoller
{
    private static readonly Random Random = new();
    
    public int Roll(int diceCount, int diceSides)
    {
        if (diceCount > 10000) throw new ArgumentOutOfRangeException(nameof(diceCount), "Number of dice rolled cannot exceed 10,000");
        if (diceCount <= 0) throw new ArgumentOutOfRangeException(nameof(diceCount), "Number of dice must be greater than 0");
        if (diceSides <= 0) throw new ArgumentOutOfRangeException(nameof(diceSides), "Number of sides must be greater than 0");
        
        int total = 0;
        
        for (int i = 0; i < diceCount; i++)
        {
            total += Random.Next(1, diceSides + 1);
        }
        return total;
    }
}