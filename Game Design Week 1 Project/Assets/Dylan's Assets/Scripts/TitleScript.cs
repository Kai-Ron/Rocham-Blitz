using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleScript : MonoBehaviour
{

    public bool P1Ready;
    public bool P2Ready;

    public TMP_Text P1Text;
    public TMP_Text P2Text;

    private float P1Attack, P2Attack;

    // Start is called before the first frame update
    void Start()
    {

        P1Text.text = "Ready Player 1?";
        P2Text.text = "Ready Player 2?";

    }

    // Update is called once per frame
    void Update()
    {

        P1Attack = Input.GetAxisRaw("Attack1");
        P2Attack = Input.GetAxisRaw("Attack2");

        if (P1Attack == 1)
        {

            P1Ready = true;

        }

        if (P2Attack == 1)
        {

            P2Ready = true;

        }

        if (P1Ready)
        {

            P1Text.text = "Ready";

        }

        if (P2Ready)
        {

            P2Text.text = "Ready";

        }

        if (P1Ready && P2Ready)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

    }
}
