using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    Vector3 moveDir;
    public float speed = 5f;
    CharacterController charController;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        moveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        moveDir *= speed;

        Move(moveDir);
    }
    public void Move(Vector3 dir)
    {
        charController.Move(dir * Time.deltaTime);
    }
}
