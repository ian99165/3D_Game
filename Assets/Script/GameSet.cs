using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSet : MonoBehaviour
{
    public AudioClip soundEffect;  // 你想要播放的音效
    private AudioSource audioSource;  // 用来播放音效的 AudioSource 组件

    public float minTime = 1f;  // 最短间隔时间
    public float maxTime = 5f;  // 最长间隔时间

    void Start()
    {
        // 获取 AudioSource 组件，如果没有则添加一个
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 启动协程来控制音效播放
        StartCoroutine(PlayRandomSound());
    }

    // 协程，每隔随机时间播放一次音效
    private IEnumerator PlayRandomSound()
    {
        while (true)
        {
            // 生成一个在 minTime 和 maxTime 之间的随机时间
            float randomTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(randomTime);  // 等待随机时间

            // 播放音效
            if (soundEffect != null)
            {
                audioSource.PlayOneShot(soundEffect);
            }
        }
    }
}