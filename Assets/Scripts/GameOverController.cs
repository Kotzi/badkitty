using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Text GameOverText;
    
    void Awake()
    {
        GameOverText.text = Object.FindObjectOfType<LanguageController>().getGameOverText();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) 
        {
            OnClickRetry();
        }
    }

    public void OnClickRetry() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}