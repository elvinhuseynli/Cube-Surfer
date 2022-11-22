using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManage : MonoBehaviour
{
    public List<string> listOfLevels = new List<string>();
    public int indexLevel;
    
    private void Awake() {
        listOfLevels.Add("Main");
        listOfLevels.Add("Main 1");
        listOfLevels.Add("Main 2");
        listOfLevels.Add("Main 3");
        Singleton();
    }

    public static SceneManage Instance;

    private void Singleton() {
        if(Instance != null && Instance!=this) {
            Destroy(gameObject);
        }

        Instance = this;
    }

    public int getIndex() {
        return indexLevel;
    }

    public void nextLevel() { 
        string[] textD = System.IO.File.ReadAllLines("Assets/Scripts/Database.txt");
        string level = textD[2];

        int index = listOfLevels.IndexOf(level);
        index++;
        if(index >= listOfLevels.Count) {
            index = 0;
        }

        indexLevel = index;

        writeNextLevel();

        SceneManager.LoadScene(listOfLevels[index]);
    }

    public void writeNextLevel() {
        string[] textD = System.IO.File.ReadAllLines("Assets/Scripts/Database.txt");
        textD[2] = listOfLevels[indexLevel];
        System.IO.File.WriteAllLines("Assets/Scripts/Database.txt", textD);
    }

}
