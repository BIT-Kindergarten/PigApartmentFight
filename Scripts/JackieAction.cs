using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 控制Jackie移动
public class JackieAction : MonoBehaviour
{
    //控制动画
    private Animator anim;

    //摄像头随角色移动
    private Vector3 offset = Vector3.zero;
    private Camera mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        // 获取动画组件
        anim = GetComponent<Animator>();

        // 初始时获取模型和摄像机的偏移值
        mainCamera = Camera.main;
        offset = mainCamera.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /**
         *  控制动画 
         */
        float vertical = Input.GetAxis("Vertical");         // 垂直轴 （W、S或者上下键）
        float horizontal = Input.GetAxis("horizontal");     // 水平轴（A、D或者左右键）
        Vector3 dir = new Vector3(horizontal, 0, vertical);     // 方向向量

        if ( dir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir);      // 旋转
            // 如果按了Q速度更快
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Translate( Vector3.forward * 20 * Time.deltaTime );
            }
            else
            {
                transform.Translate(Vector3.forward * 6 * Time.deltaTime);
            }
            anim.SetBool("walk", true);     //播放行走动画
        }
        else
        {
            anim.SetBool("walk", false);      //播放站立动画
        }

        /**
         * 按空格键跳跃
         */
         if ( Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = transform.position + new Vector3(0, 2.0f, 0);
        }

        /**
         *摄像头跟随人物 
         */
        mainCamera.transform.position = transform.position + offset;
        // TODO, 摄像头朝向怎么变化
    }
}
