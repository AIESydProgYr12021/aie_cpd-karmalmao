using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{

    public Rigidbody rb;
    public float movementSpeed;
    public float jumpForce;
    public bool onAndroid = false;
    public float forwardSpeed = 15;
    bool deadlmao = false;

    Vector3 localVel;




    [SerializeField] private VirtualJoystick input;
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
        localVel = rb.velocity;

        localVel.z = 12;
        localVel.x = Input.GetAxis("Horizontal") * movementSpeed;

        rb.velocity = localVel;

        while (isGrounded)
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
            transform.Translate((Input.acceleration.x * movementSpeed * Time.deltaTime) / 2, 0,0);
        }
        if (deadlmao == true)
        {
            Time.timeScale = 0;

            Debug.Log("get happy");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = true;
        }
        if (collision.gameObject.layer == 6)
        {
            deadlmao = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.layer == 3)
        {
            isGrounded = false;
        }
    }


}


