using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject plane = new GameObject();
        plane.name = "Plane";
        plane.transform.parent = this.transform;
        plane.AddComponent<Cube>();
        plane.GetComponent<Cube>().CreateCube(0);

        // Setting scale
        plane.transform.localScale = new Vector3(20, 0.1f, 20);
        // Setting position
        plane.transform.position = new Vector3(0, -0.1f, 0);

        Buildings();
    }

    void Buildings()
    {
        // Instance of Building
        Building building = new Building();

        for (int i = 0; i < 10; i++)
        {
            Vector3 randomSize = new Vector3(
                Random.Range(1, 3),
                Random.Range(3, 10),
                Random.Range(1, 3)
            );

            Vector3 randomPos = new Vector3(
                Random.Range(-17.5f, 17.5f),
                randomSize.y, // y-axis pos needs to be equal y-axis scale so that building is above city plane
                Random.Range(-17.5f, 17.5f)
            );

            building.CreateBuilding(i, randomSize, randomPos, Random.Range(0, 7));
        }
    }
}
