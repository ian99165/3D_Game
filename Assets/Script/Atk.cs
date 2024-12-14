using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk : MonoBehaviour
{
    public float minX = -500f;
    public float maxX = 500f;
    public float minZ = -500f;
    public float maxZ = 500f;

    // 設定隨機移動的速度
    public float moveSpeed = 3f;

    // 目前的目標位置
    private Vector3 targetPosition;

    void Start()
    {
        // 在開始時隨機選擇一個目標位置
        SetRandomTargetPosition();
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
}
