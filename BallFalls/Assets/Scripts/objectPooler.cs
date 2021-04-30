using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPooler : MonoBehaviour
{
    public static objectPooler instance;
    public GameObject BallPrefab;
    public Transform[] spawnPoints;
    public int BallsinPool;
    public Transform tBalls;
    public int numOfSpawnBall;
    List<GameObject> pooledBallList;
    List<GameObject> spawnedBallList;
    public GameObject RemoveEffect;
    public int  StartBallNum;

    // Start is called before the first frame update
    void Start()
    {
        BallPoolsystem();
        spawnedBallList = new List<GameObject>(BallsinPool);
        StartBallNum = 0;
    }

    public void BallPoolsystem()
    {
        pooledBallList = new List<GameObject>(BallsinPool);
        for (int i = 0; i < BallsinPool; i++)
        {
            InstantiateBall();
        }
    }

    public void InstantiateBall()
    {
        GameObject Ballgo = Instantiate(BallPrefab, tBalls);
        Ballgo.SetActive(false);
        pooledBallList.Add(Ballgo);
    }


    public void spawnBall()
    {
        Color BallColor = new Color(
      Random.Range(0f, 1f),
      Random.Range(0f, 1f),
      Random.Range(0f, 1f));
        
        StartCoroutine(spwaneachBall(StartBallNum,BallColor));
        StartBallNum += numOfSpawnBall;
        


    }



    public IEnumerator RemoveBalls()
    {
        if (spawnedBallList.Count != 0)
        {
            for (int i = 0; i < numOfSpawnBall; i++)
            {
                GameObject removedBall = spawnedBallList[0];
                removedBall.SetActive(false);
                GameObject go =Instantiate(RemoveEffect, removedBall.transform.position, removedBall.transform.rotation);
                Destroy(go, 0.2f);
                spawnedBallList.RemoveAt(0);
                pooledBallList.Add(removedBall);
                yield return new WaitForSeconds(0.01f);

            }
        }
    }

    public void RemoveBallButton()
    {
        StartCoroutine(RemoveBalls());
        StartBallNum -= numOfSpawnBall;
    }



     public IEnumerator spwaneachBall(int initNum ,Color _color)
    {
        if (StartBallNum >= BallsinPool)
        {
            for (int i = 0; i < numOfSpawnBall; i++)
            {
                InstantiateBall();
            }
            
            BallsinPool += numOfSpawnBall;
        }

        for (int i = initNum; i < initNum + numOfSpawnBall; i++)
        {
            
                
            GameObject spBall = pooledBallList[i];
            spawnedBallList.Add(spBall);
            
        }
        for (int i = initNum; i < initNum+numOfSpawnBall; i++)
        {
            GameObject spBall = pooledBallList[i];
            spBall.GetComponent<SpriteRenderer>().color = _color;
            spBall.SetActive(true);
            spBall.transform.position = new Vector2(Random.Range(-5.0f, 5.0f), 8.5f);
            
            
            yield return new WaitForSeconds(0.05f);
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) )
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 worldPoint2d = new Vector2(worldPoint.x, worldPoint.y);
            if(worldPoint2d.y<4.5f)
                spawnBall();
        }
    }

}
