using UnityEngine;
using DG.Tweening;
public class CatController : MonoBehaviour
{
    private Animator Animator;
    private AudioSource WalkingSound;

    void Awake()
    {
        Animator = GetComponent<Animator>();
        WalkingSound = GetComponentInChildren<AudioSource>();
    }

    public void WakeUp(float movementDuration)
    {
        gameObject.SetActive(true);
        print("the cat woke up!");
        Animator.SetTrigger("right");
        WalkingSound.Play();
        var destination = transform.position;
        destination.x = 0;
        transform.DOMove(destination, movementDuration)
            .OnComplete(() => {
                WalkingSound.Stop();
                gameObject.SetActive(false);
            });
    }
}