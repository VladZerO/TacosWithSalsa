using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public static GridGenerator instance;


    [SerializeField] private GameObject midTilePrefab;
    [SerializeField] private GameObject sideTilePrefab;


    [SerializeField] private int amountOfRows;
    [SerializeField] private int tilesPerRow;

    [SerializeField] private int tileWidth;
    [SerializeField] private int tileLength;

   
    private List<GameObject> createdTiles = new List<GameObject>();
    private List<GameObject> createdRows = new List<GameObject>();

    private GameObject[,] tileGrid;


    private int rowIndexToGenerate;
    private int currentFurthestRow;

    private void Awake()
    {
        //<< Generate singleton
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }



    void Start()
    {
        FirstGeneration();
    }


    public void StepOnTile(int lnTileRow)
    {
        if (lnTileRow == rowIndexToGenerate)
        {
            currentFurthestRow++;
            rowIndexToGenerate++;

            GenerateNewRow(currentFurthestRow);            
        }
    }


    private void GenerateNewRow(int x)
    {
        for (int y = 0; y < tilesPerRow; y++)
        {
            GameObject loTilePrefab;

            if (y == 0)
            {
                loTilePrefab = Instantiate(sideTilePrefab);
                loTilePrefab.transform.position = new Vector3(-tileWidth + (y * tileWidth), 0.0f, tileLength * x);
                loTilePrefab.transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);

            }
            else if (y == tilesPerRow - 1)
            {
                loTilePrefab = Instantiate(sideTilePrefab);
                loTilePrefab.transform.position = new Vector3(-tileWidth + (y * tileWidth), 0.0f, tileLength * x);
            }
            else
            {
                loTilePrefab = Instantiate(midTilePrefab);
                loTilePrefab.transform.position = new Vector3(-tileWidth + (y * tileWidth), 0.0f, tileLength * x);
            }

            createdTiles.Add(loTilePrefab);
            //<< Getting the coords of each grid.
            //tileGrid[x, y] = loTilePrefab;

            loTilePrefab.GetComponent<Tile>().SetTile(x, y);
        }
    }

    private void FirstGeneration()
    {
        tileGrid = new GameObject[amountOfRows, tilesPerRow];

        for (int x = 0; x < amountOfRows; x++)
        {
            GenerateNewRow(x);
        }

        //<< Sets the latest generated row as the currentFurthestRow
        rowIndexToGenerate = amountOfRows / 2;
        currentFurthestRow = amountOfRows - 1;

    }
}
        
    

