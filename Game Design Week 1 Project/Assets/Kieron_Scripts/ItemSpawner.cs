using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Transform pos0, pos1, pos2, pos3, pos4, pos5, pos6;
    public GameObject hammer, axe, spear;
    private GameObject itemPrefab;
    private float fixedTimer = 36.0f;
    private float timer;
    private int position, weapon;
    private bool recharged = true;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(8.0f, 36.0f);
        position = Random.Range(0, 7);
        weapon = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (recharged)
        {

            switch (position)
            {
                case 0:
                {
                    transform.position = pos0.position;
                    break;
                }
                case 1:
                {
                    transform.position = pos1.position;
                    break;
                }
                case 2:
                {
                    transform.position = pos2.position;
                    break;
                }
                case 3:
                {
                    transform.position = pos3.position;
                    break;
                }
                case 4:
                {
                    transform.position = pos4.position;
                    break;
                }
                case 5:
                {
                    transform.position = pos5.position;
                    break;
                }
                case 6:
                {
                    transform.position = pos6.position;
                    break;
                }
                default:
                {
                    transform.position = pos0.position;
                    break;
                }
            }

            switch (weapon)
            {
                case 0:
                {
                    itemPrefab = hammer;
                    break;
                }
                case 1:
                {
                    itemPrefab = axe;
                    break;
                }
                case 2:
                {
                    itemPrefab = spear;
                    break;
                }
                default:
                {
                    itemPrefab = null;
                    break;
                }
            }

            Charge();
        }
    }

    private void Charge()
    {
        if (itemPrefab != null && recharged)
            {
                recharged = false;
                StartCoroutine(SpawnItem());
            }
    }

    private IEnumerator SpawnItem()
    {
        Instantiate(itemPrefab, transform.position, Quaternion.identity);
        Debug.Log("Item Created");
        
        yield return new WaitForSeconds(fixedTimer + timer);

        timer = Random.Range(8.0f, 36.0f);
        position = Random.Range(0, 7);
        weapon = Random.Range(0, 3);

        recharged = true;
    }
}
