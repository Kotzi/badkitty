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

       public void setCountdownText(string s){
              countdownText.text= s;
       }
       public void setListItems(bool[] items){
       
       }
}
