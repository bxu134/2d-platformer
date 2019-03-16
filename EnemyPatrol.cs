using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;

    public Transform groundDetection;

    public float rayDist;

    private Vector3 distFromPlayer;
    private Transform targetPos;

    private bool facingRight;
    private bool movingRight = true;

    private bool lastDirRight;

    public GameObject Player;

    private bool isGrounded;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayDist);

        if (groundInfo.collider == false)
        {
            if (lastDirRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        else
        {
            lastDirRight = movingRight;
        }

    }

}
