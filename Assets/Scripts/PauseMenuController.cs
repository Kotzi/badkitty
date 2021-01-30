using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public SoundButton SoundButton;
    public Text PauseText;
    private AudioController AudioController;
    private LanguageController LanguageController;

    void Awake()
    {
        SoundButton.AudioController = GetComponent<AudioController>();
        LanguageController = LanguageController.Shared;
        PauseText.text = LanguageController.getPauseText();
    }
}