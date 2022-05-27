using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //몬스터 기본 스테이터스
    [Header("몬스터 스테이터스")]
    private float health;
    public float max_health;

    [Header("Settings")]
    public GameObject Health_Bar;

    // Start is called before the first frame update
    void Start()
    {
        health = max_health;
    }

    // Update is called once per frame
    void Update()
    {
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
}
