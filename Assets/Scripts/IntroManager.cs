using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName = "MainScene"; // Geçilecek sahnenin adı

    private GameObject logoObject;

    public void PlayIntroVideo()
    {
        // 🎯 Logo objesini bul ve gizle
        logoObject = GameObject.FindWithTag("Logo");
        if (logoObject != null)
        {
            logoObject.SetActive(false);
        }

        // 🎯 Tüm Player tagli objeleri bul ve gizle
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            player.SetActive(false);
        }

        gameObject.SetActive(true);
        videoPlayer.loopPointReached += OnVideoFinished;
        videoPlayer.Play();
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
