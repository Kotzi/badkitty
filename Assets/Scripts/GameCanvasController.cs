using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameCanvasController : MonoBehaviour
{
        [SerializeField] Text countdownText;
        [SerializeField] Text dayText;
        [SerializeField] Text FaceMaskText;
        [SerializeField] Image FaceMaskImage;
        [SerializeField] Sprite FaceMaskSpriteOn;
        [SerializeField] Sprite FaceMaskSpriteOff;
        [SerializeField] Text KeysText;
        [SerializeField] Image KeysImage;
        [SerializeField] Sprite KeysSpriteOn;
        [SerializeField] Sprite KeysSpriteOff;
        [SerializeField] Text CarKeysText;
        [SerializeField] Image CarKeysImage;
        [SerializeField] Sprite CarKeysSpriteOn;
        [SerializeField] Sprite CarKeysSpriteOff;
        [SerializeField] Text WalletText;
        [SerializeField] Image WalletImage;
        [SerializeField] Sprite WalletSpriteOn;
        [SerializeField] Sprite WalletSpriteOff;
       [SerializeField] Text InstructionText;       
       void Start(){
           FaceMaskText.text = LanguageController.Shared.getFaceMaskText();
           KeysText.text = LanguageController.Shared.getKeysText();
           CarKeysText.text= LanguageController.Shared.getCarKeysText();
           WalletText.text = LanguageController.Shared.getWalletText();
           InstructionText.text = LanguageController.Shared.getInitialInstruction();
          
       }

       public void setCountdownText(string s, string day){
            countdownText.text= s;
            dayText.text = LanguageController.Shared.getDayText(day);
       }

    private bool isScaling = false;
    public void playerIsCloseTo(ItemType item, float distance)
    {
        if (!isScaling)
        {
            Text textToScale = FaceMaskText;
            Image imageToScale = FaceMaskImage;
            switch(item){
                case ItemType.FACE_MASK:
                    textToScale = FaceMaskText;
                    imageToScale = FaceMaskImage;
                    break;
                case ItemType.CAR_KEY:
                    textToScale = CarKeysText;
                    imageToScale = CarKeysImage;
                    break;
                case ItemType.HOME_KEYS:
                    textToScale = KeysText;
                    imageToScale = KeysImage;
                    break;
                case ItemType.WALLET:
                    textToScale = WalletText;
                    imageToScale = WalletImage;
                    break;
            }

            isScaling = true;
            var textOriginalScale = textToScale.transform.localScale;
            var imageOriginalScale = textToScale.transform.localScale;
            var p = Mathf.Exp(((1/Mathf.Max(distance - 1.15f, 1.1f)) * 0.5f));
            var maxTextScale = textOriginalScale * p;
            var maxImageScale = imageOriginalScale * p;
            DOTween.Sequence()
                .Join(textToScale.transform.DOScale(maxTextScale, 0.25f))
                .Join(imageToScale.transform.DOScale(maxImageScale, 0.25f))
                .OnComplete(() => {
                    DOTween.Sequence()
                            .Join(textToScale.transform.DOScale(textOriginalScale, 0.25f))
                            .Join(imageToScale.transform.DOScale(imageOriginalScale, 0.25f))
                            .OnComplete(() => {
                                isScaling = false;
                            });
                });
        }
    }

       public void setListItems(bool[] items){
            var colorOn = Color.green;
            var colorOff = Color.gray;
            SetItem(FaceMaskText, 
                    items[(int)ItemType.FACE_MASK] ? colorOn : colorOff, 
                    FaceMaskImage, 
                    items[(int)ItemType.FACE_MASK] ? FaceMaskSpriteOn : FaceMaskSpriteOff);
            SetItem(KeysText, 
                    items[(int)ItemType.HOME_KEYS] ? colorOn : colorOff, 
                    KeysImage, 
                    items[(int)ItemType.HOME_KEYS] ? KeysSpriteOn : KeysSpriteOff);
            SetItem(CarKeysText, 
                    items[(int)ItemType.CAR_KEY] ? colorOn : colorOff, 
                    CarKeysImage, 
                    items[(int)ItemType.CAR_KEY] ? CarKeysSpriteOn : CarKeysSpriteOff);
            SetItem(WalletText, 
                    items[(int)ItemType.WALLET] ? colorOn : colorOff, 
                    WalletImage, 
                    items[(int)ItemType.WALLET] ? WalletSpriteOn : WalletSpriteOff);
       }

    private void SetItem(Text text, Color color, Image image, Sprite sprite)
    {
        var oldColor = text.color;
        text.color = color;
        image.sprite = sprite;
        if (oldColor != color)
        {
            var originalScale = Vector3.one;
            var scaled = Vector3.one * 1.2f;
            var scaledTime = 0.25f;
            var originalTime = 0.15f;
            DOTween.Sequence()
                .Join(text.transform.DOScale(scaled, scaledTime))
                .Join(image.transform.DOScale(scaled, scaledTime))
                .OnComplete(() => {
                    DOTween.Sequence()
                        .Join(text.transform.DOScale(originalScale, originalTime))
                        .Join(image.transform.DOScale(originalScale, originalTime))
                        .OnComplete(() => {
                            DOTween.Sequence()
                                .Join(text.transform.DOScale(scaled, scaledTime))
                                .Join(image.transform.DOScale(scaled, scaledTime))
                                .OnComplete(() => {
                                    DOTween.Sequence()
                                        .Join(text.transform.DOScale(originalScale, originalTime))
                                        .Join(image.transform.DOScale(originalScale, originalTime));
                                });
                        });
                });
        }
    }

    public void setInstruction(string s){
       if(s ==" INITIAL"){
            InstructionText.text = LanguageController.Shared.getInitialInstruction();
       }
        else if(s == "MIDDLE"){
             InstructionText.text = LanguageController.Shared.getMiddleInstruction();

        }
        else if(s == "LAST"){
            InstructionText.text = LanguageController.Shared.getLastInstruction();
        }
    }
}
