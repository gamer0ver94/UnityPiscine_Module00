using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Gameover : MonoBehaviour
{
    public GameObject player;
    public Terrain t;
    public int posX;
    public int posZ;
    public float[] textureValues;
    public GameObject canvas;


  
    public void GameIsOver() {
        t = Terrain.activeTerrain;
        textureValues = new float[t.terrainData.alphamapLayers];
        if (player != null)
        {
            GetTerrainTexture();
            if (textureValues[1] == 1)
            {
                Debug.Log("Gameover");
                canvas.SetActive(true);
                Destroy(player);
            }
        }
    }
    public void GetTerrainTexture()
    {
        ConvertPosition(player.transform.position);
        CheckTexture();
    }
    void ConvertPosition(Vector3 playerPosition)
    {
        Vector3 terrainPosition = playerPosition - t.transform.position;
        Vector3 mapPosition = new Vector3
        (terrainPosition.x / t.terrainData.size.x, 0,
        terrainPosition.z / t.terrainData.size.z);
        float xCoord = mapPosition.x * t.terrainData.alphamapWidth;
        float zCoord = mapPosition.z * t.terrainData.alphamapHeight;
        posX = (int)xCoord;
        posZ = (int)zCoord;
    }
    void CheckTexture()
    {
        float[,,] aMap = t.terrainData.GetAlphamaps(posX, posZ, 1, 1);
        textureValues[0] = aMap[0, 0, 0];
        textureValues[1] = aMap[0, 0, 1];
        textureValues[2] = aMap[0, 0, 2];

    }
}