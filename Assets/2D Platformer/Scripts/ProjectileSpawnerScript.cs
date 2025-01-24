
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnerScript : MonoBehaviour
{
    public GameObject cubePrefab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(cubePrefab, transform.position, Quaternion.identity);
        }
    }
}