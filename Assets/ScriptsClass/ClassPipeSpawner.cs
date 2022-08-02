using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassPipeSpawner : MonoBehaviour
{
    public GameObject pipeset;
    public GameObject pipeCollector;
    public Transform[] spawnPoints;
    public float timer = 10f;
    public float timeleft = 10f;
    // Start is called before the first frame update
    void Start()
    {
        timeleft = timer;
        pipeCollector = transform.Find("PipeColector").gameObject;


    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdatePipeSpawner()
    {
        timeleft -= Time.deltaTime;
        if (timeleft < 0)
        {
            Vector3 pos = new Vector3((float)spawnPoints[0].position.x, Random.Range((float)spawnPoints[0].position.y, (float)spawnPoints[1].position.y),0);
          
            var var = Instantiate()
        }
    }
}
