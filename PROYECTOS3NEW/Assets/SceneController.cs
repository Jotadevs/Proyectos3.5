using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public bool isSinglePlayer;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    public void ChangeScene(string level)
    {
        SceneManager.LoadScene(level);
    }


    public void SinglePlayer(string level)
    {
        isSinglePlayer = true;
        ChangeScene(level);
    }

    public void MultiPlayer(string level)
    {
        isSinglePlayer = false;
        ChangeScene(level);
    }




}
