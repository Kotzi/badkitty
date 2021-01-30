using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float MinOrthographicSize = 5f;
    const float MaxOrthographicSize = 6f;
    const float Velocity = 10f;
    const float MovementThreshold = 0.1f;
    const float StillThreshold = 1f;

    private float MovementTimer = 0f;
    private float StillTimer = 0f;

    public CameraController Camera;
    private int dx, dy;
    private bool isMoving = false;

    private bool[] grabbed_items = new bool[(int)ItemType.N_TYPES];
    public bool FaceMask = false;
    public bool HomeKeys = false;
    public bool CarKey = false;
    public bool Wallet = false;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < grabbed_items.Length; i++)
            grabbed_items[i] = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            dx = Input.GetAxis("Horizontal") > 0.01f ? 1 : (Input.GetAxis("Horizontal") < -0.01f ? -1 : 0);
            dy = dx != 0 ? 0 : (Input.GetAxis("Vertical") > 0.01f ? 1 : (Input.GetAxis("Vertical") < -0.01f ? -1 : 0));
            isMoving = (dx != 0 || dy != 0);
        }
        if (isMoving)
        {
            float dt = Time.deltaTime;
            gameObject.transform.position += new Vector3(dx, dy, 0f) * dt * Velocity;
            MovementTimer += dt;
            StillTimer = 0f;
            if (MovementTimer > MovementThreshold)
            {
                MovementTimer = 0f;
                isMoving = false;
            }
        } 
        else
        {
            StillTimer += Time.deltaTime;
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

    void FixedUpdate()
    {
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
    }
}
