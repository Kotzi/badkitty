using UnityEngine;

class LanguageController : MonoBehaviour {
    public enum Language
    {
        EN = 0,
        ES,
        CAT
    }

    private static LanguageController _instance;
    public static LanguageController Shared {
        get {
            if (_instance != null) {
                return _instance;
            } else {
                _instance = Object.FindObjectOfType<LanguageController>();
                if (_instance != null) {
                    return _instance;
                } else {
                    _instance = (new GameObject()).AddComponent<LanguageController>();
                    return _instance;
                }
            }
        }
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
            case Language.CAT: return "Comença";
        }

        return "";
    }

    public string getMuteButtonText(bool muted) {
        switch (CurrentLanguage) 
        {
            case Language.EN: return muted ? "Unmute audio" : "Mute audio";
            case Language.ES: return muted ? "Activar sonido" : "Desactivar sonido";
            case Language.CAT: return muted ? "Activa so" : "Silencia";
        }

        return "";
    }

    public string getPauseText() {
        switch (CurrentLanguage) 
        {
            case Language.EN: return "Pause";
            case Language.ES: return "Pausa";
            case Language.CAT: return "CAT";
        }

        return "";
    }

    public string getGameOverText() {
        switch (CurrentLanguage) 
        {
            case Language.EN: return "Game over";
            case Language.ES: return "Juego terminado";
            case Language.CAT: return "Fi del joc";
        }

        return "";
    }

    public string getYouWonText() {
        switch (CurrentLanguage) 
        {
            case Language.EN: return "You won!";
            case Language.ES: return "Has ganado!";
            case Language.CAT: return "Has guanyat!";
        }

        return "";
    }

    public string getFaceMaskText() {
        switch (CurrentLanguage) 
        {
            case Language.EN: return "Face mask";
            case Language.ES: return "Mascarilla";
            case Language.CAT: return "Mascareta";
        }

        return "";
    }

    public string getKeysText() {
        switch (CurrentLanguage) 
        {
            case Language.EN: return "Keys";
            case Language.ES: return "Llaves";
            case Language.CAT: return "CAT";
        }

        return "";
    }

    public string getCarKeysText() {
        switch (CurrentLanguage) 
        {
            case Language.EN: return "Car keys";
            case Language.ES: return "Llaves del coche";
            case Language.CAT: return "CAT";
        }

        return "";
    }

    public string getWalletText() {
        switch (CurrentLanguage) 
        {
            case Language.EN: return "Wallet";
            case Language.ES: return "Cartera";
            case Language.CAT: return "CAT";
        }

        return "";
    }

    public string getRetryText() {
        switch (CurrentLanguage) 
        {
            case Language.EN: return "Retry";
            case Language.ES: return "Reintentar";
            case Language.CAT: return "CAT";
        }

        return "";
    }

    public string getNextDayText() {
        switch (CurrentLanguage) 
        {
            case Language.EN: return "Go to next day";
            case Language.ES: return "Ir al próximo día";
            case Language.CAT: return "CAT";
        }

        return "";
    }

    public string getDayText(string day) {
        switch (CurrentLanguage) 
        {
            case Language.EN: return "Day " + day;
            case Language.ES: return "Día " + day;
            case Language.CAT: return "CAT";
        }

        return "";
    }
}