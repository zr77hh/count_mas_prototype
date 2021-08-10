using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    
    float lastFrameFingerPosX;
    float moveFactorX;
    
    [SerializeField] 
    float swerveSpeed = 0.5f;
    [SerializeField]
    float runSpeed = 5;
    [SerializeField] 
    float maxSwerveAmount = 1f;

    public bool stop;
    Rigidbody rb;
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        getSwerveInput();
        
    }
    private void FixedUpdate() {
        if(!stop)
        {
            move();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    void move()
    {
        float swerveAmount = Time.fixedDeltaTime * swerveSpeed * moveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        Vector3 newVelocity = new Vector3(swerveAmount,rb.velocity.y,runSpeed*Time.fixedDeltaTime);
        rb.velocity = newVelocity;
    }

    void getSwerveInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPosX;
            lastFrameFingerPosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }
    }
}
