using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandle : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public static GameObject DraggedItem;
    Vector3 StartPosition;
    Transform StartParent;

    #region IBeginDragHandler implementation

    public void OnBeginDrag(PointerEventData eventData)
    {
        DraggedItem = gameObject;
        StartPosition = transform.position;
        StartParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    #endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    #endregion

    #region IEndDragHandler implementation

    public void OnEndDrag(PointerEventData eventData)
    {
        DraggedItem = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == StartParent)
        {
            transform.position = StartPosition;
        }
    }

    #endregion
}
