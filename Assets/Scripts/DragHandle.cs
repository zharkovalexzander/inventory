using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandle : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public static GameObject DraggedItem;
    private Transform _trabs;
    public bool pointer;
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
    [SerializeField]
    Transform Ventory;
    [SerializeField]
    Transform Player;

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
        _trabs = transform;
        pointer = true;
        if (DraggedItem.transform.parent.transform.parent.transform.name == "Ventory")
        {
            Ventory.transform.SetSiblingIndex(4);
            Player.transform.SetSiblingIndex(3);
            int DraggedItemIndex = DraggedItem.transform.parent.transform.GetSiblingIndex();
            Vector3 pso = Ventory.transform.GetChild(11).transform.position;
            Ventory.transform.GetChild(11).transform.SetSiblingIndex(DraggedItemIndex);
            DraggedItem.transform.parent.transform.SetAsLastSibling();
            StartPosition = pso;
        }
        else
        {
            Ventory.transform.SetSiblingIndex(3);
            Player.transform.SetSiblingIndex(4);
        }
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
            if (transform.parent.name != _trabs.GetChild(0).name && transform.parent.name.IndexOf("Panel") == -1)
            {
                transform.parent = StartParent;
                transform.position = StartPosition;
                pointer = false;
            }
            else
            {
                if (transform.parent == StartParent)
                {
                    transform.position = StartPosition;
                }

                pointer = true;
            }
            maininfo.text = string.Empty;
            HealthText.text = string.Empty;
            ArmorText.text = string.Empty;
            StrText.text = string.Empty;
    }

    #endregion
}
