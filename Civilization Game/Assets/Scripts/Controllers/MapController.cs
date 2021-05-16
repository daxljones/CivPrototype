using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    const int sizeX = 250, sizeY = 250;
    public GameObject grasseTilePrefab;

    public GameObject[] resources;
    GameObject[,] mapGrid;
   
    void Start()
    {
        mapGrid = new GameObject[sizeX, sizeY];

        for(int i = 0; i < sizeX; i++)
        {
            for(int j = 0; j < sizeY; j++)
            {
                mapGrid[i, j] = Instantiate(grasseTilePrefab);
                mapGrid[i, j].transform.position = new Vector3(i, j, j + 5);
                Tile tile = mapGrid[i, j].GetComponent<Tile>();
                tile.setPos(i, j);

                if(Random.Range(0, 8) == 0)
                {
                    GameObject resource = Instantiate(resources[Random.Range(0, resources.Length)]);
                    resource.transform.position = new Vector3(i, j + 0.5f, j + 0.5f);
                    tile.setOccupation(resource);
                }
            }
        }
    }


    public GameObject getTile(int x, int y)
    {
        return mapGrid[x, y];
    }
    
}
