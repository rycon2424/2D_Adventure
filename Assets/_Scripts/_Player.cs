using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Player : MonoBehaviour
{

    public float speed;
    public Animator playerAnim;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }
    
    void Update()
    {
        PlayerAnimation();
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        
    }

    void PlayerAnimation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerAnim.Play("Walk_Left");
            return;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerAnim.Play("Walk_Right");
            return;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            playerAnim.Play("Walk_Back");
            return;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerAnim.Play("Walk_Forward");
            return;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.Play("Idle_Back");
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.Play("Idle_Forward");
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnim.Play("Idle_Left");
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.Play("Idle_Right");
        }
    }

}