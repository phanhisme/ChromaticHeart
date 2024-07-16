
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    private bool interacting = false;

    private void Update()
    {
        if (interacting)
        {
            SceneManager.LoadScene(sceneName);
            interacting = false;
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
