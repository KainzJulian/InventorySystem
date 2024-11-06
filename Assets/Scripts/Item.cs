using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemData;

    public TextMeshProUGUI text;

    private void Start()
    {
        updateData();
    }

    public void setItem(Item item)
    {
        if (item == null)
            removeItem();
        else
            this.itemData = item.itemData;

        updateData();
    }

    public void updateData()
    {
        text?.SetText(itemData.name);
    }

    public void removeItem()
    {
        this.itemData = null;
        updateData();
    }
}
