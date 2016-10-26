using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Slots : MonoBehaviour, IDropHandler {
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
    }

    #endregion
}
