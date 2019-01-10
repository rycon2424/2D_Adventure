using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Player : MonoBehaviour
{

    public float speed;
    private float originalSpeed;
    public Animator playerAnim;

    void Start()
    {
        originalSpeed = speed;
        playerAnim = GetComponent<Animator>();
    }
    
    void Update()
    {
        PlayerAnimation();
        PlayerMovement();
    }

    #region Player Movement/Animation

    void PlayerMovement()
    {
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
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            speed = originalSpeed * 0.75f;
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            speed = originalSpeed * 0.75f;
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            speed = originalSpeed * 0.75f;
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            speed = originalSpeed * 0.75f;
        }
        else
        {
            speed = originalSpeed;
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

#endregion

}