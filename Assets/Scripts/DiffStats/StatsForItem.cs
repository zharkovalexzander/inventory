using UnityEngine;
using System.Collections;

public class StatsForItem : StatsCollection {
    public override void AssignStats()
    {
        System.Random rd = new System.Random();

        Stat health = CreateGet(StatType.Health);
        health.StatName = "Health";
        health.StatValue = rd.Next(20, 101);

        Stat Armor = CreateGet(StatType.Armor);
        Armor.StatName = "Armor";
        Armor.StatValue = rd.Next(5, 51);

        Stat strength = CreateGet(StatType.Strength);
        strength.StatName = "Strength";
        strength.StatValue = rd.Next(1, 11);
    }
}
