using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCanvas : MonoBehaviour
{

    //In the code for starting the "selection" phase, call the phaseCheck function.
    //Have it return "true" when selection is happening and "false" when it isn't

    public bool selectPhase = true; //True when RPS selection phase is active

    public rpsSelectP1 myP1;
    public rpsSelectP2 myP2;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (selectPhase)
        {

            this.GetComponent<Renderer>().enabled = true;

        }
        else
        {

            this.GetComponent<Renderer>().enabled = false;

        }

        myP1.phaseCheck(selectPhase);
        myP2.phaseCheck(selectPhase);

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
