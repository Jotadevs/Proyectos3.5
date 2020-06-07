using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 0;
    public BDDController BDD;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        BDD = GameObject.FindObjectOfType<BDDController>();
    }

    
    public void UpdateDatabase(int vida, string player)
    {
        BDD.ConnectDataBase(score, vida, player);
    }


    void Update()
    {
        scoreText.text = score.ToString();
    }
    public void AddScore(int newValue)
    {
        score += newValue;
    }
    


    
}
