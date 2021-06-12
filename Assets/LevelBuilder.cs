using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] int depth = 5;
    [SerializeField] int pieceHeight = 3;
    [SerializeField] int minBasicsFirst = 3;

    [SerializeField] GameObject basicPiece;
    [SerializeField] GameObject[] modularPieces;
    [SerializeField] GameObject floorPiece;

    private void Start()
    {
        for (int i = 0; i < depth; i++)
        {
            if (i == depth - 1)
            {
                Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - pieceHeight * i);
                Instantiate(floorPiece, spawnPosition, Quaternion.identity, transform);
            }
            else if (i < minBasicsFirst)
            {
                Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - pieceHeight * i);
                Instantiate(basicPiece, spawnPosition, Quaternion.identity, transform);
            }
            else
            {
                Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - pieceHeight * i);

                int rand = UnityEngine.Random.Range(0, modularPieces.Length);

                Instantiate(modularPieces[rand], spawnPosition, Quaternion.identity, transform);
            }
        }
    }

    public int GetFloorYPos()
    {
        return depth * pieceHeight * -1;
    }
}
