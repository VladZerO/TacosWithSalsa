using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{

    [SerializeField] private GameObject gridPrefab;

    [SerializeField] private int amountOfGrids;
    [SerializeField] private int gridLength;

    private List<GameObject> createdGrids = new List<GameObject>();

    void Start()
    {
        for (int x = 0; x < amountOfGrids; x++)
        {
            GameObject loGridPrefab = Instantiate(gridPrefab);
            loGridPrefab.transform.position = new Vector3(0.0f, 0.0f, gridLength * x);
            createdGrids.Add(loGridPrefab);
        }
    }

}
        
    

