using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpawner : MonoBehaviour
{
    public GameObject saw;

    private void Start()
    {
        InvokeRepeating("SpawnSaw", 2, 1.15f);
    }


    public void SpawnSaw()
    {
        GameObject copy = Instantiate(saw, transform.position, Quaternion.identity);

        StartCoroutine(MoveSaw(copy));
    }

    private IEnumerator MoveSaw(GameObject sawObj)
    {
        yield return new WaitForSeconds(1.05f);

        if(sawObj != null)
        sawObj.GetComponent<Saw>().StartMoving();
    }
}
