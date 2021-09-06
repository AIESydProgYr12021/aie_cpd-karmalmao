using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    MovePlayer mp;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ToMenu()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            SceneManager.LoadScene("AndroidMenu");
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }
    public void OnQuit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if(mp.deadlmao == true)
        {
            
        }
    }
}
