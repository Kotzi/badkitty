using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;




public class GameController : MonoBehaviour
{
    const float startingTime = 10f;
    public GameObject GameOver;
    bool isTimerActive = true;
    float currentTime = 0f;

    [SerializeField] Text countdownText;
    public LightController MainLight;
    public CatController Cat;
    public Image MainOverlay;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        StartNight();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerActive)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text= currentTime.ToString("0");
            if(currentTime <= 0){
                currentTime = 0;
                GameOver.SetActive(true);
            }
        }
    }

    void StartNight()
    {
        ToggleTimerActivate();
        var originalLightIntensity = MainLight.intensity;
        MainLight.SetIntensity(0.5f, 1f, () => {
            Cat.WakeUp();
            MainOverlay.DOColor(Color.black, 0.75f)
                    .OnComplete(() => {
                        var color = Color.black;
                        color.a = 0f;
                        MainOverlay.DOColor(color, 0.75f)
                                    .OnComplete(() => {
                                        MainLight.SetIntensity(originalLightIntensity, 1f, () => {
                                            currentTime = startingTime;
                                            ToggleTimerActivate();
                                        });
                                    });
                    });
        });
    }

    void ToggleTimerActivate() {
        isTimerActive = !isTimerActive;
        countdownText.gameObject.SetActive(isTimerActive);
    }
}
