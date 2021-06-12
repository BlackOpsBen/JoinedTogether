using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] int depth = 5;
    [SerializeField] int pieceHeight = 3;
    [SerializeField] int minBasicsFirst = 3;

    [SerializeField] GameObject[] basicPieces;
    [SerializeField] GameObject[] specialPieces;
    [SerializeField] GameObject floorPiece;

    public static LevelBuilder Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

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

                int rand = UnityEngine.Random.Range(0, basicPieces.Length);
                Instantiate(basicPieces[rand], spawnPosition, Quaternion.identity, transform);
            }
            else
            {
                Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - pieceHeight * i);

                int rand = UnityEngine.Random.Range(0, specialPieces.Length);

                Instantiate(specialPieces[rand], spawnPosition, Quaternion.identity, transform);
            }
        }
    }

    public float GetFloorYPos()
    {
        return depth * pieceHeight * -1;
    }

    public int GetDepth()
    {
        return depth;
    }
}
