using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawn : MonoBehaviour
{
    public GameObject rock;
    public Terrain terrain;
    public GameObject player;
    public float sizeX = 100;
    public float sizeY = 100;
    // Start is called before the first frame update
    void Start()
    {
        spawnRocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawnRocks()
    {
        for (float i = 0; i < sizeX;i++)
        {
            for (float j = 0; j < sizeY; j++)
            {
                Instantiate(rock, new Vector3(terrain.transform.position.x + Random.Range(terrain.transform.position.x, terrain.transform.position.x - 500), player.transform.position.y, Random.Range(terrain.transform.position.z, terrain.transform.position.z + 150)), rock.transform.rotation);
            }
        }
    }
}
