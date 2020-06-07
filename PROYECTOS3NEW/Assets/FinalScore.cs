using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public BDDController bdd;
    private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        bdd = GameObject.FindObjectOfType<BDDController>();
        bdd.DownloadFromDatabase();
        scoreText.text = bdd.puntos.ToString();
    }

    
    
}
