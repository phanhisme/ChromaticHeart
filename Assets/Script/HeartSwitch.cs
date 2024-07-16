using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSwitch : MonoBehaviour
{
    public List<Sprite> heartIcons = new List<Sprite>();
    public int currentHeartIndex = 0;

    public SpriteRenderer iconHolder;

    public float coolDown;

    public Feels currentFeels;
    public enum Feels { FEAR, WARMTH, SADNESS};

    public GameObject[] PurpleGate;
    public GameObject[] YellowGate;
    public GameObject[] BlueGate;

    public Level currentLevel;
    public enum Level { Door, Bridge};

    void Start()
    {
        PurpleGate = GameObject.FindGameObjectsWithTag("Purple");
        YellowGate = GameObject.FindGameObjectsWithTag("Yellow");
        BlueGate = GameObject.FindGameObjectsWithTag("Blue");

        //if (PurpleGate != null && YellowGate != null && BlueGate != null)
        //{
        //    box1 = PurpleGate.GetComponent<BoxCollider2D>();
        //    box2 = YellowGate.GetComponent<BoxCollider2D>();
        //    box3 = BlueGate.GetComponent<BoxCollider2D>();
        //}

        currentFeels = Feels.FEAR;
        iconHolder.sprite = heartIcons[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentHeartIndex < heartIcons.Count)
            {
                currentHeartIndex++;
            }
            else
                currentHeartIndex = 0;
            
            GetKey(currentHeartIndex);
        }

        if (PurpleGate != null && YellowGate != null && BlueGate != null)
        {
            if (currentLevel == Level.Door)
            {
                if (currentFeels == Feels.FEAR)
                {
                    foreach (GameObject go in PurpleGate)
                    {
                        BoxCollider2D box = go.GetComponent<BoxCollider2D>();
                        box.enabled = false;
                    }

                    foreach (GameObject go in YellowGate)
                    {
                        BoxCollider2D box = go.GetComponent<BoxCollider2D>();
                        box.enabled = true;
                    }

                    foreach (GameObject go in BlueGate)
                    {
                        BoxCollider2D box = go.GetComponent<BoxCollider2D>();
                        box.enabled = true;
                    }
                }

                else if (currentFeels == Feels.WARMTH)
                {
                    foreach (GameObject go in PurpleGate)
                    {
                        BoxCollider2D box = go.GetComponent<BoxCollider2D>();
                        box.enabled = true;
                    }

                    foreach (GameObject go in YellowGate)
                    {
                        BoxCollider2D box = go.GetComponent<BoxCollider2D>();
                        box.enabled = false;
                    }

                    foreach (GameObject go in BlueGate)
                    {
                        BoxCollider2D box = go.GetComponent<BoxCollider2D>();
                        box.enabled = true;
                    }
                }

                else if (currentFeels == Feels.SADNESS)
                {
                    foreach (GameObject go in PurpleGate)
                    {
                        BoxCollider2D box = go.GetComponent<BoxCollider2D>();
                        box.enabled = true;
                    }

                    foreach (GameObject go in YellowGate)
                    {
                        BoxCollider2D box = go.GetComponent<BoxCollider2D>();
                        box.enabled = true;
                    }

                    foreach (GameObject go in BlueGate)
                    {
                        BoxCollider2D box = go.GetComponent<BoxCollider2D>();
                        box.enabled = false;
                    }
                }
            }
            
        }
    }

    public void GetKey(int index)
    {
        switch (index)
        {
            case 0:
                currentFeels = Feels.FEAR;
                iconHolder.sprite = heartIcons[0];
                break;

            case 1:
                currentFeels = Feels.WARMTH;
                iconHolder.sprite = heartIcons[1];
                break;

            case 2:
                currentFeels = Feels.SADNESS;
                iconHolder.sprite = heartIcons[2];
                break;
        }

    }
}
