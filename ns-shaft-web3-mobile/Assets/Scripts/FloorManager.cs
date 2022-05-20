using UnityEngine;

public class FloorManager : MonoBehaviour
{
    private float spawnRate = 0.8f;
    float spawnTimer;
    public GameObject[] blockPrefabs;
    public Transform floorPool;

    private void Start()
    {
        SpawnFloorPool();
        PickNewBlock();
    }

    void SpawnFloorPool()
    {
        int basicAmount = 6;
        for (int i = 0; i < blockPrefabs.Length; i++)
        {
            int spawnAmount = i == 1 || i == 2 ? basicAmount / 2 : basicAmount;
            for (int j = 0; j < spawnAmount; j++)
            {
                GameObject block = Instantiate(blockPrefabs[i], floorPool);
                block.SetActive(false);
            }
        }
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > 1 / spawnRate)
        {
            PickNewBlock();
            spawnTimer = 0;
        }
    }

    void PickNewBlock()
    {
        int r = 0;
        do
        {
            r = Random.Range(0, floorPool.childCount);
        } while (floorPool.GetChild(r).gameObject.activeInHierarchy);

        GameObject block = floorPool.GetChild(r).gameObject;
        block.SetActive(true);
        block.GetComponent<BoxCollider2D>().enabled = true;
        block.transform.localPosition = new Vector2(Random.Range(-2f, 2f), -8f);
    }
}
