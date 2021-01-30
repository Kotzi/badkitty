﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameController : MonoBehaviour
{
    const float startingTime = 60f;

    public GameObject YouWon;
    public GameObject GameOver;
    public GameObject Player;
    
    public GameCanvasController gameCanvasController;
    public PauseMenuController PauseMenuController;

    bool isTimerActive = true;
    float currentTime = 0f;
    bool isPaused = false;
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
        if(Input.GetKeyDown(KeyCode.Escape) && !GameOver.activeSelf && !YouWon.activeSelf)
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
                    PlayerController.CanMove =false;
                }
            }
        }
    }

    void StartNight()
    {
        PlayerController.CanMove = false;
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
                                            PlayerController.CanMove = true;
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
}
