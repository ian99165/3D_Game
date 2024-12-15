using UnityEngine;

public class PickUp : MonoBehaviour
{
    // 這個變數可以在編輯器中設置指定的GameObject
    public GameObject targetObject;

    private CD cdScript;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        // 檢查碰撞物件是否名稱為"item"
        if (other.gameObject.name == "item(Clone)")
        {
            // 刪除物件
            Destroy(other.gameObject);

            // 確保引用的cdScript不為空，然後調用ActivateShield和SetCD方法
            if (cdScript != null)
            {
                // 啟動Shield
                cdScript.ActivateShield();

                // 設置新的冷卻時間，這裡設置為5秒，您可以根據需要修改
                cdScript.SetCD(5f);
            }
        }
    }
}