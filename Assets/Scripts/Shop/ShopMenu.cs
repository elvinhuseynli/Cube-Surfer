using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    public GameObject text;
    private Vector4 color;
    private Vector3 position;
    private float[] positionDB = {0,0,0};
    public Material cubeColor;

    void Start() {
        string[] textD = System.IO.File.ReadAllLines("Assets/Scripts/Database.txt");
        string[] positionData = textD[1].Split(',');
        for(int i=0; i<3; i++) {
            positionDB[i] = (float) Convert.ToDouble(positionData[i]);
        }
        text.transform.position = new Vector3(positionDB[0],positionDB[1],positionDB[2]);
    }

    public void PlayGame() {

        Vector3 nullPosition = new Vector3(0,0,0);
        if(position!=nullPosition) {
            string[] textD = System.IO.File.ReadAllLines("Assets/Scripts/Database.txt");
            textD[1] = position.x + "," + position.y + "," + position.z;
            System.IO.File.WriteAllLines("Assets/Scripts/Database.txt", textD);
        }
        
        Vector4 nullColor = new Vector4(0,0,0,0);
        if(color!=nullColor){ cubeColor.color = color;}
        SceneManager.LoadScene("MenuScene");
    }

    public void setActive() {
        GameObject button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        position = button.transform.position;
        color = button.GetComponent<Image>().color;
        text.transform.position = position;
    }
}
