using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        City city = new City();

        // Possible positions to generate cities
        Vector3 pos1 = new Vector3(-30, 0, 30);
        Vector3 pos2 = new Vector3(30, 0, 30);
        Vector3 pos3 = new Vector3(-30, 0, -30);
        Vector3 pos4 = new Vector3(30, 0, -30);

        Vector3[] positions = { pos1, pos2, pos3, pos4 };

        for (int i = 1; i <= 2; i++)
        {
            //city.CreateCity(i, positions[Random.Range(0,3)]);
        }
    }
}
