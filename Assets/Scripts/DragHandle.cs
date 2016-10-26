using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandle : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public static GameObject DraggedItem;
    Vector3 StartPosition;
    Transform StartParent;
    [SerializeField]
    Text maininfo;
    [SerializeField]
    Text HealthText;
    [SerializeField]
    Text ArmorText;
    [SerializeField]
    Text StrText;

    #region IBeginDragHandler implementation

    public void OnBeginDrag(PointerEventData eventData)
    {
        DraggedItem = gameObject;
        StartPosition = transform.position;
        StartParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        maininfo.text = DraggedItem.name;
        HealthText.text = "Health : " + DraggedItem.GetComponent<StatItem>().HealthValue.ToString();
        ArmorText.text = "Armor : " + DraggedItem.GetComponent<StatItem>().ArmorValue.ToString();
        StrText.text = "Strength : " +  DraggedItem.GetComponent<StatItem>().StrengthValue.ToString();
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
        maininfo.text = string.Empty;
        HealthText.text = string.Empty;
        ArmorText.text = string.Empty;
        StrText.text = string.Empty;
    }

    #endregion
}
