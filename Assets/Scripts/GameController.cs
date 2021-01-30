using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameController : MonoBehaviour
{
    const float startingTime = 60f;
    public YouWonController YouWon;
    public GameObject GameOver;
    public PlayerController Player;
    public ItemPlacer ItemPlacer;
    
    public GameCanvasController gameCanvasController;
    public PauseMenuController PauseMenuController;

    bool isTimerActive = false;
    float currentTime = 0f;
    int currentDay = 1;
    bool isPaused = false;
    public LightController MainLight;
    public CatController Cat;
    public Image MainOverlay;

    void Start()
    {
        YouWon.NextDayButtonAction = () => {
            ItemPlacer.AddItems();
            currentDay += 1;
            StartNight();
        };
        currentTime = startingTime;
        StartNight();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !GameOver.activeSelf && !YouWon.gameObject.activeSelf)
        {
            if(isPaused)
            {
                UnpauseGame();
            }
            else 
            {
                PauseGame();
            }
            return;
        }

        if (!isPaused) 
        {
            if (isTimerActive)
            {
                currentTime -= 1 * Time.deltaTime;
                gameCanvasController.setCountdownText(currentTime.ToString("0"));
                if(currentTime <= 0){
                    currentTime = 0;
                    GameOver.SetActive(true);
                    Player.CanMove =false;
                    gameCanvasController.hideTimerAndItems();
                }
            }
        }
    }

    void StartNight()
    {
        YouWon.gameObject.SetActive(false);
        Player.RestartPlayer();
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
                                            Player.canMove = true;
                                        });
                                    });
                    });
        });
    }

    void ToggleTimerActivate() {
        isTimerActive = !isTimerActive;
        gameCanvasController.gameObject.SetActive(isTimerActive);
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        PauseMenuController.gameObject.SetActive(true);
    }

    void UnpauseGame()
    {
        Time.timeScale = 1f;
        PauseMenuController.gameObject.SetActive(false);
    }

    public void setListItems(bool[] items)
    {
        gameCanvasController.setListItems(items);
    }

    public void DoorOpened()
    {
        ToggleTimerActivate();
        YouWon.UpdateDay(currentDay.ToString("0"));
        YouWon.gameObject.SetActive(true);
    }
}
