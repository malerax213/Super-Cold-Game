using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MainCharMovement : MonoBehaviour
{

    public GameObject crosshair;
    public GameObject FPSCamera;
    public float horizontalSpeed;
    public float verticalSpeed;
    public Vector3 v;
    public float h1, v1;
    public RectTransform panelGameOver;
    public Text gameOver;
    public int health = 10;
    public int enemiesLeft;
    public bool won = false;
    public GameObject nextLevelButton;

    public EventHandler gameOverEvent;

    public void OnGameOver()
    {
        if(gameOverEvent != null)
        {
            gameOverEvent(this, EventArgs.Empty);
        }
    }

    void Start()
    {
        enemiesLeft = 4;
        gameOverEvent += OnGameOverEvent;
        Cursor.visible = false;
    }

    private void OnGameOverEvent(object sender, System.EventArgs e)
    {
        Cursor.visible = true;
        crosshair.SetActive(false);
        panelGameOver.gameObject.SetActive(true);
        if (won)
        {
            nextLevelButton.SetActive(true);
            gameOver.text = "YOU WON";
        }
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;
        if(enemiesLeft == 0)
        {
            won = true;
            OnGameOver();
        }
        v = new Vector3(0, 0, 0);
        h1 = horizontalSpeed * Input.GetAxis("Mouse X");
        v1 = verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(0, h1, 0);
        FPSCamera.transform.Rotate(-v1, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            v = new Vector3(0, 0, 0.1f);
            transform.Translate(v);
        }
        else
        {
            if (Input.GetKey(KeyCode.S))
            {
                v = new Vector3(0, 0, -0.1f);
                transform.Translate(v);
            }
            else
            {
                if (Input.GetKey(KeyCode.A))
                {
                    v = new Vector3(-0.1f, 0, 0);
                    transform.Translate(v);
                }
                else
                {
                    if (Input.GetKey(KeyCode.D))
                    {
                        v = new Vector3(0.1f, 0, 0);
                        transform.Translate(v);
                    }
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            health = 0;
            OnGameOver();
        }
    }

}