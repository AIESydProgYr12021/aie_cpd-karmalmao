using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class androidhud : MonoBehaviour
{

    public bool onAndroid = false;
    public GameObject PCHud;
    public GameObject AndroidHud;

    public void SetAndroidActive()
    {
        AndroidHud.SetActive(true);
        PCHud.SetActive(false);
    }
    public void SetPCActive()
    { 
        PCHud.SetActive(true);
        AndroidHud.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor)
        {
            onAndroid = true;
            SetAndroidActive();
        }
        else SetPCActive();
    }



    // Update is called once per frame
    void Update()
    {
        if (onAndroid)
        {
            // whatever extra needed here
        }
    }
}
