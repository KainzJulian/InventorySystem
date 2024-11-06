using EditorAttributes;
using UnityEngine;
using UnityEngine.EventSystems;

// das item was man aufhebt sollte ein interface sein welches die Daten zurückliefert die man braucht
// für die verschiedenen slots

public class ItemSlot : MonoBehaviour, IDropHandler
{

    public GameObject itemDisplayPrefab;

    public bool isEmpty => getCurrentItem == null;

    public Item getCurrentItem => GetComponentInChildren<Item>();

    public void setCurrentItem(Item item)
    {
        item.setItem(item);
    }

    public bool setItem(Item item)
    {
        if (!isEmpty)
            return false;

        getCurrentItem.setItem(item);
        return true;
    }

    public bool removeItem()
    {
        if (isEmpty)
            return false;

        getCurrentItem.setItem(null);

        return true;
    }

    [Button("test setItem")]
    public void _testSetItem() => testSetItem();

    private void testSetItem()
    {
        if (isEmpty)
            Instantiate(itemDisplayPrefab, transform);
    }

    private void Start()
    {
        setItem(GetComponentInChildren<Item>());
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
        Destroy(getCurrentItem);
    }
}
