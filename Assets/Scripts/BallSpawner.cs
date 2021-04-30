using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject BadBallPrefab;
    public GameObject GoodBallPrefab;

    private GameObject[] BadBalls;
    private GameObject[] GoodBalls;

    public int badBallCount = 30;
    public int goodBallCount = 15;
    private Vector3 randPosition;
    
    void Start()
    {
        BadBalls = new GameObject[badBallCount];
        GoodBalls = new GameObject[goodBallCount];

        for(int i=0; i<badBallCount; i++)
        {
            randPosition = new Vector3(Random.Range(-20, 20), Random.Range(10, 20), Random.Range(-20, 20));
            BadBalls[i] = Instantiate(BadBallPrefab, randPosition, Quaternion.identity);
        }
        for (int i = 0; i < goodBallCount; i++)
        {
            randPosition = new Vector3(Random.Range(-20, 20), Random.Range(10, 20), Random.Range(-20, 20));
            GoodBalls[i] = Instantiate(GoodBallPrefab, randPosition, Quaternion.identity);
        }
    }

}
