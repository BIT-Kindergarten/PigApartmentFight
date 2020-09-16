//锁定视角在玩家(target)身上
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    public float currentZoom = 10f;//视角缩放
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float ZoomSpeed = 4f;

    public float currentYaw = 0f;//视角移动
    public float YawSpeed = 100f;

    public float height = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;//滚轮控制视角缩放
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw -= Input.GetAxis("Horizontal") * YawSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * height);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
