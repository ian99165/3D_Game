using TMPro;
using UnityEngine;

public class CD : MonoBehaviour
{
    public float cooldownTime;
    
    private float currentCooldownTime = 0f;
    
    public TextMeshProUGUI cooldownText;

    public bool isSkillReady;

    private string skillType;

    void Start()
    {
        skillType = gameObject.name;

        if (skillType == "CD_I")
        {
            cooldownTime = 20f;  // 第一个技能的冷卻時間
        }
        else if (skillType == "CD_II")
        {
            cooldownTime = 0f;   // 第二個技能的冷卻時間 (防護罩冷卻時間)
        }

        currentCooldownTime = cooldownTime;
        isSkillReady = false;
    }

    void Update()
    {
        // 如果技能不是準備好的狀態
        if (!isSkillReady)
        {
            currentCooldownTime -= Time.deltaTime;

            // 如果倒數結束，則技能準備好
            if (currentCooldownTime <= 0)
            {
                currentCooldownTime = 0;
                isSkillReady = true;
            }
        }

        // 更新UI顯示的倒數計時
        UpdateCooldownUI();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateShield();
        }
    }

    private void UpdateCooldownUI()
    {
        if (cooldownText != null)
        {
            if (currentCooldownTime == 0)
            {
                if (skillType == "CD_I")
                {
                    cooldownText.text = "OK";
                }
                if (skillType == "CD_II")
                {
                    cooldownText.text = Mathf.Ceil(currentCooldownTime).ToString();
                }
            }
            else
            {
                cooldownText.text = Mathf.Ceil(currentCooldownTime).ToString();
            }
        }
    }

    public void ActivateShield()
    {
        if (skillType == "CD_II" && !isSkillReady)
        {
            currentCooldownTime = cooldownTime;
            isSkillReady = false;
            Debug.Log("防護罩啟動！");
        }
    }
}