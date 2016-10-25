using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatsCollection {
    private Dictionary<StatType, Stat> statDict;

    public StatsCollection()
    {
        statDict = new Dictionary<StatType, Stat>();
        AssignStats();
    }

    public virtual void AssignStats()
    {

    }

    public Stat GetStat(StatType statType)
    {
        if(IsContains(statType))
        {
            return statDict[statType];
        }
        return null;
    }

    public bool IsContains(StatType statType)
    {
        return statDict.ContainsKey(statType);
    }

    protected Stat Create(StatType statType)
    {
        Stat stat = new Stat();
        statDict.Add(statType, stat);
        return stat;
    }

    protected Stat CreateGet(StatType statType)
    {
        Stat stat = GetStat(statType);
        if(stat == null)
        {
            stat = Create(statType);
        }
        return stat;
    }
}
