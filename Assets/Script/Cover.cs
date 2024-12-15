using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour
{
    // 参考的玩家物体
    public GameObject player;

    void Update()
    {
        if (player != null)
        {
            // 更新 Cover 的 X 和 Z 位置，Y 轴保持不变
            Vector3 newPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.position = newPosition;
        }
    }
}