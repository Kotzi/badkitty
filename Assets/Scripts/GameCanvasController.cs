using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameCanvasController : MonoBehaviour
{
       [SerializeField] Text countdownText;
       [SerializeField] Text FaceMaskText;
       [SerializeField] Text KeysText;
       [SerializeField] Text CarKeysText;
       [SerializeField] Text WalletText;
       
       void Start(){
           FaceMaskText.text = LanguageController.Shared.getFaceMaskText();
           KeysText.text = LanguageController.Shared.getKeysText();
           CarKeysText.text= LanguageController.Shared.getCarKeysText();
           WalletText.text = LanguageController.Shared.getWalletText();
       }

       public void setCountdownText(string s){
              countdownText.text= s;
       }

    private bool isScaling = false;
    public void playerIsCloseTo(ItemType item, float distance)
    {
        if (!isScaling)
        {
            Text textToScale = FaceMaskText;
            switch(item){
                case ItemType.FACE_MASK:
                    textToScale = FaceMaskText;
                    break;
                case ItemType.CAR_KEY:
                    textToScale = CarKeysText;
                    break;
                case ItemType.HOME_KEYS:
                    textToScale = KeysText;
                    break;
                case ItemType.WALLET:
                    textToScale = WalletText;
                    break;
            }

            isScaling = true;
            var originalScale = textToScale.transform.localScale;
            var p = (1/Mathf.Max(distance - 1.15f, 1.1f)) * 0.5f;
            var maxScale = originalScale * Mathf.Exp(p);
            textToScale.transform.DOScale(maxScale, 0.25f).OnComplete(() => { 
                textToScale.transform.DOScale(originalScale, 0.25f).OnComplete(() => { 
                    isScaling = false;
                });
            });
        }
    }

       public void setListItems(bool[] items){
            SetTextColor(FaceMaskText, items[(int)ItemType.FACE_MASK] ? Color.green : Color.red);
            SetTextColor(KeysText, items[(int)ItemType.HOME_KEYS] ? Color.green : Color.red);
            SetTextColor(CarKeysText, items[(int)ItemType.CAR_KEY] ? Color.green : Color.red);
            SetTextColor(WalletText, items[(int)ItemType.WALLET] ? Color.green : Color.red);
       }

    private void SetTextColor(Text text, Color color)
    {
        var oldColor = text.color;
        text.color = color;
        if (oldColor != color)
        {
            var originalScale = Vector3.one;
            var scaled = Vector3.one * 1.2f;
            text.transform.DOScale(scaled, 0.25f).OnComplete(() => {
                text.transform.DOScale(originalScale, 0.15f).OnComplete(() => {
                    text.transform.DOScale(scaled, 0.25f).OnComplete(() => {
                        text.transform.DOScale(originalScale, 0.15f);
                    });
                });
            });
        }
    }
}
