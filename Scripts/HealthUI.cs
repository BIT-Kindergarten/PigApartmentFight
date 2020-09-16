//实现血条显示
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class HealthUI : MonoBehaviour
{
    public GameObject uiPrefab;
    public Transform target;

    float existingtime = 5;//血条持续时间
    float lastchangetime;//上一次血条改变的时间点

    Transform ui;
    Image healthSlider;
    Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;

        foreach(Canvas c in FindObjectsOfType<Canvas>())
        {
            if(c.renderMode == RenderMode.WorldSpace)//找到指定的canvas
            {
                ui = Instantiate(uiPrefab, c.transform).transform;
                healthSlider = ui.GetChild(0).GetComponent<Image>();
                ui.gameObject.SetActive(false);
                break;
            }
        }
        GetComponent<CharacterStats>().OnHealthChanged += OnHealthChanged;
    }

    void OnHealthChanged(int maxHealth,int currentHealth)
    {
        if (ui != null)
        {
            ui.gameObject.SetActive(true);
            lastchangetime = Time.time;
            float HealthPercent = (float)currentHealth/maxHealth;
            healthSlider.fillAmount = HealthPercent;
            if (currentHealth <= 0)
            {
                Destroy(ui.gameObject);//死亡时去除血条
            }
        }
    }

    private void LateUpdate()
    {
        if (ui != null)
        {
            ui.position = target.position;
            ui.forward = -cam.forward;

            if(Time.time - lastchangetime >= existingtime)
            {
                ui.gameObject.SetActive(false);//超出时间时不显示
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
