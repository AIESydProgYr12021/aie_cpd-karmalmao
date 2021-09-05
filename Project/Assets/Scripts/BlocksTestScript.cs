using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksTestScript : MonoBehaviour
{
    public GameObject[] blockPrefabs; //size gets set in inspector! drag prefabs in there!
    void Start()
    {

    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter()
    {
        levelmanagment.instance.offset.z = levelmanagment.instance.offset.z + 250;
        //levelmanagment.instance.offset.y = levelmanagment.instance.offset.z - 0.001f;
        Random.Range(0, blockPrefabs.Length);
        GameObject segment = Instantiate(blockPrefabs[Random.Range(0, blockPrefabs.Length)], levelmanagment.instance.offset, Quaternion.identity);

        levelmanagment.instance.list.Add(segment);

        if(levelmanagment.instance.list.Count > 2)
        {
            Destroy(levelmanagment.instance.list[0]);
            levelmanagment.instance.list.RemoveAt(0);
        }

    }

  

   
}
