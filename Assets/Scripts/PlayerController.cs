using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    const float MinOrthographicSize = 1.8f;
    const float MaxOrthographicSize = 2.8f;
    const float Velocity = 3f;
    const float StillThreshold = 1f;
    private float StillTimer = 0f;

    public Sprite FaceMaskSprite;
    public Sprite KeysSprite;
    public Sprite CarKeysSprite;
    public Sprite WalletSprite;
    public SpriteRenderer ItemSpriteRenderer;
    public SpriteRenderer PlayerSpriteRenderer;
    public CameraController Camera;
    public GameController GameController;
    public AudioSource ItemPickupAudioSource;
    public AudioSource WalkingAudioSource;

    private Animator Animator;
    private float dx, dy;
    private bool isMoving = false;
    private bool horizontal_priority = true;
    public bool[] grabbed_items = new bool[(int)ItemType.N_TYPES];
    public bool FaceMask = false;
    public bool HomeKeys = false;
    public bool CarKey = false;
    public bool Wallet = false;
    public bool canMove = true;

    void Start()
    {
        Animator = GetComponent<Animator>();
        RestartPlayer();
        ItemSpriteRenderer.enabled = false;
    }

    void Update()
    {
        if(canMove)
        {
            if (!isMoving)
            {
                StillTimer += Time.deltaTime;

                float horizontal_input = Input.GetAxisRaw("Horizontal");
                float vertical_input = Input.GetAxisRaw("Vertical");

                if (horizontal_input != 0 && vertical_input != 0)
                {
                    if (horizontal_priority)
                        setDisplacement(horizontal_input, 0);
                    else
                        setDisplacement(0, vertical_input);
                }
                else
                {
                    setDisplacement(horizontal_input, vertical_input);
                    horizontal_priority = horizontal_input == 0;
                }

                isMoving = (dx != 0 || dy != 0);
            }

            if (StillTimer > StillThreshold)
            {
                Camera.SetOrthographicSize(MaxOrthographicSize);
            }
            else 
            {
                Camera.SetOrthographicSize(MinOrthographicSize);
            }
        }
    }

    public void RestartPlayer()
    {
        Camera.CinemachineVirtualCamera.m_Lens.OrthographicSize = MinOrthographicSize;
        canMove = false;
        for (int i = 0; i < grabbed_items.Length; i++)
        {
            grabbed_items[i] = false;
        }
        GameController.setListItems(grabbed_items);
    }

    private string currentTrigger = "";
    private string orientation = "down";
    void FixedUpdate()
    {
        if (isMoving)
        {
            if(!WalkingAudioSource.isPlaying) 
            {
                WalkingAudioSource.Play();
            }

            if (dx < 0)
                updateAnimation("left");
            else if (dx > 0) 
                updateAnimation("right");
            else if (dy < 0)
                updateAnimation("down");
            else if (dy > 0)
                updateAnimation("up");

            float dt = Time.fixedDeltaTime;
            gameObject.transform.position += new Vector3(dx, dy, 0f) * dt * Velocity;
            isMoving = false;
            StillTimer = 0f;
        } 
        else
        {
            if (WalkingAudioSource.isPlaying) {
                WalkingAudioSource.Stop();
            }

            updateAnimation("still_" + orientation);
        }
    }

    public void GrabItem(ItemType item_type)
    {
        grabbed_items[(int)item_type] = true;
        Sprite itemSprite = FaceMaskSprite;
        switch ((int)item_type)
        {
            case (int)ItemType.FACE_MASK:
                FaceMask = true;
                itemSprite = FaceMaskSprite;
                break;
            case (int)ItemType.HOME_KEYS:
                HomeKeys = true;
                itemSprite = KeysSprite;
                break;
            case (int)ItemType.CAR_KEY:
                CarKey = true;
                itemSprite = CarKeysSprite;
                break;
            case (int)ItemType.WALLET:
                Wallet = true;
                itemSprite = WalletSprite;
                break;
            default:
                Debug.Log("Error: Unrecognized item type");
                break;
        }

        ItemSpriteRenderer.sprite = itemSprite;
        ItemSpriteRenderer.enabled = true;
        var originalSpriteRendererScale = ItemSpriteRenderer.transform.localScale;
        var maxSpriteRendererScale = originalSpriteRendererScale * 3f;
        var originalPosition = ItemSpriteRenderer.transform.localPosition;
        var originalColor = ItemSpriteRenderer.color;
        var newColor = originalColor;
        newColor.a = 0.2f;
        var duration = 0.8f;
        DOTween.Sequence()
                .Join(ItemSpriteRenderer.transform.DOScale(maxSpriteRendererScale, duration))
                .Join(ItemSpriteRenderer.transform.DOLocalMoveY(originalPosition.y + 1.5f, duration))
                .Join(ItemSpriteRenderer.DOColor(newColor, duration))
                .OnComplete(() => {
                    ItemSpriteRenderer.enabled = false;
                    ItemSpriteRenderer.transform.localScale = originalSpriteRendererScale;
                    ItemSpriteRenderer.transform.localPosition = originalPosition;
                    ItemSpriteRenderer.color = originalColor;
                });

        ItemPickupAudioSource.Play();

        GameController.setListItems(grabbed_items);
    }

    public void IsCloseTo(ItemType item, float distance)
    {
        GameController.playerIsCloseTo(item, distance);
    }
    private void setDisplacement(float new_dx, float new_dy) { dx = new_dx; dy = new_dy; }

    public void updateAnimation(string trigger)
    {
        if (currentTrigger != trigger)
        {
            Animator.SetTrigger(trigger);
            currentTrigger = trigger;
            orientation = trigger;
        }
    }
}
