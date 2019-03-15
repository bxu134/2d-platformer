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

    private void OnCollisionEnter2D(Collision2D collision) 
    //while enemy is moving right and facing right and collides w/ player, enemy will switch sides
    //while enemy is moving left and facing left and colldies w/ player, enemy will not switch sides
    {
        if (facingRight = true && collision.gameObject.tag == "Player")
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

}
