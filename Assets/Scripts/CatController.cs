using UnityEngine;
using DG.Tweening;
public class CatController : MonoBehaviour
{
    private Animator Animator;
    public AudioSource WalkingSound;
    public AudioSource MisterioSound;

    void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    public void WakeUp(float movementDuration)
    {
        gameObject.SetActive(true);
        MisterioSound.Play();
        print("the cat woke up!");
        Animator.SetTrigger("right");
        WalkingSound.Play();
        var destination = transform.position;
        destination.x = 0;
        transform.DOMove(destination, movementDuration)
            .OnComplete(() => {
                MisterioSound.Stop();
                WalkingSound.Stop();
                gameObject.SetActive(false);
            });
    }
}