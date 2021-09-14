using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{




    public Rigidbody rb;
    public float hzMovement;
    public float jumpForce;
    public bool onAndroid = false;
    public bool deadlmao = false;
    public float speedCap = 20f;
    public float speed = 12f;
    public float speedMultiplier = 1f;
    public bool able = true;


    public bool isGrounded;



    // Start is called before the first frame update




    void Start()
    {

        transform.position = new Vector3(15, 2, -25);

        if (Application.platform == RuntimePlatform.Android)
        {
            onAndroid = true;
        }
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        Controls();
        AndroidControls();
        SlowDown();



        if (deadlmao == true)
        {
            //dead menu enabled here <<<<<<<
            Time.timeScale = 0;
            SceneManager.LoadScene("Menu");
        }

    }

    public void Controls()
    {
        // movement
        Vector3 localVel = rb.velocity;
        localVel.x = Input.GetAxis("Horizontal") * hzMovement;
        localVel.z = speed * speedMultiplier;
        rb.velocity = localVel;


        //jump
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(0, jumpForce, 0);
            }
        }

        if (speed < speedCap)
        {
            speed += 0.2f * Time.deltaTime;
        }
    }
    public void AndroidControls()
    {
        if (onAndroid)
        {
            transform.Translate((Input.acceleration.x * hzMovement * Time.deltaTime), 0, 0);
        }
    }
    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(0, jumpForce, 0);
        }
    }
    public void SlowDown()
    {
        if (able)
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {

                if (stamina.instance.currentStamina > 1f)
                {
                    speedMultiplier = 0f;

                }
                stamina.instance.UseStamina(0.1f);
                if (stamina.instance.currentStamina < 1f)
                {
                    able = false;
                    speedMultiplier = 1f;
                }
            }
            else
            {
                speedMultiplier = 1f;

            }
            able = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            deadlmao = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = false;
        }
    }


}


