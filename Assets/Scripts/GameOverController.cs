using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public AudioSource GameOverAudioSource;
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
            OnClickRetry();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}