using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    private const float distance_to_grab = 2.15f;
    private const float distance_to_shake = 3f;

    public int Item_Container_ID = 0;
    public Item item;

    public GameObject player;
    public PlayerController player_controller;

    // Start is called before the first frame update
    void Start()
    {
        player_controller = Object.FindObjectOfType<PlayerController>();
        player = player_controller.gameObject;        
    }

    // Update is called once per frame
    void Update()
    {
        float distance_to_player = (gameObject.transform.position - player.transform.position).magnitude;
        if (item != null && distance_to_player < distance_to_shake)
        {
            player_controller.IsCloseTo(item.item_type, distance_to_player);
        }
        
        if (Input.GetKeyDown(KeyCode.E) && distance_to_player < distance_to_grab)
        {
            if (item != null)
            {
                item.Grab();
                player_controller.GrabItem(item.item_type);
                item = null;
            }
            else
                Debug.Log("There is nothing here!");
        }
    }
}