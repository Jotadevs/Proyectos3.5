using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControllerFinder : MonoBehaviour
{
    public SceneController sceneController;
    private void Start()
    {
        sceneController = GameObject.FindObjectOfType<SceneController>();
    }

    public void CallChangeScene(string level)
    {
        sceneController.ChangeScene(level);
    }

}
