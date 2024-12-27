using UnityEngine;

public class PickUp : MonoBehaviour
{
    // 指定的GameObject和隱藏物件
    public GameObject targetObject;
    public GameObject hiddenObject; // 隱藏的物件

    private CD cdScript;
    private int itemCount = 0; // 記錄撿到的物件數量
    private int maxItems = 3; // 撿到的最大數量

    private void Start()
    {
        // 確保在Start中取得指定GameObject上的CD腳本
        if (targetObject != null)
        {
            cdScript = targetObject.GetComponent<CD>();
        }
        else
        {
            Debug.LogWarning("未指定CD腳本的目標物件!");
        }

        // 確保隱藏的物件初始為隱藏狀態
        if (hiddenObject != null)
        {
            hiddenObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "item(Clone)")
        {
            // 刪除物件
            Destroy(other.gameObject);

            // 增加計數
            itemCount++;

            // 確保引用的cdScript不為空，然後調用ActivateShield和SetCD方法
            if (cdScript != null)
            {
                // 啟動Shield
                cdScript.ActivateShield();

                // 設置新的冷卻時間，這裡設置為5秒，您可以根據需要修改
                cdScript.SetCD(5f);
            }

            // 如果撿到的物件數量達到目標，顯示隱藏物件
            if (itemCount >= maxItems && hiddenObject != null)
            {
                hiddenObject.SetActive(true);
                Debug.Log("隱藏物件已啟用!");
            }
        }
    }
}