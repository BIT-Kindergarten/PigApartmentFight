//玩家移动
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;

    // 动画
    //Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // 获取动画组件
        //anim = GetComponentInChildren<Animator>();
        //anim.SetBool("walk", false);      //播放站立动画
    }

    public void Moveto (Vector3 point)//移动
    {
        agent.SetDestination(point);
        //anim.SetBool("walk", true);     //播放行走动画
    }

    public void FollowTarget (Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .8f;//确保停止距离在radius内，而不是一定要走到物品里面
        agent.updateRotation = false;
        target = newTarget.transform;
        
    }

    public void StopFollow ()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
        //anim.SetBool("walk", false);      //播放站立动画
    }

    public void FaceTarget()//面向target
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            agent.SetDestination(target.position);
            //anim.SetBool("walk", true);     //播放行走动画
            FaceTarget();
        }
        //else
        //{
        //    anim.SetBool("walk", false);      //播放站立动画
        //}

        /**
         * 按空格键跳跃
         */
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    transform.position = transform.position + new Vector3(0, 2.0f, 0);
        //}
    }


}
