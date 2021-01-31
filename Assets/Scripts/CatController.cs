using UnityEngine;
using DG.Tweening;
public class CatController : MonoBehaviour
{
    private Animator Animator;

    void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    public void WakeUp(float movementDuration)
    {
        gameObject.SetActive(true);
        print("the cat woke up!");
        Animator.SetTrigger("right");
        var destination = transform.position;
        destination.x = 0;
        transform.DOMove(destination, movementDuration)
            .OnComplete(() => {
                gameObject.SetActive(false);
            });
    }
}