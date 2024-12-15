using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CD : MonoBehaviour
{
    public float cooldownTime;  // 可設置冷卻時間或倒計時
    private float currentCooldownTime = 0f;

    public TextMeshProUGUI cooldownText;

    public bool isSkillReady;

    private string skillType;

    public GameObject Cover;

    void Start()
    {
        skillType = gameObject.name;

        // 判斷是遊戲倒數 (CD_I) 還是技能冷卻 (CD_II)
        if (skillType == "CD_I")
        {
            cooldownTime = 20f; // 設定遊戲倒數的時間（20秒）
            isSkillReady = false;  // 倒數計時不會是技能準備好
        }
        else if (skillType == "CD_II")
        {
            cooldownTime = 0f;  // 例如設定技能冷卻時間（10秒）
            isSkillReady = true;  // 假設一開始技能是準備好的
        }

        currentCooldownTime = cooldownTime;
    }

    void Update()
    {
        // 遊戲倒數時間 (CD_I)
        if (skillType == "CD_I" && !isSkillReady)
        {
            currentCooldownTime -= Time.deltaTime;

            if (currentCooldownTime <= 0)
            {
                currentCooldownTime = 0;
                isSkillReady = true; // 倒數完成，遊戲進程結束或觸發其他事件
                SceneManager.LoadScene("GameWin");  // 假設倒數結束後載入勝利場景
            }
        }

        // 技能冷卻時間 (CD_II)
        if (skillType == "CD_II" && !isSkillReady)
        {
            currentCooldownTime -= Time.deltaTime;

            if (currentCooldownTime <= 0)
            {
                currentCooldownTime = 0;
                isSkillReady = true;
                Cover.SetActive(false); // 冷卻結束，技能可用
            }
        }

        // 更新倒數顯示
        UpdateCooldownUI();
    }

    private void UpdateCooldownUI()
    {
        if (cooldownText != null)
        {
            // 顯示倒數時間
            if (currentCooldownTime == 0)
            {
                if (skillType == "CD_I")
                {
                    cooldownText.text = "OK";  // 顯示遊戲結束或倒數完成
                }
                else if (skillType == "CD_II")
                {
                    cooldownText.text = "0"; // 顯示技能準備好
                }
            }
            else
            {
                cooldownText.text = Mathf.Ceil(currentCooldownTime).ToString(); // 顯示倒數時間
            }
        }
    }

    public void SetCD(float newCooldownTime)
    {
        if (skillType == "CD_II")
        {
            currentCooldownTime = newCooldownTime;
            Cover.SetActive(true);  // 顯示冷卻覆蓋層
            isSkillReady = false;
        }
    }

    public void ActivateShield()
    {
        if (skillType == "CD_II" && isSkillReady)
        {
            currentCooldownTime = cooldownTime;
            isSkillReady = false;
            Cover.SetActive(true);
            Debug.Log("防護罩啟動！");
        }
    }
}
