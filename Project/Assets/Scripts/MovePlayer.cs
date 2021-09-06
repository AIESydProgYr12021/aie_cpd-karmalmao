using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


        if (Input.GetKey(KeyCode.S))
        {
            speedMultiplier = 0.7f;
        }
        else
        {
            speedMultiplier = 1f;
        }


        Vector3 localVel = rb.velocity;

        if (speed < speedCap)
        {
            speed += 0.5f * Time.deltaTime;
        }
        localVel.x = Input.GetAxis("Horizontal") * hzMovement;
        localVel.z = speed * speedMultiplier;
        rb.velocity = localVel;

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(0, jumpForce, 0);
            }
        }





        if (onAndroid)
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && isGrounded)
            {
                rb.AddForce(0, jumpForce, 0);
            }
            transform.Translate((Input.acceleration.x * hzMovement * Time.deltaTime) / 2, 0, 0);
        }
        if (deadlmao == true)
        {


            //dead menu enabled 


            Time.timeScale = 0;
            SceneManager.LoadScene("Menu");
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


