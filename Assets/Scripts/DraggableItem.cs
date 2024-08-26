using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [SerializeField] List<GameObject> hideOnDrag;
    [SerializeField] List<Image> disableRaycastOnDrag;

    [HideInInspector] public Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;

        foreach (var obj in hideOnDrag)
            obj.SetActive(false);

        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        foreach (var item in disableRaycastOnDrag)
            item.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);

        foreach (var obj in hideOnDrag)
            obj.SetActive(true);

        foreach (var item in disableRaycastOnDrag)
            item.raycastTarget = true;


    }
}
