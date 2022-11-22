using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private SInputSystem swerveInputSystem;

    [SerializeField]
    private float speed = 0.5f;

    [SerializeField]
    private float maxAmount = 1f;
	public float forwardSpeed = 5.0f;
    private bool gameEnded = false;
    public SInputSystem sInputSystem;
    public CurrentCubeScore currentCubeScore;

    void FixedUpdate() {
        if(gameEnded) {
            return;
        }

        if(transform.position.z >= 116) {
            PlayerController.Instance.VictoryAnimation();
            PlayerController.Instance.StopPlayer();
            
            gameEnded = true;
            sInputSystem.stopInput();
            currentCubeScore.showWinScreen();
        }
        
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed); 

        float swerveAmount = Time.deltaTime * speed * swerveInputSystem.moveX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxAmount, maxAmount);

        if(swerveAmount > 0) {
            if(transform.position.x + swerveAmount <= 2) {
                transform.Translate(swerveAmount, 0f, 0f);
            } else {
                transform.position = new Vector3(2f, transform.position.y, transform.position.z);
            }
        } else {
            if(transform.position.x + swerveAmount >= -2) {
                transform.Translate(swerveAmount, 0f, 0f);
            } else {
                transform.position = new Vector3(-2f, transform.position.y, transform.position.z);
            }
        }



    }
}
