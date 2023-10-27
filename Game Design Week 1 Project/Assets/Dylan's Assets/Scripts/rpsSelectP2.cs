using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpsSelectP2 : MonoBehaviour
{

    //You shouldn't need to mess with this

    //Code for the selection phase. Assumes that players navigate options using Left-Right movement buttons and select using attack buttons.
    //Assumes Arrow Key movement and NumPad 0 to attack for Player Two
    //The acronym RPS stands for "Rock, Paper, Scissors", and refers to the selection portion of the game which is styled after it.

    public bool battle = false; //True when RPS selection phase is active

    int playerTwoSelect = 0;

    public int mySelectID = 1;

    public GameObject player2Sprite;

    public void IDCheck(int playerTwoSelect)
    {

        if (playerTwoSelect == mySelectID)
        {

            this.GetComponent<Renderer>().enabled = true;

        }
        else
        {

            this.GetComponent<Renderer>().enabled = false;

        }

    }

    public void phaseCheck(bool phase)
    {

        if (phase)
        {

            battle = false;

        }
        else
        {

            battle = true;

        }

    }
}
