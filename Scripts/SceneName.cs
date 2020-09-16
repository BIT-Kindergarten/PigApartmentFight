//获取当前场景名称
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneName : MonoBehaviour
{

    public string name;


    // Start is called before the first frame update
    void Start()
    {
        name = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("name", name);//将当前场景名存储，以便后续使用
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
