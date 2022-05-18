using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpPower = 10f;

    [Header("Bools")]
    [SerializeField] bool isGrounded = false;

    //animatorThings

    Animator myAnim;
    public bool flip;

    //movements keys
    public KeyCode hit;
    public KeyCode left;
    public KeyCode jump;
    public KeyCode right;
    public KeyCode boost;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        if (flip)
        {
            Flip();
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        //movements

        if(Input.GetKey(right)){
            rigidbody2d.velocity = new Vector2(moveSpeed, rigidbody2d.velocity.y);

        }else if(Input.GetKey(left)) {
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
        }

        Jump();
        
        if(Input.GetKey(hit))
        {
            myAnim.Play("AttackJake");
        }
    }

    void FixedUpdate()
    {
        
    }

    void Jump()
    {
        if (Input.GetKey(jump) && isGrounded == true)
        {
            rigidbody2d.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }
    
    void Flip(){

        Vector3 TheCurrentScale = transform.localScale;

        TheCurrentScale.x*= -1;

        transform.localScale = TheCurrentScale;
    }

}
