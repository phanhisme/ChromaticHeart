using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameFlow : MonoBehaviour
{
    public GameObject player;

    public List<GameObject> texts = new List<GameObject>();

    private bool pressed = false;
    private int pressIndex = 0;

    private int maxIndex = 15;

    public TextMeshProUGUI info;

    public GameObject bubble;
    public Transform bubbleHolder;
    PhoneManager phoneManager;

    void Start()
    {
        phoneManager = FindObjectOfType<PhoneManager>();

        phoneManager.phoneNotInUse = false;
        phoneManager.UsingPhone(phoneManager.phoneNotInUse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressed = true;
            if (pressed)
            {
                if (pressIndex <= maxIndex - 1) //start with 0
                {
                    pressIndex++;

                    GameObject newBubble = Instantiate(bubble, bubbleHolder);
                    texts.Add(newBubble);

                    TextMeshProUGUI text = newBubble.GetComponentInChildren<TextMeshProUGUI>();
                    text.text = CheckPressIndex();

                    PlayerController controller = player.GetComponent<PlayerController>();
                    
                    switch (pressIndex)
                    {
                        case 4:
                            info.text = "Press A or D to move";
                            controller.enabled = true;
                            break;

                        case 5:
                            info.text = "Press Space to Jump";
                            break;

                        case 6:
                            controller.enabled = false;
                            break;

                        case 8:
                            info.text = "<size=65%>Beito powers #R2, the lower the power, the harder to navigate the world";
                            break;

                        case 10:
                            info.text = "<size=65%>As the power runs low, press Q to recharge";
                            break;

                        case 13:
                            controller.enabled = true;
                            info.text = "Press F to interact";
                            break;

                        case 15:
                            info.text = "<size=80%>Press Escape to turn off phone";
                            break;
                    }

                    pressed = false;
                }
            }
        }
    }

    private string CheckPressIndex()
    {
        switch (pressIndex)
        {
            case 1:
                return "Thank gods above, you are awake!";

            case 2:
                return "I know it's been a long time since you last walked...";

            case 3:
                return "You can't possibly forget everything, can you?";

            case 4:
                return "It's okay, press A and D on your control panel to walk.";

            case 5:
                return "You can also jump with Spacebar!";

            case 6:
                return "Alright, good, you get the basics.";

            case 7:
                return "I think you are running out of power, Leth";

            case 8:
                return "There are some batteries inside your poket.";

            case 9:
                return "Beitos are rarely produced these day, ";

            case 10:
                return "You should use this wisely";

            case 11:
                return "I would love to spend more time with you, Sis";

            case 12:
                return "But you have to leave this place immediately.";

            case 13:
                return "Interact with the panel in front of you...";

            case 14:
                return "and the door will open for you.";

            case 15:
                return "I will wait for you at the main entrance.";

            default:
                return "";
        }
    }

    IEnumerator WaitForSeconds(float time)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1;
    }
}
