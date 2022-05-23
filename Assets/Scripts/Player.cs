using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpd; // 플레이어가 이동하는 속도
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");

        Vector2 inputDir = new Vector2(hAxis,0).normalized;

        rigidbody.velocity = inputDir * moveSpd;
    }
}
