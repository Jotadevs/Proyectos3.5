using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetAnyKey : MonoBehaviour
{
    
    public void Update()
    {
        StartCoroutine(ChangeScene());
    }

    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        if (Input.anyKey)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
