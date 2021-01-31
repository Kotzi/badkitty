using UnityEngine;

public class IntroController : MonoBehaviour
{
    private float MaxTimer = 1f;
    private SceneManagerController SceneManagerController;
    private float Timer = 0f;
    private bool TimerActive = true;

    void Awake()
    {
        SceneManagerController = Object.FindObjectOfType<SceneManagerController>();
        SceneManagerController.CurrentSceneIndex = 0;
    }

    void Update()
    {
        if(TimerActive)
        {
            Timer += Time.deltaTime;

            if (Timer >= MaxTimer) 
            {
                TimerActive = false;
                SceneManagerController.GoToNexScene();
            }
        }
    }
}