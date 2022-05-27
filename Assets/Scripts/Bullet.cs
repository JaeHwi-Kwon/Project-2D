using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpd;
    public Transform bullet;
    public float bulletDmg;
    private float bulletLifeTime;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
        bulletLifeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 view = Camera.main.WorldToScreenPoint(transform.position);
        bullet.Translate(new Vector2(bulletSpd* Time.deltaTime,0));
        bulletLifeTime += Time.deltaTime;

        if (bulletLifeTime > 3)
        {
            Destroy(gameObject);
        }
    }
}
