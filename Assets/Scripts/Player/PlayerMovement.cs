using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterAnimation playerAnimation;
    private Rigidbody rb;

    public float walkSpeed = 3f;
    public float zSpeed = 1.5f;

    private float rotation_Y = -90f;
    private float rotationSpeed = 15f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimation = GetComponentInChildren<CharacterAnimation>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        AnimatedPlayerWalk();
    }

    void FixedUpdate()
    {
        DetectMovement();
    }

    void DetectMovement()
    {
        rb.velocity = new Vector3(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walkSpeed), rb.velocity.y, Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-zSpeed));
    }

    void RotatePlayer()
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0) 
        { 
            transform.rotation = Quaternion.Euler(0f, rotation_Y, 0f);
        }
        else if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotation_Y), 0f);
        }
    }

    void AnimatedPlayerWalk()
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
        {
            playerAnimation.Walk(true);
        }
        else
        {
            playerAnimation.Walk(false);
        }
    }
}
