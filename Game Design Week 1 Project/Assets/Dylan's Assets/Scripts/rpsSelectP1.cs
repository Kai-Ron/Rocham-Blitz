using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpsSelectP1 : MonoBehaviour
{

    //You shouldn't need to mess with this

    //Code for the selection phase. Assumes that players navigate options using Left-Right movement buttons and select using attack buttons.
    //Assumes WASD movement and F to attack for Player One
    //The acronym RPS stands for "Rock, Paper, Scissors", and refers to the selection portion of the game which is styled after it.

    public bool selectPhase = true; //True when RPS selection phase is active

    int playerOneSelect = 0;

    public int mySelectID = 1;

    public GameObject player1Sprite;

    void Start()
    {

    }

    void Update()
    {

        if (selectPhase) //Detects whether players are in selection phase, in combat, or something else i.e. 
        {

            //Start of selection code
            //Detects inputs of player 1 and ajusts their respective selection values accordingly
            if (Input.GetKey(KeyCode.A))
            {

                playerOneSelect = 1;

            }
            else if (Input.GetKey(KeyCode.W))
            {

                playerOneSelect = 2;

            }
            else if (Input.GetKey(KeyCode.D))
            {

                playerOneSelect = 3;

            }
            else
            {

                playerOneSelect = 0;

            }

            if (playerOneSelect == mySelectID)
            {

                this.GetComponent<Renderer>().enabled = true;

            }
            else
            {

                this.GetComponent<Renderer>().enabled = false;

            }

            //End of selection code

        }
            

    }

    public void phaseCheck(bool phase)
    {

        if (phase)
        {

            selectPhase = true;

        }
        else
        {

            selectPhase = false;

        }

    }

    
}
