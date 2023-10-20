using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHP = 30.0f, damage = 1.0f, speed = 3.0f, jumpForce = 3.0f, cooldown = 1.0f, invincibility = 0.0f;
    private float currentHP, timeLeft, xDir;
    private int ammo;
    public string weapon;
    public bool battle = false;
    private bool grounded = true, facingForward = true;
    public int player;
    public bool firstPlayer = false, secondPlayer = false;


    public GameObject hammer, axe, spear, player1, player2;

    private Rigidbody2D rb;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (battle && player == 1)
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                xDir = 0;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                xDir = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                xDir = 1;
            }
            else
            {
                xDir = 0;
            }
        }
        else if (battle && player == 2)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                xDir = 0;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                xDir = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                xDir = 1;
            }
            else
            {
                xDir = 0;
            }
        }
        else if (!battle && player == 1)
        {
            xDir = 0;

            if (Input.GetKeyDown(KeyCode.A))
            {
                weapon = "Hammer";
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                weapon = "Axe";
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                weapon = "Spear";
            }
        }
        else if (!battle && player == 2)
        {
            xDir = 0;

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                weapon = "Hammer";
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                weapon = "Axe";
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                weapon = "Spear";
            }
        }
    }

    void FixedUpdate()
    {

        if(battle && player == 1)
        {

            Move();

            if (Input.GetKeyDown(KeyCode.W) && grounded)
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Attack();
            }
        }
        else if (battle && player == 2)
        {

            Move();

            if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Attack();
            }
        }

        if (invincibility > 0.0f)
        {
            invincibility -= 0.01f;
        }
        else if(invincibility == 1.0f)
        {
            Debug.Log("Player " + player + " is no longer invincible");
        }
    }

    private IEnumerator invincible()
    {
        animator.SetTrigger("Damaged");

        yield return new WaitForSeconds(invincibility);

        Debug.Log("Player " + player + " is no longer invincible");

    }

    public void Select()
    {

    }

    private void Move()
    {
        rb.velocity = new Vector2(xDir * speed, rb.velocity.y);
        if (xDir > 0 && !facingForward || xDir < 0 && facingForward)
        {
            facingForward = !facingForward;
            Vector3 playerScale = transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
        }
    }
    
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void Attack()
    {
        switch(weapon)
        {
            case "Hammer":
                {
                    hammer.SetActive(true);
                    animator.SetTrigger("Hammer");
                    axe.SetActive(false);
                    spear.SetActive(false);
                    break;
                }
            case "Axe":
                {
                    axe.SetActive(true);
                    animator.SetTrigger("Axe");
                    hammer.SetActive(false);
                    spear.SetActive(false);
                    break;
                }
            case "Spear":
                {
                    spear.SetActive(true);
                    animator.SetTrigger("Spear");
                    hammer.SetActive(false);
                    axe.SetActive(false);
                    break;
                }
            default:
                {
                    hammer.SetActive(false);
                    axe.SetActive(false);
                    spear.SetActive(false);
                    break;
                }
        }
    }

    public void TakeDamage(float damageTaken)
    {
        if (invincibility <= 0.0f)
        {
            currentHP -= damageTaken;
            if (currentHP <= 0.0f)
            {
                // animator.SetTrigger("Dead");
                Debug.Log("Player " + player + " Loses");
            }
            else
            {
                invincibility = 1.0f;
                StartCoroutine(invincible());
                Debug.Log("Player " + player + " Takes Damage");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if((collision.gameObject.tag == "Weapon1") && (!firstPlayer))
            {
                player2.GetComponent<PlayerController>().TakeDamage(damage);
            }
            else if((collision.gameObject.tag == "Weapon2") && (!secondPlayer))
            {
                player1.GetComponent<PlayerController>().TakeDamage(damage);
            }
    }

    private void OnTriggerStay2D(Collider2D collision) // needs a trigger to work 
    {
        if (collision.gameObject.tag != "Player" + player.ToString() && collision.isTrigger == false) //- ignores any colliders marked player and any colliders that are Triggers
        {
            grounded = true; //if a collider NOT marked player is detected, it marks the player as being on the ground (or a surface)
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" + player.ToString() && collision.isTrigger == false)
        {
            grounded = false;
        }

    }
}
