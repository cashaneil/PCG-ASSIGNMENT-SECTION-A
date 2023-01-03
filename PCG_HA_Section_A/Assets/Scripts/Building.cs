using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public void CreateBuilding(int buildingIdx, Vector3 size, Vector3 position, int material)
    {
        GameObject building = new GameObject();
        building.name = "Building " + buildingIdx; // giving building an index so that it can be uniquely identified
        building.transform.parent = GameObject.Find("City").transform;
        building.AddComponent<Cube>();
        building.GetComponent<Cube>().CreateCube(material);

        // Setting scale
        building.transform.localScale = size;
        // Setting position
        building.transform.position = position;
    }
}
