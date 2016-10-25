using UnityEngine;
using System.Collections;

public class Stat {
    private string statsName;
    private int statsValue;

    public string StatName
    {
        get { return statsName; }
        set { statsName = value; }
    }

    public int StatValue
    {
        get { return statsValue; }
        set { statsValue = value; }
    }

    public Stat() 
    {
        this.statsName = string.Empty;
        this.statsValue = 0;
    }

    public Stat(string name, int value)
    {
        this.statsName = name;
        this.statsValue = value;
    }
}
