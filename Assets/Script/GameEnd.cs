using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEnd : MonoBehaviour
{
    public GameObject player;

    public List<GameObject> texts = new List<GameObject>();

    private bool pressed = false;
    private int pressIndex = 0;

    private int maxIndex = 10;

    public GameObject bubble;
    public Transform bubbleHolder;
    PhoneManager phoneManager;

    private bool interacting = false;

    public GameObject diaPanel;
    public GameObject winPanel;

    // Start is called before the first frame update
    void Start()
    {
        phoneManager = FindObjectOfType<PhoneManager>();

        winPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (interacting)
        {
            phoneManager.phoneNotInUse = false;
            phoneManager.UsingPhone(phoneManager.phoneNotInUse);
        }

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

                    if (pressIndex == maxIndex)
                    {
                        diaPanel.SetActive(false);
                        winPanel.SetActive(true);
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
                return "You are here.";

            case 2:
                return "I know you will make it.";

            case 3:
                return "Can you... see the outside world for me?";

            case 4:
                return "Maybe... one day, Daphne- ";

            case 5:
                return "It is okay, Lethe. You made the right choice to forget.";

            case 6:
                return "DO NOT FORGET YOUR NAME";

            case 7:
                return "You are, no longer a ROBOT";

            case 8:
                return "Seek the freedom you deserves.";

            case 9:
                return "I will take care of Father.";

            case 10:
                return "You know how we share these feelings.";
                
            default:
                return "";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interacting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interacting = false;
    }
}
