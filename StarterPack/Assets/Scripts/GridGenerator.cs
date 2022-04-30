using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{

    [SerializeField] private GameObject midTilePrefab;
    [SerializeField] private GameObject sideTilePrefab;


    [SerializeField] private int amountOfRows;
    [SerializeField] private int tilesPerRow;

    [SerializeField] private int tileWidth;
    [SerializeField] private int tileLength;



    private List<GameObject> createdTiles = new List<GameObject>();
    private List<GameObject> createdRows = new List<GameObject>();

    private GameObject[,] tileGrid;

    void Start()
    {
        tileGrid = new GameObject[amountOfRows, tilesPerRow];

        for (int x = 0; x < amountOfRows; x++)
        {
            for (int y = 0; y < tilesPerRow; y++)
            {
                GameObject loTilePrefab;
                
                if (y == 0)
                {
                    loTilePrefab = Instantiate(sideTilePrefab);
                    loTilePrefab.transform.position = new Vector3(-tileWidth + (y * tileWidth), 0.0f, tileLength * x);
                    
                }
                else if (y == tilesPerRow - 1)
                {
                    loTilePrefab = Instantiate(sideTilePrefab);
                    loTilePrefab.transform.position = new Vector3(-tileWidth + (y * tileWidth), 0.0f, tileLength * x);
                    loTilePrefab.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                }
                else
                {
                    loTilePrefab = Instantiate(midTilePrefab);
                    loTilePrefab.transform.position = new Vector3(-tileWidth + (y * tileWidth), 0.0f, tileLength * x);
                }

                createdTiles.Add(loTilePrefab);
                //<< Getting the coords of each grid.
                tileGrid[x, y] = loTilePrefab;
            }
        }
    }

}
        
    

