using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    public Transform Objects;

    public Transform player_pos;

    public int map_distance = 20;

    private Stage[] stagelist;

    public void LoadingMap()
    {
        foreach (var item in stagelist)
        {
            bool b = map_distance > Vector2.Distance(item.pos.position, player_pos.position);

            item.gameObject.SetActive(b);
            item.tile.SetActive(b);
        }
    }




    void Start()
    {
        stagelist = Objects.GetComponentsInChildren<Stage>();
    }

    // Update is called once per frame
    void Update()
    {
        LoadingMap();
    }
}
