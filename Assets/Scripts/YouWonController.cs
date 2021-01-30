using UnityEngine;
using UnityEngine.UI;

public class YouWonController : MonoBehaviour
{
    public Text YouWonLabel;
    public Text NextDayLabel;
    public Text DayLabel;
    public System.Action NextDayButtonAction;

    void Awake()
    {
        YouWonLabel.text = LanguageController.Shared.getYouWonText();
        NextDayLabel.text = LanguageController.Shared.getNextDayText();
    }

    public void UpdateDay(string day)
    {
        DayLabel.text = LanguageController.Shared.getDayText(day);
    }

    public void OnNextDayClick()
    {
        if (NextDayButtonAction != null)
        {
            NextDayButtonAction();
        }
    }
}