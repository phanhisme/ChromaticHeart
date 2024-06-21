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

    void Start()
    {
        
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
