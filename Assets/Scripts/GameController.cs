using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameController : MonoBehaviour
{
    const float startingTime = 60f;
    public AudioSource DoorAudioSource;
    public SpriteRenderer PlayerInBed;
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

    private Vector3 originalCatPosition = Vector3.zero;
    private Vector3 originalPlayerPosition = Vector3.zero;

    void Start()
    {
        originalCatPosition = Cat.transform.position;
        originalPlayerPosition = Player.transform.position;

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
            }
        }
    }

    void StartNight()
    {
        Player.PlayerSpriteRenderer.enabled = false;
        PlayerInBed.enabled = true;
        Player.transform.position = originalPlayerPosition;
        Cat.transform.position = originalCatPosition;

        var startingColor = Color.black;
        startingColor.a = 0.3f;
        MainOverlay.color = startingColor;
        MainAudioSource.Stop();
        YouWon.gameObject.SetActive(false);
        Player.RestartPlayer();
        var fadeOutDuration = 5f;
        Cat.WakeUp(fadeOutDuration);
        MainOverlay.DOColor(Color.black, fadeOutDuration)
            .OnComplete(() => {
                var color = Color.black;
                color.a = 0f;
                PlayerInBed.enabled = false;
                Player.PlayerSpriteRenderer.enabled = true;
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

    public void playerIsCloseTo(ItemType item, float distance)
    {
        gameCanvasController.playerIsCloseTo(item, distance);
    }

    public void setListItems(bool[] items)
    {
        gameCanvasController.setListItems(items);
    }

    public void DoorOpened()
    {
        DoorAudioSource.Play();
        ToggleTimerActivate();
        YouWon.UpdateDay(currentDay.ToString("0"));
        YouWon.gameObject.SetActive(true);
    }
}
