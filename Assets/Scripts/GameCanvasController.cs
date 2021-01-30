using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasController : MonoBehaviour
{
     [SerializeField] Text countdownText;
     [SerializeField] Text lisItems;

     public void setCountdownText(string s){
            countdownText.text= s;
     }
     public void setListItems(string list){
            lisItems.text = list;
     }
     

}
