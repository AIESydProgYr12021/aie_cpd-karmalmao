using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{

    public bool onAndroid = false;
    public GameObject PCMenu;
    public GameObject AndroidMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("thanks brackeys lmao");
        Application.Quit();
    }
    public void SetAndroidActive()
    {
        AndroidMenu.SetActive(true);
        PCMenu.SetActive(false);
    }
    public void SetPCActive()
    {
        PCMenu.SetActive(true);
        AndroidMenu.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            onAndroid = true;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (onAndroid)
        {
            SetAndroidActive();
        }
        else SetPCActive();
    }
}
