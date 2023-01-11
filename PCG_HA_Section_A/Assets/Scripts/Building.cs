using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject CreateBuilding(int index, Vector3 size, Vector3 position, int material)
    {
        GameObject building = new GameObject();
        building.name = "Building " + index; // giving building an index so that it can be uniquely identified
        building.AddComponent<Cube>();
        building.GetComponent<Cube>().CreateCube(material);

        // Setting scale
        building.transform.localScale = size;
        // Setting position
        building.transform.position = position;

        return building;
    }
}
