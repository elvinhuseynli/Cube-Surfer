using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CubesManager : MonoBehaviour
{
    private float stepLength = 0.043f;
    private float ground = 0.5f;
    private float playerStepLength = 0.0226f;
    public SInputSystem sInputSystem;
    public CurrentCubeScore currentCubeScore;
    public GameObject cubeM;
    public bool gameEnded=false;
    public List<CubeController> cubeControllerList = new List<CubeController>();

    private void Awake() {
        Singleton();
    }

    private void Start() {
        var cubeCon = cubeM.GetComponent<CubeController>();
        this.getCube(cubeCon);
    }

    public static CubesManager Instance;

    private void Singleton() {
        if(Instance != null && Instance!=this) {
            Destroy(gameObject);
        }

        Instance = this;
    }

    public void getCube(CubeController cubeController) {
        cubeControllerList.Add(cubeController);
        cubeController.isStacked = true;

        cubeController.transform.parent = transform;

        orderCubes();

        orderPlayer();
    }

    public void dropCube(CubeController cubeController) {
        cubeController.transform.parent = null;
        cubeController.isStacked = false;

        cubeControllerList.Remove(cubeController);

        if(cubeControllerList.Count < 1) {

            PlayerController.Instance.FailAnimation();
            PlayerController.Instance.StopPlayer();

            sInputSystem.stopInput();

            currentCubeScore.showEndScreen();

            var playerTransform2 = PlayerController.Instance.transform;
            Vector3 groundTarget = new Vector3(-0.02434914f, -1.0f, -6.837307f);
            playerTransform2.DOLocalJump(groundTarget, 0.05f, 1, 0.5f);

            return;

        }

        orderPlayer();
    }

    private void orderPlayer() {
        int index = cubeControllerList.Count - 1;
        var playerTransform = PlayerController.Instance.transform;
        var target = new Vector3(-0.02434914f, (index-1)*ground, -5.837307f);
        playerTransform.transform.DOLocalMove(target, 0f);
    }

    private void orderCubes() {
        int index = cubeControllerList.Count-1;

        Vector3 target = new Vector3(-0.02434914f, 0.6258709f, -5.837307f);
        cubeControllerList[index].transform.DOLocalMove(target, 0f);
    }
}
