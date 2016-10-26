using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour, IChanged {
    [SerializeField] 
    Transform slots;
    [SerializeField] 
    Text healthText;
    [SerializeField]
    Text armText;
    [SerializeField]
    Text strText;
    [SerializeField]
    Transform player;
	// Use this for initialization
	void Start () { }

    #region IChanged implementation

    public void Changed()
    {
        int hp = player.gameObject.GetComponent<StatPlayer>().HealthValue;
        int ar = player.gameObject.GetComponent<StatPlayer>().ArmorValue;
        int st = player.gameObject.GetComponent<StatPlayer>().StrengthValue;
        foreach(Transform slotTrans in slots)
        {
            GameObject item = slotTrans.GetComponent<Slots>().item;
            if (item == null) continue;
            hp += item.gameObject.GetComponent<StatItem>().HealthValue;
            ar += item.gameObject.GetComponent<StatItem>().ArmorValue;
            st += item.gameObject.GetComponent<StatItem>().StrengthValue;
        }
        healthText.text = hp.ToString();
        armText.text = ar.ToString();
        strText.text = st.ToString();
    }

    #endregion

}
namespace UnityEngine.EventSystems
{
    public interface IChanged : IEventSystemHandler
    {
        void Changed();
    }
}