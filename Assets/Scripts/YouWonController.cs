using UnityEngine;
using UnityEngine.UI;

public class YouWonController : MonoBehaviour
{
    public Text YouWonLabel;
    public Text NextDayLabel;
    public Text DayLabel;
    public System.Action NextDayButtonAction;
    public AudioSource MusicAudioSource;
    public AudioSource PopAudioSource;

    void Awake()
    {
        YouWonLabel.text = LanguageController.Shared.getYouWonText();
        NextDayLabel.text = LanguageController.Shared.getNextDayText();
    }

    public void Show(string day)
    {
        MusicAudioSource.Play();
        DayLabel.text = LanguageController.Shared.getDayText(day);
    }

    public void OnNextDayClick()
    {
        PopAudioSource.Play();
        if (NextDayButtonAction != null)
        {
            NextDayButtonAction();
        }
    }
}