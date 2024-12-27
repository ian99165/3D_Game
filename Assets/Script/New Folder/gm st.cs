using UnityEngine;
using UnityEngine.SceneManagement;

public class gmst : MonoBehaviour
{
    public void LoadS2Scene()
    {
        Debug.Log("Button clicked! Loading scene S1...");
        SceneManager.LoadScene("S1"); // 跳轉到 S1 場景
    }
}