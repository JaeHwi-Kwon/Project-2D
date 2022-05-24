using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpd; // 플레이어가 이동하는 속도
    private Rigidbody2D rigidbody;
    public float jmpForce;

    private bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");

        Vector2 inputDir = new Vector2(hAxis, 0).normalized;

        this.transform.Translate(inputDir * moveSpd * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!isJumping)
            {
                isJumping = true;
                rigidbody.AddForce(Vector2.up*jmpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
