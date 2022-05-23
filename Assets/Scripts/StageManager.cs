using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    public Transform[] stages;

    public Transform player_pos;

    public int map_distance = 20;


    public void LoadingMap()
    {
        foreach (var item in stages)
        {
            item.parent.gameObject.SetActive(map_distance > Vector2.Distance(item.position, player_pos.position));
        }
    }




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LoadingMap();
    }
}
