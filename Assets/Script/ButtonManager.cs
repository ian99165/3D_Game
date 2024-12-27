using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private bool played = false;
    public Button SkipButton;
    
    [Header("主頁")]
    public Button StartButton;
    public Button ExitButton;
    
    [Header("操作說明")]
    public GameObject ManualObject;
    public Button ManualButton;
    public Button ManualButtonX;

    [Header("選單")] 
    public bool isMenu = false;
    public GameObject MenuObject;
    public Button Back;
    public Button Home;
    public Button Restart;
    public Button ESC;
    
    [Header("回到主頁")]
    public Button HomeButton;
    private void Start()
    {
        if (MenuObject != null)
        {
            MenuObject.SetActive(false);
        }

        if (ManualObject != null)
        {
            ManualObject.SetActive(false);
        }

        
        Button[] buttons = { SkipButton , StartButton, ExitButton , ManualButton , ManualButtonX , ESC , Back , Home , Restart , HomeButton};

        foreach (var button in buttons)
        {
            button?.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    private void OnButtonClick(Button button)
    {
        if (button == StartButton)
        {
            SceneManager.LoadScene("S1");
        }
        else if (button == ExitButton)
        {
        #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
        #else
                    Application.Quit(); // 退出遊戲
        #endif
        }
        else if (button == SkipButton)
        {
            SceneManager.LoadScene("S2");
        }
        else if (button == ManualButton)
        {
            ManualObject.SetActive(true);
        }
        else if (button == ManualButtonX)
        {
            ManualObject.SetActive(false);
        }
        else if (button == ESC)
        {
            if (!isMenu)
            {
                MenuObject.SetActive(true);
                isMenu = true;
                return;
            }
            if (isMenu)
            {
                MenuObject.SetActive(false);
                isMenu = false;
            }
        }
        else if (button == Back)
        {
            MenuObject.SetActive(false);
            isMenu = false;
        }
        else if (button == Restart)
        {
            SceneManager.LoadScene("S2");
        }
        else if (button == Home)
        {
            SceneManager.LoadScene("S0");
        }
        else if (button == HomeButton)
        {
            SceneManager.LoadScene("S0");
        }
    }
}