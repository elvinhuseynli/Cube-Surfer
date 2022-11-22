using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDetector : MonoBehaviour
{
    public CurrentCubeScore currentCubeScore;

    private void OnCollisionEnter(Collision collision) {

        if(collision.gameObject.CompareTag("Cube")) {    
            var cubeController = collision.gameObject.GetComponent<CubeController>();

            if(!cubeController.isStacked) {
                cubeController.playEffect();
                CubesManager.Instance.getCube(cubeController);
            }
        }

        if(collision.gameObject.CompareTag("Coin")) {
            currentCubeScore.updateMoney();
            Destroy(collision.gameObject);
        }
    }
}
