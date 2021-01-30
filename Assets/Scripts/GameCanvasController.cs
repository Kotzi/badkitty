using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

            countdownText.enabled=true;
           FaceMaskText.enabled=true;
           KeysText.enabled=true;
           CarKeysText.enabled=true;
           WalletText.enabled=true;
       }

       public void setCountdownText(string s){
              countdownText.text= s;
       }
       public void setListItems(bool[] items){
            if(items[(int)ItemType.FACE_MASK])
           {
                FaceMaskText.color = Color.green;
           }
           else 
           {
                FaceMaskText.color = Color.red;
           }

           if(items[(int)ItemType.HOME_KEYS])
           {
                KeysText.color = Color.green;
           }
           else 
           {
                KeysText.color = Color.red;
           }

           if(items[(int)ItemType.CAR_KEY])
           {
                CarKeysText.color = Color.green;
           }
           else 
           {
               CarKeysText.color = Color.red;
           }

           if(items[(int)ItemType.WALLET])
           {
               WalletText.color = Color.green;
           }
           else 
           {
               WalletText.color = Color.red;
           }
       }

       public void hideTimerAndItems(){
           countdownText.enabled=false;
           FaceMaskText.enabled=false;
           KeysText.enabled=false;
           CarKeysText.enabled=false;
           WalletText.enabled=false;



       }
}
