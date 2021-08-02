using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : Mirror.NetworkBehaviour
{
    public float moveSpeed = 8.0f;
    public float maxTurnSpeed = 5.0f;       //TODO: Later derive these from player settings file
    public Rigidbody playerRigidBody;
    public Transform turnTransform;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    public void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Vector3.up, -maxTurnSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.up, maxTurnSpeed);
        }
    }

    //public void MoveTowards(Vector3 _moveDir)
    //{
    //    Vector3 moveDir = _moveDir * moveSpeed * Time.deltaTime;
    //    playerRigidBody.velocity = moveDir;
    //}

    //public void TurnDirection(Vector3 _turnDir)
    //{
    //    if(_turnDir != Vector3.zero)
    //    {
    //        var targetRotation = Quaternion.LookRotation(_turnDir);
    //        turnTransform.rotation = Quaternion.Slerp(turnTransform.rotation, targetRotation, Mathf.Clamp(turnSpeed * Time.deltaTime, 0.0f, 1.0f));
    //    }
    //}
}
