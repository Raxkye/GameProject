using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Script : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpPower = 10f;

    [Header("Bools")]
    [SerializeField] bool isGrounded = false;

    //animatorThings
    bool facingRight = true;
    bool isAtacking;
    Animator myAnim;
    public int combo;
    public AudioSource audio_S;
    public AudioClip[] sound;

    //health and mana bars
    private int maxHealth = 100;
	private int currentHealth;
	public HealthManaBarScripts healthBar;

    private int maxMana = 100;
	private int currentMana;
	public HealthManaBarScripts manaBar;

    //movements keys
    public KeyCode hit;
    public KeyCode left;
    public KeyCode jump;
    public KeyCode right;
    public KeyCode boost;

    //attack
    int damage = 10;
    bool boostAttack;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        audio_S = GetComponent<AudioSource>();   

        //mana and health
        currentHealth = maxHealth;
        healthBar.SetMaxValue(maxHealth);

        currentMana = maxMana;
        manaBar.SetMaxValue(maxMana);

    }

    // Update is called once per frame
    void Update()
    {
        //movements

        if(Input.GetKey(right)){
            rigidbody2d.velocity = new Vector2(moveSpeed, rigidbody2d.velocity.y);
            if(!facingRight)
            {
                Flip_();
            }
        }else if(Input.GetKey(left)) {
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
            if(facingRight)
            {
                Flip_();
            }
        }

        Combo_();

        Jump();

        BoostMethod();

    }
    void BoostMethod()
    {
        if(Input.GetKey(boost) && !boostAttack)
        {
            boostAttack = true;
        }
    }

    void Jump()
    {
        if (Input.GetKey(jump) && isGrounded == true)
        {
            rigidbody2d.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
            isGrounded = false;

        }
    }

    public void Combo_()
    {
        if(Input.GetKey(hit) && !isAtacking)
        {
            isAtacking = true;
            myAnim.SetTrigger(""+combo);
        }
    }

    public void Start_Combo() 
    {
        isAtacking = false;

        if (combo <2)
        {      
            combo++;   
        }
    }

    public void Finish_Anim()
    {
        isAtacking = false;
        combo = 0;

    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true; 
        ProcessCollision(other.gameObject);       
    }

    public void Flip_()
    {   
        facingRight = !facingRight;
        transform.Rotate(0,180,0);
    }

    void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetValue(currentHealth);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
    ProcessCollision(collision.gameObject); 
    }

    void ProcessCollision(GameObject collider)
    {
        Debug.Log(collider.tag);
        if(collider.gameObject.CompareTag("Player1") && isAtacking)
        {
            if(currentMana>0 && boostAttack){
                TakeDamage(damage+5);
                currentMana -= 10;
		        manaBar.SetValue(currentMana);
            }else{
                TakeDamage(damage);
                currentMana += 10;
		        manaBar.SetValue(currentMana);
            }
            
        }
        if(collider.gameObject.CompareTag("Player2") && isAtacking)
        {
            if(currentMana>0 && boostAttack){
                TakeDamage(damage+5);
                currentMana -= 30;
		        manaBar.SetValue(currentMana);
                boostAttack = false;
            }else{
                TakeDamage(damage);
                currentMana += 10;
		        manaBar.SetValue(currentMana);
            }
        }
    }

}
