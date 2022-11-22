using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SInputSystem : MonoBehaviour
{
    private float positionX;
    private float moveXpos;
    private bool gameEnded = false;
    public float moveX { get => moveXpos; }

    private void Update() {
        if(gameEnded) {
            return;
        }

        if (Input.GetMouseButtonDown(0)) {
            positionX = Input.mousePosition.x;
        }

        else if (Input.GetMouseButton(0)) {
            Vector3 currentMousePosition = Input.mousePosition;

            moveXpos = currentMousePosition.x - positionX;

            positionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0)) {
            moveXpos = 0f;
        }
    }

    public void stopInput() {
        gameEnded = true;
    }
}
