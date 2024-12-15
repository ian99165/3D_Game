using UnityEngine;

public class Shit : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bird")) return;

        Destroy(gameObject);
    }
}