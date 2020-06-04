using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnemy : MonoBehaviour
{
    [SerializeField]
    private InstantiateController controller;
    private void Awake()
    {
        controller = GameObject.FindObjectOfType<InstantiateController>();
    }
    private void Start()
    {
        controller.AddEnemy(this.gameObject);
    }
}
