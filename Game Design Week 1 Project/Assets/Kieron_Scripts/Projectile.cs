using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string name;
    public float speed = 5.0f, damage = 1;
    private Vector2 direction;
    private Rigidbody2D rb;
    public int player;
    private bool thrown = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Direction();

        if (name == "Hammer")
        {
            if (thrown)
            {
                //rb.velocity = new Vector2(speed * xDir, speed);
                thrown = false;
            }
        }

        if (name == "Axe")
        {
            //Direction();
            transform.Rotate(0.0f, 0.0f, speed * Time.deltaTime, Space.Self);
        }

        if (name == "Spear")
        {
            //Direction();
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
        if((collision.gameObject.tag == "Player1") && (collision.gameObject.tag == "Player" + player.ToString()))
        {
            return;
        }
        else if((collision.gameObject.tag == "Player2") && (collision.gameObject.tag == "Player" + player.ToString()))
        {
            return;
        }
        else if((collision.gameObject.tag == "Player1") || (collision.gameObject.tag == "Player1"))
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
