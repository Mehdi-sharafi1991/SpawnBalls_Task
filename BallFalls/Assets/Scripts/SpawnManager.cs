using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    objectPooler ObjPollerSC;
    // Start is called before the first frame update
    void Start()
    {
        ObjPollerSC = objectPooler.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ObjPollerSC.spawnBall();
        }
    }
}
