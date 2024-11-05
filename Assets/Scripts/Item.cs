using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemData;

    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setItem(ItemData itemData)
    {
        if (itemData == null)
            removeItem();
        else
            this.itemData = itemData;
    }

    public void setItem(Item item)
    {
        if (item == null)
            removeItem();
        else
            itemData = item.itemData;
    }

    public void removeItem()
    {
        this.itemData = null;
    }
}
