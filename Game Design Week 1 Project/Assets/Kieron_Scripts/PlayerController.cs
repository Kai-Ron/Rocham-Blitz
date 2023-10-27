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
    public float maxHP = 30.0f, currentHP, damage = 1.0f, speed = 3.0f, jumpForce = 3.0f, cooldown = 1.0f, invincibility = 0.0f;
    private float timeLeft, xDir;
    private int ammo;
    public string weapon;
    public bool battle = false;
    private bool grounded = true, facingForward = true;
    public int player;
    public bool firstPlayer = false, secondPlayer = false;
    private float horizontal, vertical, attack, throws;

    public GameObject hammer, axe, spear, throwingHammer, throwingAxe, throwingSpear, player1, player2;

    private Rigidbody2D rb;
    private Animator animator;

    public rpsSelectP1 P1A;
    public rpsSelectP1 P1B;
    public rpsSelectP1 P1C;

    public rpsSelectP2 P2A;
    public rpsSelectP2 P2B;
    public rpsSelectP2 P2C;


    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerActions();
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHP = maxHP;
    }

    // Update is called once per frame
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
            //controls.BattleActions.Move.performed += context => xDir = horizontal1;
            horizontal = Input.GetAxisRaw("Horizontal1");
            vertical = Input.GetAxisRaw("Vertical1");
            attack = Input.GetAxisRaw("Attack1");
            throws = Input.GetAxisRaw("Throw1");
        }
        else if (secondPlayer)
        {
            //controls.BattleActions.Move.performed += context => xDir = horizontal2;
            horizontal = Input.GetAxisRaw("Horizontal2");
            vertical = Input.GetAxisRaw("Vertical2");
            attack = Input.GetAxisRaw("Attack2");
            throws = Input.GetAxisRaw("Throw2");
        }

        xDir = horizontal;
        //controls.BattleActions.Move.canceled += context => xDir = 0;
    }

    void FixedUpdate()
    {

        if(battle)
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

            /*if (firstPlayer)
            {
                if (vertical1 > 0)
                {
                    controls.BattleActions.Jump.performed += context => Jump();
                }
                
                if (attack1 > 0)
                {
                    controls.BattleActions.Attack.performed += context => Attack();
                }

                if (throw1 > 0)
                {
                    controls.BattleActions.Throw.performed += context => Throw();
                }
            }
            else if (secondPlayer)
            {
                if (vertical2 > 0)
                {
                    controls.BattleActions.Jump.performed += context => Jump();
                }
                
                if (attack2 > 0)
                {
                    controls.BattleActions.Attack.performed += context => Attack();
                }

                if (throw2 > 0)
                {
                    controls.BattleActions.Throw.performed += context => Throw();
                }
            }*/
        }
        else
        {
            Select();
        }

        /*if (invincibility > 0.0f)
        {
            invincibility -= 0.01f;
        }
        else if(invincibility == 1.0f)
        {
            Debug.Log("Player " + player + " is no longer invincible");
        }*/
    }

    private IEnumerator invincible()
    {
        animator.SetTrigger("Damaged");

        yield return new WaitForSeconds(invincibility);

        invincibility = 0.0f;
        Debug.Log("Player " + player + " is no longer invincible");

    }

    public void Select()
    {
        if (firstPlayer)
        {
            if (horizontal == -1)
            {
                weapon = "Hammer";
                P1A.IDCheck(1);
                P1B.IDCheck(1);
                P1C.IDCheck(1);

            }
            else if (horizontal == 1)
            {
                weapon = "Spear";
                P1A.IDCheck(3);
                P1B.IDCheck(3);
                P1C.IDCheck(3);
            }
            else if (vertical == 1)
            {
                weapon = "Axe";
                P1A.IDCheck(2);
                P1B.IDCheck(2);
                P1C.IDCheck(2);
            }
            else
            {

                P1A.IDCheck(0);
                P1B.IDCheck(0);
                P1C.IDCheck(0);
            }
        }

        if (secondPlayer)
        {
            if (horizontal == -1)
            {
                weapon = "Hammer";
                P2A.IDCheck(1);
                P2B.IDCheck(1);
                P2C.IDCheck(1);

            }
            else if (horizontal == 1)
            {
                weapon = "Spear";
                P2A.IDCheck(3);
                P2B.IDCheck(3);
                P2C.IDCheck(3);
            }
            else if (vertical == 1)
            {
                weapon = "Axe";
                P2A.IDCheck(2);
                P2B.IDCheck(2);
                P2C.IDCheck(2);
            }
            else
            {

                P2A.IDCheck(0);
                P2B.IDCheck(0);
                P2C.IDCheck(0);
            }
        }


        /*if (firstPlayer)
            {
                if (horizontal1 < 0)
                {
                    controls.SelectActions.Hammer.performed += context => weapon = "Hammer";
                }
                
                if (vertical1 > 0)
                {
                    controls.SelectActions.Axe.performed += context => weapon = "Axe";
                }

                if (horizontal1 > 0)
                {
                    controls.SelectActions.Spear.performed += context => weapon = "Spear";
                }
            }
        else if (secondPlayer)
            {
                if (horizontal2 < 0)
                {
                    controls.SelectActions.Hammer.performed += context => weapon = "Hammer";
                }
                
                if (vertical2 > 0)
                {
                    controls.SelectActions.Axe.performed += context => weapon = "Axe";
                }

                if (horizontal2 > 0)
                {
                    controls.SelectActions.Spear.performed += context => weapon = "Spear";
                }
            }*/

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
            /*var newPrefab = */
            /*newPrefab.transform.setParent(gameObject.transform);*/
            /*if (cooldown <= 0)
            {
                var newPrefab = Instantiate(projectilePrefab, throwPosition.position, transform.rotation);
                ammo --;
                cooldown = 1.0f;
            }*/
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

    public void TakeDamage(float damageTaken)
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
                    StartCoroutine(invincible());
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
}
