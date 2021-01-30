using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject player;
    public PlayerController player_controller;
    public float distance_to_open = 3f;

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
        //Debug.Log("distance_to_player: " + distance_to_player);
        if (Input.GetKeyDown(KeyCode.E) && distance_to_player < distance_to_open)
        {
            bool all_items_grabbed = true;
            for (int i = 0; i < player_controller.grabbed_items.Length; i++)
                if (!player_controller.grabbed_items[i])
                {
                    all_items_grabbed = false;
                    break;
                }

            if (!all_items_grabbed)
                Debug.Log("You have not found all your necessary stuff yet!");
            else
            {
                Debug.Log("You managed to grab all your stuff in time!");
            }
        }
    }
}
