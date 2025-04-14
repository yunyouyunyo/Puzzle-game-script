using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class OpeningMovie : MonoBehaviour
{
    public VideoLevelManager videoLevelManager; // 确保这个变量被正确赋值
    public VideoPlayer videoPlayer;
    public string sceneName;

    void Start()
    {
        Debug.Log("play");

        // 自动查找 VideoLevelManager（如果未在 Inspector 手动赋值）
        if (videoLevelManager == null)
        {
            videoLevelManager = FindObjectOfType<VideoLevelManager>();
        }

        // 确保 videoLevelManager 不是 null
        if (videoLevelManager == null)
        {
            Debug.LogError("VideoLevelManager 未找到！");
            return;
        }

        videoPlayer.Play();
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Stop();
                OnVideoEnd(videoPlayer);
            }
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // 调用 VideoLevelManager 退出方法
        if (videoLevelManager != null)
        {
            videoLevelManager.ExitVideoScene();
        }
        else
        {
            Debug.LogWarning("videoLevelManager 为空，无法调用 ExitVideoScene()");
        }

        SceneManager.LoadScene(sceneName);
    }
}
