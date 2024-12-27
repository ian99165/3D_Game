using UnityEngine;

public class xx : MonoBehaviour
{
    public GameObject objectToEnable; // 要啟用的物件

    // 此方法將與按鈕的 OnClick 事件綁定
    public void EnableObject()
    {
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(false);
        }
    }
}