using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float Velocity = 10f;
    const float MovementThreshold = 0.1f;
    private float MovementTimer = 0f;

    private int dx, dy;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            dx = Input.GetAxis("Horizontal") > 0.01f ? 1 : (Input.GetAxis("Horizontal") < -0.01f ? -1 : 0);
            dy = dx != 0 ? 0 : (Input.GetAxis("Vertical") > 0.01f ? 1 : (Input.GetAxis("Vertical") < -0.01f ? -1 : 0));
            isMoving = true;
        }
        if (isMoving)
        {
            float dt = Time.deltaTime;
            gameObject.transform.position += new Vector3(dx, dy, 0f) * dt * Velocity;
            MovementTimer += dt;
            if (MovementTimer > MovementThreshold)
            {
                MovementTimer = 0f;
                isMoving = false;
            }
        }
    }

    void FixedUpdate()
    {
    }
}
