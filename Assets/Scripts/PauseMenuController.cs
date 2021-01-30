using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public Text MuteButtonText;
    public Text PauseText;
    private AudioController AudioController;
    private LanguageController LanguageController;

    void Awake()
    {
        AudioController = GetComponent<AudioController>();
        LanguageController = LanguageController.Shared;
        PauseText.text = LanguageController.getPauseText();
    }

    void Update()
    {
        MuteButtonText.text = LanguageController.getMuteButtonText(AudioController.IsMuted);
    }

    public void OnClickAudio() 
    {
        AudioController.ToggleMute();
    }
}