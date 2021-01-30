using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Text MuteButtonText;
    public Text StartButtonText;

    private LanguageController LanguageController;
    private SceneManagerController SceneManagerController;
    private AudioController AudioController;

    void Awake()
    {
        AudioController = GetComponent<AudioController>();
        SceneManagerController = Object.FindObjectOfType<SceneManagerController>();
        LanguageController = LanguageController.Shared;
        ReloadTexts();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) 
        {
            OnClickStart();
        }

        MuteButtonText.text = LanguageController.getMuteButtonText(AudioController.IsMuted);
    }

    public void OnClickStart() 
    {
        SceneManagerController.GoToNexScene();
    }

    public void OnClickSound() 
    {
        AudioController.ToggleMute();
    }

    public void OnClickCAT()
    {
        LanguageController.CurrentLanguage = LanguageController.Language.CAT;
        ReloadTexts();
    }

    public void OnClickES()
    {
        LanguageController.CurrentLanguage = LanguageController.Language.ES;
        ReloadTexts();
    }

    public void OnClickEN()
    {
        LanguageController.CurrentLanguage = LanguageController.Language.EN;
        ReloadTexts();
    }

    private void ReloadTexts()
    {
        MuteButtonText.text = LanguageController.getMuteButtonText(AudioController.IsMuted);
        StartButtonText.text = LanguageController.getStartButtonText();
    }
}