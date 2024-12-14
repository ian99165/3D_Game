using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; //游標不顯示
        Cursor.lockState = CursorLockMode.Locked; //游標定在螢幕中央
    }
}
