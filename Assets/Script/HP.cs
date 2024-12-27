using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;

    public float _hp = 3f;

    public AudioClip damageSound;
    private AudioSource audioSource; 

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "shit(Clone)")
        {
            PlayDamageSound();

            HpKill();
        }
    }

    private void PlayDamageSound()
    {
        if (damageSound != null)
        {
            audioSource.PlayOneShot(damageSound);
        }
    }

    public void HpKill()
    {
        _hp--;

        if (_hp == 2)
        {
            Destroy(HP1);
        }
        else if (_hp == 1)
        {
            Destroy(HP2);
        }
        else if (_hp == 0)
        {
            Destroy(HP3);
            GameOver();
        }

        if (_hp < 0)
        {
            _hp = 0;
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");  // 请确认场景名称为 "GameOver"
    }
}