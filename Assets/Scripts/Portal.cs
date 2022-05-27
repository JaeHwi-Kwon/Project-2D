using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public Transform Enter;

    private float cooltime = 0;

    void Start()
    {
        if (Enter == null)
            Debug.Log("포탈 출구가 없음");
    }

    private void Update()
    {
        if (cooltime > 0)
            cooltime -= Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player" && cooltime <= 0)
        {
            collision.transform.position = Enter.position;

            if (Enter.GetComponent<Portal>() != null)
                Enter.GetComponent<Portal>().cooltime = 3;
        }
    }
}
