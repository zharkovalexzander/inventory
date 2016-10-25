using UnityEngine;
using System.Collections;

public class StatForHum : StatsCollection {
    public override void AssignStats()
    {
        System.Random rd = new System.Random();

        Stat health = CreateGet(StatType.Health);
        health.StatName = "Health";
        health.StatValue = 500;

        Stat Armor = CreateGet(StatType.Armor);
        Armor.StatName = "Armor";
        Armor.StatValue = 0;

        Stat strength = CreateGet(StatType.Strength);
        strength.StatName = "Strength";
        strength.StatValue = rd.Next(1, 11);
    }
}
