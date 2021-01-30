using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    void Start()
    {
        AddItems();
    }

    public void AddItems()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        GameObject[] item_containers = GameObject.FindGameObjectsWithTag("ItemContainer");

        int n_items = items.Length;
        int n_item_containers = item_containers.Length;
        List<int> item_containers_with_item = new List<int>();
        for (int i = 0; i < n_items; i++)
        {
            int rand;
            do
            {
                rand = Random.Range(0, n_item_containers);
            }
            while (item_containers_with_item.Contains(rand));

            item_containers_with_item.Add(rand);
            Item item = items[i].GetComponent<Item>();
            item.item_type = (ItemType)i;
            item_containers[rand].GetComponent<ItemContainer>().item = item;
            Debug.Log("Placing item type " + (ItemType)i + " into item container " + item_containers[rand].name);
        }
    }
}
