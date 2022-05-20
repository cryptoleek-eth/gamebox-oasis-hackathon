using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    private float spawnRate;
    private bool isCoroutineReady = true;
    private float minHeight = -1f;
    private float maxHeight = 1f;

    private void Awake()
    {
        SetSpawnRate(GameManager.Difficulty.Easy);
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(GetSpawnRate());
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        isCoroutineReady = true;
        yield return null;
    }

    private void Update()
    {
        SetSpawnRate(GameManager.GetDifficulty());

        if (isCoroutineReady)
        {
            isCoroutineReady = false;
            StartCoroutine(Spawn());
        }
    }

    private void SetSpawnRate(GameManager.Difficulty difficulty)
    {
        switch (difficulty)
        {
            case (GameManager.Difficulty.Impossible):
                spawnRate = 0.8f;
                break;
            case (GameManager.Difficulty.Hard):
                spawnRate = 1f;
                break;
            case (GameManager.Difficulty.Medium):
                spawnRate = 1.2f;
                break;
            case (GameManager.Difficulty.Easy):
                spawnRate = 1.5f;
                break;
        }
    }

    private float GetSpawnRate()
    {
        return spawnRate;
    }
}
