using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//필수 컴포넌트가 부착이 되지 않은 상태로 실행되는것을 방지하고,
//적혀진 해당 컴포넌트를 부착해주는 상태로 시작하는 RequireCompoenent/.
[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
   [SerializeField] public float moveSpeed = 5;
    PlayerController controller;
    Camera viewCamera;


    private void Start()
    {
        controller = GetComponent<PlayerController>();
        viewCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if(groundPlane.Raycast(ray,out rayDistance))
            {
            Vector3 point = ray.GetPoint(rayDistance);
            //Debug.DrawLine(ray.origin, point, Color.red);

            controller.LookAt(point);
        }

    }
}
