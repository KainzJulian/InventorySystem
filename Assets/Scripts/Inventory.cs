using System;
using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject itemSlotPrefab;

    public int inventorySlots = 10;
    public List<ItemSlot> itemSlots = new List<ItemSlot>();

    [Button("Instantiate Slots")]
    public void _instantiateSlots() => instantiateSlots();

    [Button("Clear Slots")]
    public void _clearSlots() => removeSlots();

    [Button("hide slots")]
    public void _hideSlots() => switchVisibilitySlots(false);

    [Button("show slots")]
    public void _showSlots() => switchVisibilitySlots(true);

    void Start()
    {
        instantiateSlots();
    }

    public void instantiateSlots()
    {
        for (int i = 0; i < inventorySlots; i++)
        {
            GameObject itemSlot = Instantiate(itemSlotPrefab, transform);
            itemSlots.Add(itemSlot.GetComponent<ItemSlot>());
        }
    }

    public void removeSlots()
    {
        foreach (ItemSlot item in itemSlots)
        {
            if (Application.isPlaying)
                Destroy(item.gameObject);
            else
                DestroyImmediate(item.gameObject);
        }

        itemSlots.Clear();
    }

    public void switchVisibilitySlots(bool state)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(state);
        }
    }
}