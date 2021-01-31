using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Sprite ImageOn;
    public Sprite ImageOff;
    public AudioController AudioController;
    public AudioSource PopSound;

    private Image Image;

    void Awake()
    {
        Image = GetComponent<Image>();
    }

    public void OnClick() 
    {
        AudioController.ToggleMute();
        PopSound.Play();
        Image.sprite = AudioController.IsMuted ? ImageOff : ImageOn;
    }
}
