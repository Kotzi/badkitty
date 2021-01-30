using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasController : MonoBehaviour
{
     [SerializeField] Text countdownText;
     
     public void setCountdownText(string s){
            countdownText.text= s;
     }

}
