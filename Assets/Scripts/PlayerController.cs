using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float Velocity = 60f;
    const float MovementThreshold = 0.5f;

    private float DesiredMovementX = 0f;
    private float DesiredMovementY = 0f;
    private float MovementTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DesiredMovementX = Input.GetAxis("Horizontal");
        DesiredMovementY = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        MovementTimer += Time.deltaTime;
        if (MovementTimer > MovementThreshold && (DesiredMovementX != 0f || DesiredMovementY != 0f))
        {
            if (DesiredMovementX != 0) 
            {
                this.transform.position += Vector3.right * DesiredMovementX * Velocity * Time.deltaTime;
            } 
            else if (DesiredMovementY != 0)
            {
                this.transform.position += Vector3.up * DesiredMovementY * Velocity * Time.deltaTime;
            }
            MovementTimer = 0f;
        }
    }
}
