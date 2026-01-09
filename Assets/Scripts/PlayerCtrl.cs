using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCtrl : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed;
    private Rigidbody2D rb;
    private float x;
    private float y;
    private Vector2 input;
    private bool moving;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        GetInput();
        Animate();
    }
    void FixedUpdate()
    {
        rb.linearVelocity = input * moveSpeed;
    }
    void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        input = new Vector2(x, y);
        input.Normalize();
    }
    void Animate()
    {
        if(input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if(moving)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);
        }

        anim.SetBool("Moving", moving);
    }
}