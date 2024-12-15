using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;  // 用來指定生成的物件預製件
    public float spawnInterval = 5f;  // 生成間隔，設為5秒
    public float destroyDelay = 3f;   // 銷毀延遲，設為3秒

    // Start is called before the first frame update
    void Start()
    {
        // 每隔 spawnInterval 秒生成一次物件
        InvokeRepeating("SpawnItem", 0f, spawnInterval);
    }

    // 生成物件的方法
    void SpawnItem()
    {
        // 隨機生成 X 和 Z 坐標在指定範圍內
        float randomX = Random.Range(-10f, 10f);
        float randomZ = Random.Range(-10f, 10f);
        Vector3 spawnPosition = new Vector3(randomX, 1f, randomZ); // 這裡 Y 固定為 1，您可以根據需要調整

        // 生成物件
        GameObject item = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);

        // 延遲3秒後銷毀該物件
        Destroy(item, destroyDelay);
    }
}