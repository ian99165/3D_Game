using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;

    public float _hp = 3f;  // 初始生命值

    // 使用 OnTriggerEnter 來處理觸發事件
    private void OnTriggerEnter(Collider other)
    {
        // 檢查碰到的物件名稱是否為 "shit"
        if (other.gameObject.name == "shit(Clone)")
        {
            // 減少生命
            HpKill();
        }
    }

    public void HpKill()
    {
        // 減少生命值
        _hp--;

        // 根據生命值改變相應的 HP 顯示物件
        if (_hp == 2)
        {
            Destroy(HP1);  // 當 _hp 等於 2 時，摧毀 HP1 物件
        }
        else if (_hp == 1)
        {
            Destroy(HP2);  // 當 _hp 等於 1 時，摧毀 HP2 物件
        }
        else if (_hp == 0)
        {
            Destroy(HP3);  // 當 _hp 等於 0 時，摧毀 HP3 物件
            GameOver();     // 呼叫 GameOver() 方法，載入 GameOver 場景
        }

        // 確保 _hp 不會小於 0
        if (_hp < 0)
        {
            _hp = 0;
        }
    }

    // 當生命值歸零時載入 GameOver 場景
    private void GameOver()
    {
        // 載入 GameOver 場景
        SceneManager.LoadScene("GameOver");  // 請確認場景名稱為 "GameOver"
    }
}