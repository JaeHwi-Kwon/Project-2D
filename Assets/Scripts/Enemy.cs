using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Enemy : MonoBehaviour
{
    //몬스터 기본 스테이터스
    [Header("Mob Status")]
    private float health;
    public float max_health;
    private Rigidbody2D rigidbody;

    [Header("Attribute")]
    public Transform Player;
    public enum Atk_Pattern { Jump, Walk };
    public Atk_Pattern AttackPattern;

    [Header("Jump Attribute")]
    public float jumpCD;
    private float jumpCDprivate;
    public float jumpPow;
    public float jumpMaxDistance;

    [Header("Walk Attribute")]
    public float walk_movSpd;

    // Start is called before the first frame update
    void Start()
    {
        health = max_health;
        jumpCDprivate = jumpCD;
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack(AttackPattern.ToString());
        jumpCDprivate -= Time.deltaTime;
        if(health <= 0) { Destroy(gameObject); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            GameObject bullet = collision.gameObject;
            health -= bullet.GetComponent<Bullet>().bulletDmg;
            Destroy(bullet);
        }
    }

    private void Jump()
    {
        if (jumpCDprivate <= 0)
        {
            float Xdiff = Player.position.x - transform.position.x;
            Xdiff = Mathf.Clamp(Xdiff, -jumpMaxDistance, jumpMaxDistance);
            Debug.Log("Mob has Pushed by " + new Vector2(Xdiff, jumpPow) + " Vector");
            rigidbody.AddForce(new Vector2(Xdiff, jumpPow), ForceMode2D.Impulse);
            jumpCDprivate = jumpCD;
        }
    }

    private void Walk()
    {
        float Xdiff = Player.position.x - transform.position.x;
        float calculated_Spd = Mathf.Sign(Xdiff) * walk_movSpd * Time.deltaTime;
        transform.Translate(new Vector2(calculated_Spd,0));
    }

    private void Attack(string FuncName)
    {
        Invoke(FuncName, 0);
    }

}
