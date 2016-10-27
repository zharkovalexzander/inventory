using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Slots : MonoBehaviour, IDropHandler {
    [SerializeField]
    Text a;
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0) 
            { 
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    #region IDropHandler implementation

    public void OnDrop(PointerEventData eventData)
    {
        if(!item)
        {
            DragHandle.DraggedItem.transform.SetParent(transform);
            ExecuteEvents.ExecuteHierarchy<IChanged>(gameObject, null, (x, y) => x.Changed());
        }
        else
        {
            if ((item.transform.GetChild(0).transform.name != DragHandle.DraggedItem.transform.GetChild(0).transform.name && item.transform.parent.transform.name.IndexOf("Panel") == -1) || (item.transform.GetChild(0).transform.name != DragHandle.DraggedItem.transform.GetChild(0).transform.name && DragHandle.DraggedItem.transform.parent.transform.name.IndexOf("Panel") == -1))
            {

            }
            else
            {
                Transform parent = item.transform.parent;
                item.transform.SetParent(DragHandle.DraggedItem.transform.parent);
                DragHandle.DraggedItem.transform.SetParent(transform);
                ExecuteEvents.ExecuteHierarchy<IChanged>(gameObject, null, (x, y) => x.Changed());
            }
        }
    }

    #endregion
}
