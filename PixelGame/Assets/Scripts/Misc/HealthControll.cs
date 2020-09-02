using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControll : MonoBehaviour
{
    private List<GameObject> objects = new List<GameObject>();
    public GameObject health;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject obj = Instantiate(health);
            obj.transform.SetParent(transform, false);
            objects.Add(obj);
        }
    }

    public void DestroyHealth()
    {
        var obj = objects[objects.Count - 1];

        Destroy(obj);
        objects.Remove(objects[objects.Count - 1]);
    }
    
}
