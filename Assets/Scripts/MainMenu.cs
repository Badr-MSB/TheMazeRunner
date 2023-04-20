using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject scene;
    public GameObject canvas;
    public GameObject image;
    public GameObject ButtonPlay;
    public GameObject Buttonf;
    public GameObject ButtonI;
    public GameObject ButtonD;


    public void playButton()
    {
        ButtonPlay.SetActive(false);
        Buttonf.SetActive(true);
        ButtonI.SetActive(true);
        ButtonD.SetActive(true);

    }
    public void playGame(int difficulte)
    {
        scene.GetComponent<SceneCreator>().difficulte = difficulte;
        scene.GetComponent<SceneCreator>().Create();
        canvas.SetActive(false);
        image.SetActive(true);
    }
    public void gameover()
    {
        canvas.SetActive(true);
        Buttonf.SetActive(false);
        ButtonI.SetActive(false);
        ButtonD.SetActive(false);
        ButtonPlay.SetActive(true);
        image.SetActive(false);
        Cursor.lockState = CursorLockMode.None; // cursor in the midle of the screen
        Cursor.visible = true;
    }
}
