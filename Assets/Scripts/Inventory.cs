using System;
using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject hotbarGO;
    public GameObject armorSlotsGO;
    public GameObject itemSlotsGO;
    public GameObject weaponSlotsGO;

    public List<ItemSlot> hotbar = new();
    public List<ItemSlot> armorSlots = new();
    public List<ItemSlot> itemSlots = new();
    public List<ItemSlot> weaponSlots = new();

    [Button("Test InitializeItemSlotList")]
    public void _testInitItemSlotList() => testInitItemSlotList();

    private void testInitItemSlotList()
    {
        hotbar.Clear();
        armorSlots.Clear();
        itemSlots.Clear();
        weaponSlots.Clear();

        initializeItemSlotList(hotbar, hotbarGO);
        initializeItemSlotList(armorSlots, armorSlotsGO);
        initializeItemSlotList(itemSlots, itemSlotsGO);
        initializeItemSlotList(weaponSlots, weaponSlotsGO);
    }

    void Start()
    {
        initializeItemSlotList(hotbar, hotbarGO);
        initializeItemSlotList(armorSlots, armorSlotsGO);
        initializeItemSlotList(itemSlots, itemSlotsGO);
        initializeItemSlotList(weaponSlots, weaponSlotsGO);
    }

    public void initializeItemSlotList(List<ItemSlot> itemSlots, GameObject gameObject)
    {
        foreach (ItemSlot itemSlot in gameObject.GetComponentsInChildren<ItemSlot>())
        {
            itemSlots.Add(itemSlot);
        }
    }
}