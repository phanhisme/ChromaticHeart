using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableOpen : MonoBehaviour
{
    private bool isLocked = true;
    private bool interacting = false;

    public GameObject door;
    public GameObject hint;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interacting)
        {
            if (isLocked)
            {
                hint.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    OpenDoor();
                }
            }
        }
        else
            hint.SetActive(false);
    }

    private void OpenDoor()
    {
        Animator doorAnim = door.GetComponent<Animator>();
        doorAnim.SetTrigger("isOpen");

        BoxCollider2D box2D = door.GetComponent<BoxCollider2D>();
        box2D.enabled = false;
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
