using UnityEngine;
using System.Collections;  // 添加这个命名空间以使用协程

public class PickUp : MonoBehaviour
{
    // 指定的GameObject和隱藏物件
    public GameObject targetObject;
    public GameObject hiddenObject; // 隱藏的物件
    public GameObject CavanObject;

    private CD cdScript;
    private int itemCount = 0; // 記錄撿到的物件數量
    private int maxItems = 3; // 撿到的最大數量

    public AudioClip pickupSound;  // 撿到物品時播放的音效
    private AudioSource audioSource;  // 用於播放音效的 AudioSource

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

        // 初始化 AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "item(Clone)")
        {
            // 刪除物件
            Destroy(other.gameObject);

            // 播放撿到物品的音效
            if (pickupSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(pickupSound);
            }

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
                CavanObject.SetActive(true);
                Debug.Log("隱藏物件已啟用!");

                // 启动协程，10秒后再次隐藏 hiddenObject，1.2秒后隐藏 CavanObject
                StartCoroutine(HideObjectsAfterDelay(10f, 1.2f));
            }
        }
    }

    // 协程：延迟指定时间后再次隐藏物体
    private IEnumerator HideObjectsAfterDelay(float delayForHiddenObject, float delayForCavanObject)
    {
        // 等待指定的时间后隐藏 CavanObject
        yield return new WaitForSeconds(delayForCavanObject);
        if (CavanObject != null)
        {
            CavanObject.SetActive(false);
        }
        Debug.Log("CavanObject已隱藏!");

        // 等待指定的时间后隐藏 hiddenObject
        yield return new WaitForSeconds(delayForHiddenObject - delayForCavanObject);  // 剩余的时间
        if (hiddenObject != null)
        {
            hiddenObject.SetActive(false);
        }
        Debug.Log("隱藏物件已隱藏!");
    }
}
