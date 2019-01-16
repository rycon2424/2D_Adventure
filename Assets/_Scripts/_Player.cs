using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Player : MonoBehaviour
{

    public float speed;
    private float originalSpeed;
    public Animator playerAnim;

    private _PlayerPartyStats gameManager;

    void Start()
    {
        originalSpeed = speed;
        playerAnim = GetComponent<Animator>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<_PlayerPartyStats>();
    }
    
    void Update()
    {
        PlayerAnimation();
        PlayerMovement();
        Pause();

        if (Input.GetKeyDown(KeyCode.O))
        {
            gameManager.IncreaseParty("Ivan", Random.Range(1,20), Random.Range(1, 20), Random.Range(1, 20), Random.Range(1, 20));
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameManager.IncreaseParty("Rebecca", Random.Range(1, 20), Random.Range(1, 20), Random.Range(1, 20), Random.Range(1, 20));
        }
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

    #region Logistics
    public GameObject pauseMenu;
    private bool pauseMenuSwitch = false;
    private void Pause()
    {
        pauseMenuSwitch = pauseMenu.activeSelf;
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            pauseMenuSwitch = !pauseMenuSwitch;
            pauseMenu.SetActive(pauseMenuSwitch);
        }
    }
    #endregion

}