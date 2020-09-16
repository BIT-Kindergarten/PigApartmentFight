//玩家控制脚本
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerControl : MonoBehaviour
{

    public Interactable focus;
    //public LayerMask movementmask;
    Camera cam;
    PlayerMotor motor;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))//鼠标左键点击
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))//指向点击的位置
            {
                motor.Moveto(hit.point);//移动到鼠标点击位置

                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))//鼠标右键点击
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))//指向点击的位置
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus(Interactable newfocus)//设置焦点（即玩家指向点）
    {
        if(newfocus!=focus)
        {
            if(focus!=null)
                focus.Defocused();
            
        }
        focus = newfocus;
        newfocus.Onfocused(transform);
        //motor.Moveto(newfocus.transform.position);//交互的同时移动向该物品
        motor.FollowTarget(newfocus);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.Defocused();
        focus = null;
        motor.StopFollow();
    }
}
