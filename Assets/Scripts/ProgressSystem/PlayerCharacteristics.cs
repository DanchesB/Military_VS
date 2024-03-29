﻿public class PlayerCharacteristics : BaseCharacteristics
{
    public Stat Hp { get; private set; }
    public Stat Armour { get; private set; }
    public Stat MoveSpeed { get; private set; }
    public Stat Luck { get; private set; }



    public PlayerCharacteristics(PlayerSO playerStats)
    {
        Hp = new(playerStats.Hp);
        Armour = new(playerStats.Armour);
        MoveSpeed = new(playerStats.MoveSpeed);
        Luck = new(playerStats.Luck);
    }

    public override void DebuffAll()
    {
        Hp.RemoveAllModifiers();
        Armour.RemoveAllModifiers();
        MoveSpeed.RemoveAllModifiers();
        Luck.RemoveAllModifiers();
    }
}
