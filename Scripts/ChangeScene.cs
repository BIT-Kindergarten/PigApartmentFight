//切换场景脚本
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChangeScene(string SceneName)
    {
        if (SceneName == "GameIntroduction")
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("BGM1"));
        else if (SceneName != "StartScene")
            Destroy(GameObject.FindGameObjectWithTag("BGM1"));
        if (SceneName == "AboutUs")
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("BGM2"));
        else if (SceneName != "FinalScene")
            Destroy(GameObject.FindGameObjectWithTag("BGM2"));
        Application.LoadLevel(SceneName);
    }

    public void ChangeToLast()//切换至上一个场景
    {
        string name = PlayerPrefs.GetString("name");
        Application.LoadLevel(name);
    }

    public void ChangeToNext()//切换至下一个场景
    {
        string name = PlayerPrefs.GetString("name");
        if (name == "Instruction")
            name = "Level1";
        else
            name = "Level2";
        Application.LoadLevel(name);
    }
}
