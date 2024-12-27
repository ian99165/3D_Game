using UnityEngine;
using TMPro; // 引入 TextMeshPro 命名空間

public class TextAnimation : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // TextMeshPro 元件
    public float animationInterval = 0.5f; // 每幀動畫間隔時間（秒）

    private string baseText = "Skip"; // 基本文字
    private int currentStep = 0; // 當前動畫步驟

    void Start()
    {
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshPro component is not assigned.");
            return;
        }

        // 開始動畫 Coroutine
        StartCoroutine(AnimateText());
    }

    private System.Collections.IEnumerator AnimateText()
    {
        while (true)
        {
            // 設置當前文字
            textMeshPro.text = baseText + new string('>', currentStep);

            // 更新步驟（0 到 3 循環）
            currentStep = (currentStep + 1) % 4;

            // 等待下一幀
            yield return new WaitForSeconds(animationInterval);
        }
    }
}