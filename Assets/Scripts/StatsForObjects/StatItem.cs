using UnityEngine;
using System.Collections;
using System;

public class StatItem : MonoBehaviour {
    private StatsCollection stats;
    private Stat _health;
    private Stat _armor;
    private Stat _strength;
    public int HealthValue
    { 
        get
        {
            return _health.StatValue;
        }
    }
    public int ArmorValue
    {
        get
        {
            return _armor.StatValue;
        }
    }
    public int StrengthValue
    {
        get
        {
            return _strength.StatValue;
        }
    }
	// Use this for initialization
	void Start () {

        stats = new StatsForItem();
        _health = stats.GetStat(StatType.Health);
        _armor = stats.GetStat(StatType.Armor);
        _strength = stats.GetStat(StatType.Strength);

	}

	// Update is called once per frame
	void Update () {
	
	}
}
