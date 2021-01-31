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

    public string getInitialInstruction(){
        switch(CurrentLanguage){

         case Language.EN: return "Find the items that Bigotitos has hidden from you and take them by pressing the (E) key";
         case Language.ES: return "Encuentra los articulos que te ha escondido Bigotitos y cogelos presionando la tecla (E)";
         case Language.CAT: return "Troba els articles que t'ha amagat Bigotitos i agafa'ls pressionant la tecla (E)";
        }
        return "";
    }
    

    public string getMiddleInstruction(){
         switch(CurrentLanguage){

         case Language.EN: return "Take a look at the rest of the rooms";
         case Language.ES: return "Mira bien en el resto de las habitaciones";
         case Language.CAT: return "Mira bé a la resta de les habitacions";
        }
        return "";
    }
    

    public string getLastInstruction(){
        switch(CurrentLanguage){

         case Language.EN: return "Time is running out! Go quickly to the front door! ";
         case Language.ES: return "Se acaba el tiempo! Ve rápido hacia la puerta principal! ";
         case Language.CAT: return "S'acaba el temps! Veu ràpid cap a la porta principal! ";
        }
        return "";
    }
    
    public string getIntroText(){
        switch(CurrentLanguage){

         case Language.EN: return "Bigotitos is a very naughty kitten, he likes to hide items so that his owner cannot leave the house... Help her to find the items!";
         case Language.ES: return "Bigotitos es un gatito muy travieso y le gusta esconder articulos para que su dueña no pueda salir de casa... Ayudala a encontrar los articulos";
         case Language.CAT: return "Bigotitos és un gat molt entremaliat, li agrada amagar articles  perque  la seva propietaria no pugui sortir de casa";
        }
        return "";
    }



}