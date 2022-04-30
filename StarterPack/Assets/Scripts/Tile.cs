using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    private int tileRow;

    private int tileColumn;

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GridGenerator.instance.StepOnTile(tileRow);
        }
    }

    public void SetTile(int lnTileRow, int lnTileColumn)
    {
        tileRow = lnTileRow;
        tileColumn = lnTileColumn;
    }
}
