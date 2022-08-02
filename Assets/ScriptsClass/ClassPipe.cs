using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassPipe : MonoBehaviour
{
    public float speed = 4f;
    public float endtime = 5f;
    private ClassGameScipt gamescript;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Death());
        gamescript = GameObject.Find("Game Controller").GetComponent<ClassGameScipt>();
    }

    // Update is called once per frame
    void Update()
    {

       transform.position += Vector3.left * speed * Time.deltaTime;
        
        
    }
    private IEnumerator Death()
    {
        yield return new WaitForSeconds(endtime);
        Destroy(gameObject);
    }
}
