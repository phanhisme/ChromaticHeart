using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartActivate : MonoBehaviour
{
    public GameObject playerHeart;

    private bool interacting = false;
    private bool activatingHeart = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interacting)
        {
            if (!activatingHeart)
            {
                playerHeart.SetActive(true);
                activatingHeart = true;

                Destroy(this.gameObject);
            }
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
