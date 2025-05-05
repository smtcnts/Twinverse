using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class FinalVideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string returnScene = "giris"; // giri� sahnesinin ad�

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(returnScene);
    }
}
