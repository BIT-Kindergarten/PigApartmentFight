using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLOOR : MonoBehaviour
{
    public GameObject obj;
    public GameObject obj1;
    // Start is called before the first frame update
    void Start()
    {
        int temp;
        int mask;
        temp = Random.Range(1,3);
        mask = Random.Range(1, 3);
        if (temp == 1)

            Instantiate(obj, new Vector3(-69, -1, 0), Quaternion.identity);
        if (mask == 2)
            Instantiate(obj1, new Vector3(-69, -1, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}