using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Text StartButtonText;
    public SoundButton SoundButton;
    private LanguageController LanguageController;
    private SceneManagerController SceneManagerController;

    void Awake()
    {
        SoundButton.AudioController = GetComponent<AudioController>();
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
    }

    public void OnClickStart() 
    {
        SceneManagerController.GoToNexScene();
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
        StartButtonText.text = LanguageController.getStartButtonText();
    }
}