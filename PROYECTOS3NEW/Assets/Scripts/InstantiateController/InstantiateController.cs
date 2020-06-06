using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class InstantiateController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToInstantiate = new List<GameObject>();
    [SerializeField]
    private List<Vector3> objectsInitialTransform = new List<Vector3>();

    public void AddEnemy(GameObject enemy)
    {

        objectsToInstantiate.Add(enemy);
        objectsInitialTransform.Add(enemy.transform.localPosition);
    }

    public void InstanceMyObjects()
    {
        for(int i = 0; i < objectsToInstantiate.Count; i++)
        {
            objectsToInstantiate[i].transform.localPosition = objectsInitialTransform[i];
            objectsToInstantiate[i].SetActive(true);
        }
    }

   

}



