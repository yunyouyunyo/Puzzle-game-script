using UnityEngine;
using UnityEngine.Video;

public class VideoLevelManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; // 视频播放器
    public AudioSource videoAudioSource; // 影片音频

    void Start()
    {
        // 进入影片 Scene 时，静音 BGM
        if (BGMManager.Instance != null)
        {
            BGMManager.Instance.MuteBGM();
        }

        // 连接视频音频
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, videoAudioSource);

        // 播放影片
        videoPlayer.Play();
        videoAudioSource.Play();
    }

    public void ExitVideoScene()
    {
        // 停止视频播放
        videoPlayer.Stop();
        videoAudioSource.Stop();

        // 退出影片 Scene 时恢复 BGM
        if (BGMManager.Instance != null)
        {
            BGMManager.Instance.UnmuteBGM();
        }
    }
}
