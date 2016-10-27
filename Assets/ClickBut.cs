using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickBut : MonoBehaviour {
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
    private Transform panel;
    [SerializeField]
    Transform ventory;
	// Use this for initialization
	void Start () {
        panel = transform;
	}
	
    public void TransformChilds()
    {
        for(int i = 0; i <= 5; ++i)
        {
            if(transform.GetChild(i).transform.childCount > 0)
            {
                for(int j = 0; j <= 11; ++j)
                {
                    if(ventory.GetChild(j).transform.childCount == 0)
                    {
                        var pos = ventory.position;
                        transform.GetChild(i).transform.GetChild(0).position = pos;
                        transform.GetChild(i).transform.GetChild(0).SetParent(ventory.GetChild(j));
                        CallText();
                        break;
                    }
                }
            }
        }
    }
    private void CallText()
    {
        int hp = player.gameObject.GetComponent<StatPlayer>().HealthValue;
        int ar = player.gameObject.GetComponent<StatPlayer>().ArmorValue;
        int st = player.gameObject.GetComponent<StatPlayer>().StrengthValue;
        foreach (Transform slotTrans in slots)
        {
            GameObject item = slotTrans.GetComponent<Slots>().item;
            if (item == null) continue;
            if (item.transform.parent.name != item.transform.GetChild(0).name) continue;
            hp += item.gameObject.GetComponent<StatItem>().HealthValue;
            ar += item.gameObject.GetComponent<StatItem>().ArmorValue;
            st += item.gameObject.GetComponent<StatItem>().StrengthValue;
        }
        healthText.text = hp.ToString();
        armText.text = ar.ToString();
        strText.text = st.ToString();
    }
}
