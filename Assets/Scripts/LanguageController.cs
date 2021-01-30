using UnityEngine;

class LanguageController : MonoBehaviour {
    public enum Language
    {
        EN = 0,
        ES,
        CAT
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public Language CurrentLanguage = Language.EN;

    public string getStartButtonText() {
        switch (CurrentLanguage) 
        {
            case Language.EN: return "Start";
            case Language.ES: return "Comenzar";
            case Language.CAT: return "Start";
        }

        return "";
    }

    public string getMuteButtonText(bool muted) {
        switch (CurrentLanguage) 
        {
            case Language.EN: return muted ? "Unmute audio" : "Mute audio";
            case Language.ES: return muted ? "Activar sonido" : "Desactivar sonido";
            case Language.CAT: return muted ? "Unmute audio" : "Mute audio";
        }

        return "";
    }

    public string getGameOverText() {
        switch (CurrentLanguage) 
        {
            case Language.EN: return "Game over";
            case Language.ES: return "Juego terminado";
            case Language.CAT: return "Game over";
        }

        return "";
    }

    public string getYouWonText() {
        switch (CurrentLanguage) 
        {
            case Language.EN: return "You won!";
            case Language.ES: return "Has ganado!";
            case Language.CAT: return "You won!";
        }

        return "";
    }
}