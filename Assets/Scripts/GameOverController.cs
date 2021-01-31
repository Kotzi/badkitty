using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public AudioSource GameOverAudioSource;
    public AudioSource PopAudioSource;
    public Text GameOverText;
    public Text RetryButtonText;
    
    void Awake()
    {
        GameOverText.text = LanguageController.Shared.getGameOverText();
        RetryButtonText.text = LanguageController.Shared.getRetryText();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void PlaySong()
    {
        GameOverAudioSource.Play();
    }

    public void StopSong()
    {
        GameOverAudioSource.Play();
    }

    public void OnClickRetry() 
    {
        PopAudioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}