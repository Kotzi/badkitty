using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public PlayerController PlayerController;
    public GameController GameController;
    public float distance_to_open = 3f;

    void Update()
    {
        float distance_to_player = (gameObject.transform.position - PlayerController.gameObject.transform.position).magnitude;
        //Debug.Log("distance_to_player: " + distance_to_player);
        if (Input.GetKeyDown(KeyCode.E) && distance_to_player < distance_to_open)
        {
            bool all_items_grabbed = true;
            for (int i = 0; i < PlayerController.grabbed_items.Length; i++)
                if (!PlayerController.grabbed_items[i])
                {
                    all_items_grabbed = false;
                    break;
                }

            if (!all_items_grabbed)
                Debug.Log("You have not found all your necessary stuff yet!");
            else
            {
                Debug.Log("You managed to grab all your stuff in time!");
                GameController.DoorOpened();
            }
        }
    }
}
