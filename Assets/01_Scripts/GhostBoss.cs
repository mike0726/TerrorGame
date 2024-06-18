using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBoss : MonoBehaviour
{
    public int maxEnemies;
    public float rateInstance;
    public float timeInstance;
    public GameObject enemie;
    //[SerializeField]
    //public Vector2 instanceLimits;
    public float[] limitsX;
    public int countEnemies;
    void Start()
    {
        
    }

    
    void Update()
    {


        timeInstance += Time.deltaTime * 0.3f;
        if (timeInstance > rateInstance)
        {

            timeInstance = 0.0f;
            EnemieCreator();
        }


    }

    public void EnemieCreator()
    {
        if(countEnemies<maxEnemies)
        {
            Instantiate(enemie, new Vector2(limitsX[Random.Range(0, 2)], Random.Range(-14, 3)), Quaternion.identity);
            countEnemies++;
        }
        
    }

   
}
