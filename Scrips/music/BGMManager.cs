
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;
    public AudioSource bgmAudioSource; // 背景音乐 AudioSource

    private void Awake()
    {
        // 确保这个对象不会重复创建
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 让 BGM 持续存在
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MuteBGM()
    {
        if (bgmAudioSource != null)
        {
            bgmAudioSource.mute = true;
        }
    }

    public void UnmuteBGM()
    {
        if (bgmAudioSource != null)
        {
            bgmAudioSource.mute = false;
        }
    }
}
