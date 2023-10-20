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
    public float maxHP = 30.0f, damage = 1.0f, speed = 3.0f, jumpForce = 3.0f, cooldown = 1.0f, invincibility = 0.0f;
    private float currentHP, timeLeft, xDir;
    private int ammo;
    public string weapon;
    public bool battle = false;
    private bool grounded = true, facingForward = true;
    public int player;
    public bool firstPlayer = false, secondPlayer = false;

    public GameObject hammer, axe, spear, throwingHammer, throwingAxe, throwingSpear, player1, player2;

    private Rigidbody2D rb;
    private Animator animator;
    
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
        if (battle && player == 1)
        {
            controls.BattleActions.Enable();
            
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
            controls.BattleActions.Enable();
            
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
            controls.BattleActions.Disable();
            xDir = 0;
            ammo = 3;

            if (Input.GetKeyDown(KeyCode.A))
            {
                weapon = "Hammer";
                projectilePrefab = throwingHammer;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                weapon = "Axe";
                projectilePrefab = throwingAxe;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                weapon = "Spear";
                projectilePrefab = throwingSpear;
            }
        }
        else if (!battle && player == 2)
        {
            controls.BattleActions.Disable();
            xDir = 0;
            ammo = 3;

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                weapon = "Hammer";
                projectilePrefab = throwingHammer;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                weapon = "Axe";
                projectilePrefab = throwingAxe;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                weapon = "Spear";
                projectilePrefab = throwingSpear;
            }
        }

        controls.BattleActions.Move.performed += context => move = context.ReadValue<Vector2>();
        xDir = move.x;
        controls.BattleActions.Jump.performed += context => Jump();
        controls.BattleActions.Attack.performed += context => Attack();
        controls.BattleActions.Move.canceled += context => move = Vector2.zero;
        controls.BattleActions.Throw.performed += context => Throw();
    }

    void FixedUpdate()
    {

        if(battle && player == 1)
        {

            Move(xDir);

            if (Input.GetKeyDown(KeyCode.W))
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

            Move(xDir);

            if (Input.GetKeyDown(KeyCode.UpArrow))
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

    private void Move(float xDirection)
    {
        rb.velocity = new Vector2(xDirection * speed, rb.velocity.y);
        if (xDirection > 0 && !facingForward || xDirection < 0 && facingForward)
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
        if (ammo > 0)
        {
            /*var newPrefab = */
            /*newPrefab.transform.setParent(gameObject.transform);*/

            var newPrefab = Instantiate(projectilePrefab, throwPosition.position, transform.rotation);
            ammo --;
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

    private void OnCollisionStay2D(Collision2D collision) // needs a trigger to work 
    {
        if (collision.gameObject.tag != "Player" + player.ToString() /*&& collision.isTrigger == false*/) //- ignores any colliders marked player and any colliders that are Triggers
        {
            grounded = true; //if a collider NOT marked player is detected, it marks the player as being on the ground (or a surface)
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player" + player.ToString() /*&& collision.isTrigger == false*/)
        {
            grounded = false;
        }

    }
}
