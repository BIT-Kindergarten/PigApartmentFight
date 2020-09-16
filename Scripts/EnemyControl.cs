//敌人控制脚本
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    public float lookRadius = 10f;

    // 动画
    Animator anim;

    Transform target;
    NavMeshAgent agent;
    CharacterCombat charactercombat;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.Player.transform;
        agent = GetComponent<NavMeshAgent>();
        charactercombat = GetComponent<CharacterCombat>();
        // 获取动画组件
        //anim = GetComponent<Animator>();

        //anim.SetBool("mutantAttack", false);      //停止攻击swiping动画
        //anim.SetBool("mutantwalk", false);      //播放站立动画
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void FaceTarget()//面向target
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // Update is called once per frame
    void Update()//设置敌人始终面向玩家
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance<=agent.stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if(targetStats != null)
                {
                    charactercombat.Attack(targetStats);
                  
                }
                FaceTarget();
            }
        }
    }

}
