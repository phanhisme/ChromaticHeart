using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject player;

    private bool interacting = false;

    public GameObject timelineHolder;
    public PlayableDirector timeline;

    // Start is called before the first frame update
    void Start()
    {
        timeline = timelineHolder.GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interacting)
        {
            timeline.Play();

            Rigidbody2D controller = player.GetComponent<Rigidbody2D>();
            controller.bodyType = RigidbodyType2D.Static;

            Animator anim = player.GetComponent<Animator>();
            anim.SetTrigger("isIdle");


            Wait(2);
            controller.bodyType = RigidbodyType2D.Dynamic;
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

    IEnumerator Wait(float time)
    {
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(time);

        Time.timeScale = 1;
    }
}
