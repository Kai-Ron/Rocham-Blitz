using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string name;
    public float speed = 5.0f, damage = 1;
    private Vector2 direction;
    public int player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
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
