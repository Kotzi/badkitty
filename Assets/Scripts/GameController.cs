﻿using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameController : MonoBehaviour
{
    const float startingTime = 60f;
    public YouWonController YouWon;
    public GameOverController GameOver;
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
    public AudioSource MainAudioSource;

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
        if(Input.GetKeyDown(KeyCode.Escape) && !GameOver.gameObject.activeSelf && !YouWon.gameObject.activeSelf)
        {
            if(isPaused)
            {
                UnpauseGame();
                isPaused = false;
            }
            else 
            {
                PauseGame();
                isPaused = true;
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
                    isTimerActive = false;
                    currentTime = 0;
                    MainAudioSource.Stop();
                    gameCanvasController.gameObject.SetActive(false);
                    GameOver.gameObject.SetActive(true);
                    GameOver.PlaySong();
                    Player.canMove = false;
                }
                else if(currentTime <= 14  ){
                   
                    gameCanvasController.setInstruction("LAST");
                }
                else if(currentTime <= 30 && currentTime > 14){
                 
                    gameCanvasController.setInstruction("MIDDLE");
                }
                else if(currentTime <= 100 && currentTime > 30){
                   
                     gameCanvasController.setInstruction("INITIAL");
                }
            }
        }
    }

    void StartNight()
    {
        MainAudioSource.Stop();
        YouWon.gameObject.SetActive(false);
        Player.RestartPlayer();
        Cat.WakeUp();
        MainOverlay.DOColor(Color.black, 1f)
                .OnComplete(() => {
                    var color = Color.black;
                    color.a = 0f;
                    MainOverlay.DOColor(color, 1f)
                                .OnComplete(() => {
                                    MainAudioSource.Play();
                                    currentTime = startingTime;
                                    ToggleTimerActivate();
                                    Player.canMove = true;
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

    public void playerIsCloseTo(ItemType item)
    {
        gameCanvasController.playerIsCloseTo(item);
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
