using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public TerrainLayer terrainLayer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        terrainLayer.tileOffset = new Vector2 (terrainLayer.tileOffset.x + Time.deltaTime,0);
     
    }
}
