//可交互物品基类
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;//可交互范围

    bool isfocus = false;//判断是否已经focus
    bool interacted = false;//防止二次interact
    Transform player;

    public virtual void Interact()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void Onfocused(Transform playertransform)
    {
        isfocus = true;
        player = playertransform;
        interacted = false;
    }

    public void Defocused()
    {
        isfocus = false;
        player = null;
        interacted = false;
    }

    private void Update()
    {
        if(isfocus && !interacted)//判断是否focus在该物品
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if(distance<= radius)//如果二者距离在radius内，则可交互
            {
                interacted = true;
                Interact();
            }
        }
    }
}
