using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelmanagment : MonoBehaviour
{
    public static levelmanagment instance;
    public List<GameObject> list = new List<GameObject>();
    public Vector3 offset;




    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
