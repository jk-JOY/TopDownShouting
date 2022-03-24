using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ʼ� ������Ʈ�� ������ ���� ���� ���·� ����Ǵ°��� �����ϰ�,
//������ �ش� ������Ʈ�� �������ִ� ���·� �����ϴ� RequireCompoenent/.
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
