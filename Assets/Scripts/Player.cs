using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpd; // 플레이어가 이동하는 속도
    public float jmpForce; // 플레이어가 점프하는 힘
    public GameObject bullet; // 인스턴스화 할 총알 오브젝트
    public float bulletSpd; // 발사하는 총알의 발사 주기

    private Rigidbody2D rigidbody;
    private Vector2 MousePosition;
    private float shootCD;

    private bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
        shootCD = 0;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Move();
        Jump();
        Attack();
        shootCD += Time.deltaTime;
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

    void Attack()
    {
        if (Input.GetMouseButton(0) && shootCD >= bulletSpd)
        {
            float degree = GetAngle(ConvVec3toVec2(transform.position), MousePosition);
            Quaternion dir = ConvDirByVec2(degree);
            GameObject instBullet = Instantiate(bullet, transform.position, dir);
            shootCD = 0;
        }
    }

    private Vector2 ConvVec3toVec2(Vector3 vec)
    {
        return new Vector2(vec.x, vec.y);
    }

    private float GetAngle(Vector2 start, Vector2 end)
    {
        Vector2 deltaVec = end - start;
        return Mathf.Atan2(deltaVec.y, deltaVec.x) * Mathf.Rad2Deg;
    }

    private Quaternion ConvDirByVec2(float dir)
    {
        Quaternion angle = Quaternion.Euler(0, 0, dir);
        return angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
