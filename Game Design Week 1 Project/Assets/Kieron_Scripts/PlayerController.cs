using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerActions controls;
    Vector2 move;
    private GameObject projectilePrefab;
    public Transform throwPosition;
    public float maxHP = 30.0f, currentHP, damage = 1.0f, speed = 3.0f, jumpForce = 3.0f, cooldown = 1.0f, invincibility = 0.0f, knockBack = 100.0f;
    private float timeLeft, xDir;
    private int ammo;
    public string weapon;
    public bool battle = false;
    private bool grounded = true;
    public bool facingForward = true;
    private bool knockedBack = false;
    public int player;
    public bool firstPlayer = false, secondPlayer = false;
    private float horizontal, vertical, attack, throws;

    public GameObject hammer, axe, spear, throwingHammer, throwingAxe, throwingSpear, player1, player2;

    private Rigidbody2D rb;
    private Animator animator;

    public rpsSelectP1 P1A;
    public rpsSelectP1 P1B;
    public rpsSelectP1 P1C;
    public rpsSelectP1 P1D;
    public rpsSelectP1 P1E;
    public rpsSelectP1 P1F;

    public rpsSelectP2 P2A;
    public rpsSelectP2 P2B;
    public rpsSelectP2 P2C;
    public rpsSelectP2 P2D;
    public rpsSelectP2 P2E;
    public rpsSelectP2 P2F;


    void Start()
    {
        controls = new PlayerActions();
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHP = maxHP;
    }

    void Update()
    {
        if(cooldown > 0)
        {
            cooldown = cooldown - 0.01f;
        }

        if (battle)
        {
            controls.BattleActions.Enable();
            controls.SelectActions.Disable();
        }
        else
        {
            controls.BattleActions.Disable();
            controls.SelectActions.Enable();

            ammo = 3;

            hammer.SetActive(false);
            axe.SetActive(false);
            spear.SetActive(false);
        }

        if (firstPlayer)
        {
            horizontal = Input.GetAxisRaw("Horizontal1");
            vertical = Input.GetAxisRaw("Vertical1");
            attack = Input.GetAxisRaw("Attack1");
            throws = Input.GetAxisRaw("Throw1");
        }
        else if (secondPlayer)
        {
            horizontal = Input.GetAxisRaw("Horizontal2");
            vertical = Input.GetAxisRaw("Vertical2");
            attack = Input.GetAxisRaw("Attack2");
            throws = Input.GetAxisRaw("Throw2");
        }

        xDir = horizontal;
    }

    void FixedUpdate()
    {
        if(battle)
        {
            if (!knockedBack)
            {
                Move(xDir);

                if (vertical == 1)
                {
                    Jump();
                }

                if (attack == 1)
                {
                    Attack();
                }

                if (throws  == 1)
                {
                    Throw();
                }
            }
        }
        else
        {
            Select();
        }
    }

    public void Select()
    {

        if (firstPlayer)
        {
            if (horizontal == -1)
            {
                weapon = "Hammer";
                projectilePrefab = throwingHammer;
                P1A.IDCheck(1);
                P1B.IDCheck(1);
                P1C.IDCheck(1);
                P1D.IDCheck(1);
                P1E.IDCheck(1);
                P1F.IDCheck(1);

            }
            else if (horizontal == 1)
            {
                weapon = "Spear";
                projectilePrefab = throwingSpear;
                P1A.IDCheck(3);
                P1B.IDCheck(3);
                P1C.IDCheck(3);
                P1D.IDCheck(3);
                P1E.IDCheck(3);
                P1F.IDCheck(3);
            }
            else if (vertical == 1)
            {
                weapon = "Axe";
                projectilePrefab = throwingAxe;
                P1A.IDCheck(2);
                P1B.IDCheck(2);
                P1C.IDCheck(2);
                P1D.IDCheck(2);
                P1E.IDCheck(2);
                P1F.IDCheck(2);

            }
            else
            {
                projectilePrefab = null;
                P1A.IDCheck(0);
                P1B.IDCheck(0);
                P1C.IDCheck(0);
                P1D.IDCheck(0);
                P1E.IDCheck(0);
                P1F.IDCheck(0);
            }

        }

        if (secondPlayer)
        {
            if (horizontal == -1)
            {
                weapon = "Hammer";
                projectilePrefab = throwingHammer;
                P2A.IDCheck(1);
                P2B.IDCheck(1);
                P2C.IDCheck(1);
                P2D.IDCheck(1);
                P2E.IDCheck(1);
                P2F.IDCheck(1);

            }
            else if (horizontal == 1)
            {
                weapon = "Spear";
                projectilePrefab = throwingSpear;
                P2A.IDCheck(3);
                P2B.IDCheck(3);
                P2C.IDCheck(3);
                P2D.IDCheck(3);
                P2E.IDCheck(3);
                P2F.IDCheck(3);
            }
            else if (vertical == 1)
            {
                weapon = "Axe";
                projectilePrefab = throwingAxe;
                P2A.IDCheck(2);
                P2B.IDCheck(2);
                P2C.IDCheck(2);
                P2D.IDCheck(2);
                P2E.IDCheck(2);
                P2F.IDCheck(2);

            }
            else
            {
                projectilePrefab = null;
                P2A.IDCheck(0);
                P2B.IDCheck(0);
                P2C.IDCheck(0);
                P2D.IDCheck(0);
                P2E.IDCheck(0);
                P2F.IDCheck(0);
            }

        }

        ammo = 3;

    }

    private void Move(float xDirection)
    {
        rb.velocity = new Vector2(xDirection * speed, rb.velocity.y);
        if (xDirection == 1 && !facingForward || xDirection == -1 && facingForward)
        {
            facingForward = !facingForward;
            Vector3 playerScale = transform.localScale;
            playerScale.x *= -1;
            knockBack *= -1;
            transform.localScale = playerScale;
        }
    }
    
    private void Jump()
    {
        if (grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
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

    public void Throw()
    {
        if (ammo > 0 && projectilePrefab != null)
        {
            if (cooldown <= 0)
            {
                var newPrefab = Instantiate(projectilePrefab, throwPosition.position, transform.rotation);
                ammo --;
                cooldown = 1.0f;
            }
        }
    }

    public void PickUpHammer()
    {
        projectilePrefab = throwingHammer;
        ammo = 3;
    }

    public void PickUpAxe()
    {
        projectilePrefab = throwingAxe;
        ammo = 3;
    }

    public void PickUpSpear()
    {
        projectilePrefab = throwingSpear;
        ammo = 3;
    }

    public void TakeDamage(float damageTaken, float knockBackTaken)
    {
        
            if (invincibility <= 0)
            {
                currentHP -= damageTaken;
                if (currentHP <= 0.0f)
                {
                    //animator.SetTrigger("Dead");
                    Debug.Log("Player " + player + " Loses");

                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("Player " + player + " Takes Damage");
                    invincibility = 1.0f;

                    rb.velocity = new Vector2(rb.velocity.x + knockBackTaken, rb.velocity.y + 10);

                    //rb.AddForce(transform.up * 10, ForceMode2D.Impulse);
                    //rb.AddForce(transform.right * knockBackTaken, ForceMode2D.Impulse);

                    StartCoroutine(Invincible());
                }
            }
    }

    private IEnumerator Invincible()
    {
        //rb.velocity = new Vector2(rb.velocity.x + knockBack, rb.velocity.y + 5);

        knockedBack = true;

        animator.SetTrigger("Damaged");

        yield return new WaitForSeconds(invincibility);

        invincibility = 0.0f;
        knockedBack = false;
        Debug.Log("Player " + player + " is no longer invincible");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if((collision.gameObject.tag == "Weapon1") && (!firstPlayer))
            {
                TakeDamage(player1.GetComponent<PlayerController>().damage, player1.GetComponent<PlayerController>().knockBack);
            }
            else if((collision.gameObject.tag == "Weapon2") && (!secondPlayer))
            {
                TakeDamage(player2.GetComponent<PlayerController>().damage, player2.GetComponent<PlayerController>().knockBack);
            }

            if(collision.gameObject.tag == "Hammer")
            {
                projectilePrefab = throwingHammer;
                ammo = 3;
            }

            if(collision.gameObject.tag == "Axe")
            {
                projectilePrefab = throwingAxe;
                ammo = 3;
            }

            if(collision.gameObject.tag == "Spear")
            {
                projectilePrefab = throwingSpear;
                ammo = 3;
            }
    }

    private void OnCollisionStay2D(Collision2D collision) // needs a trigger to work 
    {
        if (collision.gameObject.tag == "Ground" /*&& collision.isTrigger == false*/) //- ignores any colliders marked player and any colliders that are Triggers
        {
            grounded = true; //if a collider NOT marked player is detected, it marks the player as being on the ground (or a surface)
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" /*&& collision.isTrigger == false*/)
        {
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if(collision.gameObject.tag == "Hammer")
            {
                projectilePrefab = throwingHammer;
                ammo = 3;
                Destroy(collision.gameObject);
            }

            if(collision.gameObject.tag == "Axe")
            {
                projectilePrefab = throwingAxe;
                ammo = 3;
                Destroy(collision.gameObject);
            }

            if(collision.gameObject.tag == "Spear")
            {
                projectilePrefab = throwingSpear;
                ammo = 3;
                Destroy(collision.gameObject);
            }
    }
}
