using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    const float MinOrthographicSize = 1.2f;
    const float MaxOrthographicSize = 2f;
    const float Velocity = 3f;
    const float StillThreshold = 1f;
    private float StillTimer = 0f;

    public CameraController Camera;
    public GameController GameController;
    private float dx, dy;
    private bool isMoving = false;
    private bool horizontal_priority = true;
    public bool[] grabbed_items = new bool[(int)ItemType.N_TYPES];
    public bool FaceMask = false;
    public bool HomeKeys = false;
    public bool CarKey = false;
    public bool Wallet = false;
    public bool canMove = true;

    void Start()
    {
        RestartPlayer();
    }

    void Update()
    {
        if(canMove)
        {
            if (!isMoving)
            {
                StillTimer += Time.deltaTime;

                float horizontal_input = Input.GetAxis("Horizontal");
                float vertical_input = Input.GetAxis("Vertical");

                if (horizontal_input != 0 && vertical_input != 0)
                {
                    if (horizontal_priority)
                        setDisplacement(horizontal_input, 0);
                    else
                        setDisplacement(0, vertical_input);
                }
                else
                {
                    setDisplacement(horizontal_input, vertical_input);
                    horizontal_priority = horizontal_input == 0;
                }

                isMoving = (dx != 0 || dy != 0);
            }

            if (StillTimer > StillThreshold)
            {
                Camera.SetOrthographicSize(MaxOrthographicSize);
            }
            else 
            {
                Camera.SetOrthographicSize(MinOrthographicSize);
            }
        }
    }

    public void RestartPlayer()
    {
        canMove = false;
        for (int i = 0; i < grabbed_items.Length; i++)
        {
            grabbed_items[i] = false;
        }
        GameController.setListItems(grabbed_items);
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            float dt = Time.fixedDeltaTime;
            gameObject.transform.position += new Vector3(dx, dy, 0f) * dt * Velocity;
            isMoving = false;
            StillTimer = 0f;
        }
    }

    public void GrabItem(ItemType item_type)
    {
        grabbed_items[(int)item_type] = true;
        switch ((int)item_type)
        {
            case (int)ItemType.FACE_MASK:
                FaceMask = true;
                break;
            case (int)ItemType.HOME_KEYS:
                HomeKeys = true;
                break;
            case (int)ItemType.CAR_KEY:
                CarKey = true;
                break;
            case (int)ItemType.WALLET:
                Wallet = true;
                break;
            default:
                Debug.Log("Error: Unrecognized item type");
                break;
        }
        GameController.setListItems(grabbed_items);
    }

    private void setDisplacement(float new_dx, float new_dy) { dx = new_dx; dy = new_dy; }
}
