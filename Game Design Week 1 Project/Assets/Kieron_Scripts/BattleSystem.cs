using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleSystem : MonoBehaviour
{
    public GameObject player1, player2;
    private PlayerController controller1, controller2;
    public string choice1, choice2;
    public float battleTime = 300.0f, chooseTime = 30.0f;
    private float timeLeft;
    public bool battle = false;

    public TMP_Text countdown;

    // Start is called before the first frame update
    void Start()
    {
        controller1 = player1.GetComponent<PlayerController>();
        controller2 = player2.GetComponent<PlayerController>();

        timeLeft = chooseTime;
        battle = false;
        controller1.battle = false;
        controller2.battle = false;
    }

    // Update is called once per frame
    void Update()
    {
        countdown.text = timeLeft.ToString();

        if (!battle)
        {
            
            if (timeLeft >= 0)
            {
                timeLeft--;
            }
            else
            {
                switch (controller1.weapon)
                {
                    case "Hammer":
                        {
                            switch (controller2.weapon)
                            {
                                case "Hammer":
                                    {
                                        break;
                                    }
                                case "Axe":
                                    {
                                        controller1.weapon = null;
                                        controller1.PickUpHammer();
                                        break;
                                    }
                                case "Spear":
                                    {
                                        controller2.weapon = null;
                                        controller2.PickUpSpear();
                                        break;
                                    }
                                default:
                                    {
                                        controller2.weapon = null;
                                        break;
                                    }
                            }
                            break;
                        }
                    case "Axe":
                        {
                            switch (controller2.weapon)
                            {
                                case "Hammer":
                                    {
                                        controller2.weapon = null;
                                        controller2.PickUpHammer();
                                        break;
                                    }
                                case "Axe":
                                    {
                                        break;
                                    }
                                case "Spear":
                                    {
                                        controller1.weapon = null;
                                        controller1.PickUpAxe();
                                        break;
                                    }
                                default:
                                    {
                                        controller2.weapon = null;
                                        break;
                                    }
                            }
                            break;
                        }
                    case "Spear":
                        {
                            switch (controller2.weapon)
                            {
                                case "Hammer":
                                    {
                                        controller1.weapon = null;
                                        controller1.PickUpSpear();
                                        break;
                                    }
                                case "Axe":
                                    {
                                        controller2.weapon = null;
                                        controller2.PickUpAxe();
                                        break;
                                    }
                                case "Spear":
                                    {
                                        break;
                                    }
                                default:
                                    {
                                        controller2.weapon = null;
                                        break;
                                    }
                            }
                            break;
                        }
                    default:
                        {
                            controller1.weapon = null;
                            break;
                        }
                }

                battle = true;
                controller1.battle = true;
                controller2.battle = true;
                timeLeft = battleTime;
            }
        }
        else
        {
            if (timeLeft >= 0)
            {
                timeLeft--;
            }
            else
            {
                battle = false;
                controller1.battle = false;
                controller2.battle = false;
                timeLeft = chooseTime;
            }
        }
    }
}
