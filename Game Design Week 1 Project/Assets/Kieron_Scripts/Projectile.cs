using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string name;
    private float speed = 5.0f, damage = 1;
    private Vector2 direction;
    private float xDir;
    private Rigidbody2D rb;
    private bool thrown = true;
    public int playerNo;
    private GameObject player;
    private PlayerController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //player = GameObject.FindGameObjectWithTag("Player" + playerNo.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        //Direction();

        if (controller != null)
        {
            if (name == "Hammer")
            {
                if (thrown)
                {
                    if(controller.facingForward)
                    {
                        xDir = 1;
                    }
                    else
                    {
                        xDir = -1;
                    }

                    rb.velocity = new Vector2(speed * xDir, speed);
                    thrown = false;
                }
                transform.Rotate(0.0f, 0.0f, speed * -xDir /** Time.deltaTime*//*, Space.Self*/);
            }

            if (name == "Axe")
            {
                if (thrown)
                {
                    if(controller.facingForward)
                    {
                        xDir = 1;
                    }
                    else
                    {
                        xDir = -1;
                    }

                    Vector3 weaponScale = transform.localScale;
                    weaponScale.x *= xDir;
                    transform.localScale = weaponScale;

                    thrown = false;
                }
                rb.velocity = new Vector2(speed * xDir, 0.0f);
                transform.Rotate(0.0f, 0.0f, speed * -xDir /** Time.deltaTime*//*, Space.Self*/);
                //transform.position += transform.right * Time.deltaTime * speed * xDir;
            }

            if (name == "Spear")
            {
                if (thrown)
                {
                    if(controller.facingForward)
                    {
                        xDir = 1;
                    }
                    else
                    {
                        xDir = -1;
                    }
                    
                    transform.Rotate(0.0f, 0.0f, -90.0f);

                    Vector3 weaponScale = transform.localScale;
                    weaponScale.x *= xDir;
                    transform.localScale = weaponScale;

                    thrown = false;
                }
                rb.velocity = new Vector2(speed * xDir * 2, 0.0f);
                //transform.position += transform.right * Time.deltaTime * speed * xDir;
            }
        }
        else
        {
            if (playerNo == 1)
            {
                player = GameObject.FindGameObjectWithTag("Player1");
                controller = player.GetComponent<PlayerController>();
                Debug.Log("Player Assigned");
            }
            else if (playerNo == 2)
            {
                player = GameObject.FindGameObjectWithTag("Player2");
                controller = player.GetComponent<PlayerController>();
                Debug.Log("Player Assigned");
            }
        }
    }

    public void Direction(float xDirection)
    {
        /*if (name == "Hammer")
        {
            rb.velocity = new Vector2(xDirection * speed, speed);
        }
        else
        {
            transform.position += transform.right * Time.deltaTime * speed;
        }
        if (xDirection == 1 && !facingForward || xDirection == -1 && facingForward)
        {
            facingForward = !facingForward;
            Vector3 playerScale = transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
        }*/
    }

    private void OnTrigger2D(Collider2D collision)
    {
        if((collision.gameObject.tag == "Player" + playerNo.ToString()))
        {
            if (player == null)
            {
                player = collision.gameObject;
                controller = player.GetComponent<PlayerController>();
                Debug.Log("Throwing Weapon Claimed");
            }
            return;
        }
        else if((collision.gameObject.tag == "Player1") || (collision.gameObject.tag == "Player2"))
        {
            Debug.Log("Throwing Weapon Destroyed");
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Ground" /*&& collision.isTrigger == false*/)
        {
            Debug.Log("Throwing Weapon Destroyed");
            Destroy(gameObject);
        }
    }
}
