using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{

    public Transform teleportTo;

    public GameObject ui;
    private Animator uiAnimator;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        uiAnimator = GameObject.FindGameObjectWithTag("PlayerCanvas").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(Transition());
        }
    }

    IEnumerator Transition() {
        uiAnimator.Play("FadeAnimation");
        yield return new WaitForSecondsRealtime(0.75f);
        player.transform.position = teleportTo.transform.position;
    }

}