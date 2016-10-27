using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class StatPlayer : MonoBehaviour {
    private StatsCollection stats;
    [SerializeField] Text HealthText;
    [SerializeField] Text ArmorText;
    [SerializeField] Text StrengthText;
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
        stats = new StatForHum();
        _health = stats.GetStat(StatType.Health);
        _armor = stats.GetStat(StatType.Armor);
        _strength = stats.GetStat(StatType.Strength);
        var statTypes = Enum.GetValues(typeof(StatType));
        foreach(var statType in statTypes)
        {
            Stat stat = stats.GetStat((StatType)statType);
            if (stat != null)
            {
                if (stat.StatName == "Health")
                { HealthText.text = stat.StatValue.ToString(); }
                else
                {
                    if (stat.StatName == "Armor")
                    { ArmorText.text = stat.StatValue.ToString(); }
                    else
                    { StrengthText.text = stat.StatValue.ToString(); }
                }
            }
                
        }
	}

    public Stat GetStat(int stat)
    {
        if (stats == null) return null;
        Stat stater = new Stat();
        switch (stat)
        {
            case 1: stater = stats.GetStat(StatType.Health); return stater;
            case 2: stater = stats.GetStat(StatType.Armor); return stater;
            case 3: stater = stats.GetStat(StatType.Strength); return stater;
        }
        return null;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
