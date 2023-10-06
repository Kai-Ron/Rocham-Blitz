using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHP = 30.0f, damage = 1.0f, speed = 3.0f, jumpForce = 3.0f, cooldown = 1.0f, invincibility = 0.0f;
    private float currentHP, timeLeft, xDir;
    private int ammo = 3;
    public string weapon;
    public bool battle = false;
    private bool grounded = true, facingForward = true;

    public GameObject hammer, axe, spear, hammer2, axe2, spear2, groundCheck, otherPlayer, battleSystem;

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
        if (battle)
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

            /*if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                weapon = "Hammer";
                axe.SetActive(false);
                spear.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                weapon = "Axe";
                hammer.SetActive(false);
                spear.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                weapon = "Spear";
                hammer.SetActive(false);
                axe.SetActive(false);
            } */
        }
        else
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
    }

    void FixedUpdate()
    {

        if(battle)
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

        if (invincibility > 0.0f)
        {
            invincibility -= 0.01f;
        }
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
            case "Hammer2":
                {
                    if (ammo > 0)
                    {
                        ammo--;
                    }
                    break;
                }
            case "Axe2":
                {
                    if (ammo > 0)
                    {
                        ammo--;
                    }
                    break;
                }
            case "Spear2":
                {
                    if (ammo > 0)
                    {
                        ammo--;
                    }
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
            invincibility = 50.0f;
            if (currentHP <= 0.0f)
            {
                Debug.Log("Player 2 Wins");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player2" && collision.isTrigger == false) //- ignores any colliders marked player and any colliders that are Triggers
        {
            collision.GetComponent<Player2Controller>().TakeDamage(damage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) // needs a trigger to work 
    {
        if (collision.gameObject.tag != "Player1" && collision.isTrigger == false) //- ignores any colliders marked player and any colliders that are Triggers
        {
            grounded = true; //if a collider NOT marked player is detected, it marks the player as being on the ground (or a surface)
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player1" && collision.isTrigger == false)
        {
            grounded = false;
        }

    }
}
