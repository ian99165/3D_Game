using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk : MonoBehaviour
{
    public float minX = -30f;
    public float maxX = 30f;
    public float minZ = -30f;
    public float maxZ = 30f;

    // 設定隨機移動的速度
    public float moveSpeed = 3f;

    // 目前的目標位置
    private Vector3 targetPosition;

    // 要生成的預製物件
    public GameObject shitPrefab;

    // 生成的隨機時間間隔
    public float minTime = 1f;
    public float maxTime = 5f;

    private float nextSpawnTime;

    void Start()
    {
        // 在開始時隨機選擇一個目標位置
        SetRandomTargetPosition();

        // 初始化下一次生成的時間
        SetNextSpawnTime();
    }

    void Update()
    {
        // 計算移動的步伐
        float step = moveSpeed * Time.deltaTime;

        // 移動鳥向目標位置
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // 旋轉鳥朝向目標位置
        Vector3 direction = targetPosition - transform.position;
        if (direction.sqrMagnitude > 0.01f) // 防止在接近目標時會造成不必要的旋轉
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
        }

        // 如果接近目標位置，就重新設置目標位置
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }

        // 每過一段隨機時間生成一顆shit
        if (Time.time >= nextSpawnTime)
        {
            SpawnShit();
            SetNextSpawnTime(); // 設置下一次生成的時間
        }
    }

    // 設置隨機的目標位置
    void SetRandomTargetPosition()
    {
        // 生成隨機的 X 和 Z 坐標在指定範圍內
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        // 設定新的目標位置
        targetPosition = new Vector3(randomX, transform.position.y, randomZ); // 假設鳥的 Y 軸位置保持不變
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
            // 隨機生成 shit 的位置（可以調整生成的位置範圍）
            Vector3 spawnPosition = transform.position - new Vector3(0, 1f, 0);

            // 實例化 shit 預製物件
            Instantiate(shitPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
