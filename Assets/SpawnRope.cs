using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRope : MonoBehaviour
{
    [SerializeField] float initialYOffset = 2f;
    [SerializeField] float ySize = 2f;
    [SerializeField] int ropePerMod = 3;
    [SerializeField] GameObject ropePrefab;

    private void Start()
    {
        //int numToSpawn = ropePerMod * LevelBuilder.Instance.GetDepth() * 100;
        int numToSpawn = ropePerMod * 100;

        for (int i = 0; i < numToSpawn; i++)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + initialYOffset + ySize * i, transform.position.z);
            Instantiate(ropePrefab, spawnPosition, Quaternion.identity, transform);
        }
    }
}
