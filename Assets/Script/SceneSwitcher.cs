using UnityEngine;
using UnityEngine.SceneManagement; // 用於場景管理

public class SceneSwitcher : MonoBehaviour
{
    // 時間間隔，單位為秒
    public float delay = 30f;
    // 目標場景名稱
    public string targetScene = "S2";

    void Start()
    {
        // 在指定的延遲後切換場景
        Invoke("SwitchScene", delay);
    }

    // 切換場景的方法
    void SwitchScene()
    {
        // 切換到指定的場景
        SceneManager.LoadScene(targetScene);
    }
}