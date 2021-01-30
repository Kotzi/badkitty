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
           //Mask
           if(items[(int)ItemType.FACE_MASK]){
                FaceMaskText.fontSize = 30;
           }
           else if(!items[(int)ItemType.FACE_MASK]){
               //Setearlo valores iniciales
           }
            //
           if(items[(int)ItemType.HOME_KEYS]){
               KeysText.fontSize = 30;
           }
           else if(!items[(int)ItemType.HOME_KEYS]){

           }

           if(items[(int)ItemType.CAR_KEY]){
               CarKeysText.fontSize = 30;
            
           }
           else if(!items[(int)ItemType.CAR_KEY]){
               

           }

           if(items[(int)ItemType.WALLET]){
               WalletText.fontSize= 30;

           }
           else if(!items[(int)ItemType.WALLET]){

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
