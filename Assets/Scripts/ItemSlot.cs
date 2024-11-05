using EditorAttributes;
using UnityEngine;
using UnityEngine.EventSystems;

// das item was man aufhebt sollte ein interface sein welches die Daten zurückliefert die man braucht
// für die verschiedenen slots

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public Item getCurrentItem()
    {
        return GetComponentInChildren<Item>();
    }

    public void setCurrentItem(Item item)
    {
        GetComponentInChildren<Item>().setItem(item.itemData);
    }

    public GameObject itemDisplayPrefab;

    public bool isEmpty => getCurrentItem() == null;

    public bool setItem(Item item)
    {
        if (!isEmpty)
            return false;

        setCurrentItem(item);
        updateData();
        return true;
    }

    public bool removeItem()
    {
        if (isEmpty)
            return false;

        setCurrentItem(null);
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
        getCurrentItem()?.text?.SetText(getCurrentItem().itemData.name);
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        Item droppedItem = dropped.GetComponent<Item>();

        Debug.LogWarning("help");

        if (transform.childCount != 0)
            return;

        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
        draggableItem.parentAfterDrag = transform;

        // Instantiate(itemDisplayPrefab, transform);
        Debug.Log(droppedItem.name);
        removeItem();
    }
}
