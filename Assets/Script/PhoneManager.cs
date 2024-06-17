using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    public bool phoneNotInUse = true;
    public Animator phoneAnim;


    public GameObject confirmPanel;
    public GameObject appScreen;

    // Start is called before the first frame update
    void Start()
    {
        confirmPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (phoneNotInUse)
            {
                //use phone
                phoneNotInUse = false;
            }
            else if (!phoneNotInUse)
            {
                phoneNotInUse = true;
            }

            UsingPhone(phoneNotInUse);
        }
    }

    public void UsingPhone(bool status)
    {
        if (!status)
        {
            phoneAnim.SetTrigger("isEntering");
        }
        else if (status)
        {
            ExitPhone();
        }
    }

    public void ExitPhone()
    {
        phoneAnim.SetTrigger("isExiting");
    }

    public void TextApp()
    {

    }

    public void QuitGameApp()
    {
        confirmPanel.SetActive(false);
    }

    public void AcceptQuit()
    {
        Application.Quit();
    }
    public void DeclineQuit()
    {
        confirmPanel.SetActive(true);
    }

    
}
