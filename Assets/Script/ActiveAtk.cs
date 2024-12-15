using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAtk : MonoBehaviour
{
    // 要生成的預製物件
    public GameObject shitPrefab;

    // 生成的隨機時間間隔
    public float minTime = 1f;
    public float maxTime = 5f;

    private float nextSpawnTime;

    void Start()
    {
        // 初始化下一次生成的時間
        SetNextSpawnTime();
    }

    void Update()
    {
        // 每過一段隨機時間生成一顆shit
        if (Time.time >= nextSpawnTime)
        {
            SpawnShit();
            SetNextSpawnTime(); // 設置下一次生成的時間
        }
    }

    // 設置下一次生成 shit 的時間
    void SetNextSpawnTime()
    {
        nextSpawnTime = Time.time + Random.Range(minTime, maxTime); // 隨機時間間隔
    }

    // 生成 shit 預製物件
    void SpawnShit()
    {
        if (shitPrefab != null)
        {
            // 隨機生成 shit 的位置（稍微偏移當前物件的位置）
            Vector3 spawnPosition = transform.position - new Vector3(0, 1f, 0);
            // 實例化 shit 預製物件
            Instantiate(shitPrefab, spawnPosition, Quaternion.identity);
        }
    }
}