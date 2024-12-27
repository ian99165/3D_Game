using UnityEngine;

public class gmout : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("成功跳出遊戲！");
        Application.Quit();
    }
}