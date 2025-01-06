using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_GhostTrail : MonoBehaviour
{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    [SerializeField] GameObject echo;
    [SerializeField] Player_Movement dash;
    [SerializeField] float instanceLife = 2f;

       

    // Update is called once per frame
    void Update()
    {
        if (dash != null) { GhostTrailPlayer(); }
        PickupTrail();
    }

    

    private void GhostTrailPlayer()
    {  
       if (dash.direction != 0)
       {
              if (timeBtwSpawns <= 0)
              {
                    GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                    Destroy(instance, instanceLife);
                    timeBtwSpawns = startTimeBtwSpawns;
              }
              else
              {
                    timeBtwSpawns -= Time.deltaTime;
              }
       }  
    }
    private void PickupTrail()
    {
        if (tag == "BadBox" || tag == "GoodBox" || tag == "LifeBox")
        {
            if (timeBtwSpawns <= 0)
            {
                GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                Destroy(instance, instanceLife);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }

    
}
