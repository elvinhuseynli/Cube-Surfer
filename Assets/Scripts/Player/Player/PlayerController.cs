using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator animatorPlayer;
    public PlayerMovement playerMovement;

    private void Awake() {
        Singleton();
    }

    public static PlayerController Instance;

    private void Singleton() {
        if(Instance != null && Instance!=this) {
            Destroy(gameObject);
        }

        Instance = this;
    }

    public void VictoryAnimation() {
        animatorPlayer.SetTrigger("Victory");
    }

    public void FailAnimation() {
        animatorPlayer.SetTrigger("Fail");
    }

    public void StopPlayer() {
        DOTween.To(() => playerMovement.forwardSpeed, x => playerMovement.forwardSpeed = x, 0, 0.003f);
    }
}
