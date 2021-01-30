using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    FACE_MASK = 0,
    HOME_KEYS,
    CAR_KEY,
    WALLET,
    N_TYPES
}

public class Item : MonoBehaviour
{
    private string[] item_names = new string[] { "face mask", "home keys", "car key", "wallet" };
    public ItemType item_type;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string ItemName()
    {
        //Debug.Log("item_type: " + item_type);
        return item_names[(int)item_type];
    }

    public void Grab()
    {
        Debug.Log("You found the " + ItemName() + "!");
    }
}
