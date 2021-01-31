using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Text StartButtonText;
    public Text IntroText;
    public SoundButton SoundButton;
    public AudioSource PopAudioSource;
    private LanguageController LanguageController;
    private SceneManagerController SceneManagerController;

    void Awake()
    {
        SoundButton.AudioController = GetComponent<AudioController>();
        SceneManagerController = Object.FindObjectOfType<SceneManagerController>();
        SceneManagerController.CurrentSceneIndex = 1;
        LanguageController = LanguageController.Shared;
        IntroText.text= LanguageController.Shared.getIntroText();
        ReloadTexts();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) 
        {
            SceneManagerController.GoToNexScene();
        }
    }

    public void OnClickStart() 
    {
        PopAudioSource.Play();
        SceneManagerController.GoToNexScene();
    }

    public void OnClickCAT()
    {
        PopAudioSource.Play();
        LanguageController.CurrentLanguage = LanguageController.Language.CAT;
        ReloadTexts();
    }

    public void OnClickES()
    {
        PopAudioSource.Play();
        LanguageController.CurrentLanguage = LanguageController.Language.ES;
        ReloadTexts();
    }

    public void OnClickEN()
    {
        PopAudioSource.Play();
        LanguageController.CurrentLanguage = LanguageController.Language.EN;
        ReloadTexts();
    }

    private void ReloadTexts()
    {
        StartButtonText.text = LanguageController.getStartButtonText();
    }
}