using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] int THREE_LASER_INDEX = 2;

    [SerializeField] int minDepth = 10;
    private int depth;
    [SerializeField] int pieceHeight = 3;
    [SerializeField] int minBasicsFirst = 3;

    [SerializeField] GameObject[] basicPieces;
    [SerializeField] GameObject[] specialPieces;
    [SerializeField] GameObject floorPiece;

    private bool lastPlacedWas3Laser = false;
    private bool lastPlacedWasBasic = true;

    public static LevelBuilder Instance { get; private set; }

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
        depth = PersistentSceneManager.Instance.GetCurrentLevel() + minDepth;

        for (int i = 0; i < depth; i++)
        {
            if (i == depth - 1)
            {
                Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - pieceHeight * i);
                Instantiate(floorPiece, spawnPosition, Quaternion.identity, transform);
                lastPlacedWas3Laser = false;
                lastPlacedWasBasic = false;
            }
            else if (i < minBasicsFirst)
            {
                SpawnBasic(i);
            }
            else
            {
                if (lastPlacedWas3Laser)
                {
                    SpawnBasic(i);
                }
                else
                {
                    int randChanceOfBasic = UnityEngine.Random.Range(0, specialPieces.Length + 1);

                    if (randChanceOfBasic == 0)
                    {
                        SpawnBasic(i);
                    }
                    else
                    {
                        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - pieceHeight * i);

                        int rand = UnityEngine.Random.Range(0, specialPieces.Length);

                        if (!lastPlacedWasBasic && rand == THREE_LASER_INDEX)
                        {
                            rand = UnityEngine.Random.Range(0, THREE_LASER_INDEX);
                        }

                        Instantiate(specialPieces[rand], spawnPosition, Quaternion.identity, transform);

                        lastPlacedWasBasic = false;

                        if (rand == THREE_LASER_INDEX)
                        {
                            lastPlacedWas3Laser = true;
                        }
                    }
                }
            }
        }
    }

    private void SpawnBasic(int i)
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - pieceHeight * i);

        int rand = UnityEngine.Random.Range(0, basicPieces.Length);
        Instantiate(basicPieces[rand], spawnPosition, Quaternion.identity, transform);
        lastPlacedWas3Laser = false;
        lastPlacedWasBasic = true;
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
