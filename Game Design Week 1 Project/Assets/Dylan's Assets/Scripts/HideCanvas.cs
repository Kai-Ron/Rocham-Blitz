using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCanvas : MonoBehaviour
{

    //In the code for starting the "selection" phase, call the phaseCheck function.
    //Have it return "true" when selection is happening and "false" when it isn't

    public bool battle = false; //True when RPS selection phase is active

    public rpsSelectP1 myP1A;
    public rpsSelectP1 myP1B;
    public rpsSelectP1 myP1C;
    public rpsSelectP1 myP1D;
    public rpsSelectP1 myP1E;
    public rpsSelectP1 myP1F;

    public rpsSelectP2 myP2A;
    public rpsSelectP2 myP2B;
    public rpsSelectP2 myP2C;
    public rpsSelectP2 myP2D;
    public rpsSelectP2 myP2E;
    public rpsSelectP2 myP2F;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (battle)
        {

            this.transform.localScale = new Vector3(1.45f, 1.45f, 1.45f);

        }
        else
        {

            this.transform.localScale = new Vector3 (0, 0, 0);

        }

        myP1A.phaseCheck(battle);
        myP1B.phaseCheck(battle);
        myP1C.phaseCheck(battle);
        myP1D.phaseCheck(battle);
        myP1E.phaseCheck(battle);
        myP1F.phaseCheck(battle);

        myP2A.phaseCheck(battle);
        myP2B.phaseCheck(battle);
        myP2C.phaseCheck(battle);
        myP2D.phaseCheck(battle);
        myP2E.phaseCheck(battle);
        myP2F.phaseCheck(battle);

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
