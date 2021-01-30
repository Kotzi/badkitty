using UnityEngine;
using UnityEngine.UI;

public class YouWonController : MonoBehaviour
{
    public Text YouWonLabel;
    public Text NextDayLabel;
    public System.Action NextDayButtonAction;

    void Awake()
    {
        YouWonLabel.text = LanguageController.Shared.getYouWonText();
        NextDayLabel.text = LanguageController.Shared.getNextDayText();
    }

    public void OnNextDayClick()
    {
        if (NextDayButtonAction != null)
        {
            NextDayButtonAction();
        }
    }
}