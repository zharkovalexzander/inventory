using UnityEngine;
using System.Collections;
using System;

public class StatPlayer : MonoBehaviour {
    private StatsCollection stats;

	// Use this for initialization
	void Start () {
        stats = new StatForHum();

        var statTypes = Enum.GetValues(typeof(StatType));
        foreach(var statType in statTypes)
        {
            Stat stat = stats.GetStat((StatType)statType);
            if(stat != null)
                Debug.Log(String.Format("{0} : {1}", stat.StatName, stat.StatValue));
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
