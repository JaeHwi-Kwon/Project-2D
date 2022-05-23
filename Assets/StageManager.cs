using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    public GameObject[] stages;




    void SetStage(int n)
    {
        for(int i=0; i < stages.Length ; i++)
        {
                stages[i].SetActive(i == n);
        }
    }










    void Start()
    {
        SetStage(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
