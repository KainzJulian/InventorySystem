using System;
using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

// das item was man aufhebt sollte ein interface sein welches die Daten zurückliefert die man braucht
// für die verschiedenen slots

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public Item currentItem;

    public GameObject itemDisplayPrefab;

    public bool isEmpty => currentItem == null;

    public bool setItem(Item item)
    {
        if (!isEmpty)
            return false;

        currentItem = item;
        updateData();
        return true;
    }

    public bool removeItem()
    {
        if (isEmpty)
            return false;

        currentItem = null;
        updateData();
        return true;
    }

    [Button("test setItem")]
    public void _testSetItem() => testSetItem();

    private void testSetItem()
    {
        setItem(GetComponentInChildren<Item>());
    }

    private void Start()
    {
        setItem(GetComponentInChildren<Item>());
    }

    public void updateData()
    {
        currentItem?.text?.SetText(currentItem.itemData.name);
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

        draggableItem.parentAfterDrag = transform;




        Instantiate(itemDisplayPrefab, transform);
    }

}
