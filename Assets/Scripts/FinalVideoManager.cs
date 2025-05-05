using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class FinalVideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string returnScene = "giris"; // giriþ sahnesinin adý

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(returnScene);
    }
}
