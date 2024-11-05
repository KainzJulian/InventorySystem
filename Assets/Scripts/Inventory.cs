using System;
using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int inventorySlots;

    public GameObject itemSlot;

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
            Instantiate(itemSlot, transform);
        }
    }

    public void removeSlots()
    {
        foreach (Transform child in transform)
        {
            if (Application.isPlaying)
                Destroy(child.gameObject);
            else
                DestroyImmediate(child.gameObject);
        }
    }

    public void switchVisibilitySlots(bool state)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(state);
        }
    }
}