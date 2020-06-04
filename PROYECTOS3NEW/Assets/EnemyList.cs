using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> otakus = new List<GameObject>();
    [SerializeField]
    private List<GameObject> cazas = new List<GameObject>();
    [SerializeField]
    
   
    
    public void AddOtakus(GameObject otaku)
    {
        otakus.Add(otaku);
    }
    public void AddCazas(GameObject caza)
    {
        cazas.Add(caza);
    }
}
