using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject CreateRoad(int index, Vector3 size, Vector3 position, Quaternion rotation)
    {
        GameObject road = new GameObject();
        road.name = "Road " + index; // giving road an index so that it can be uniquely identified
        road.tag = "Road";
        road.AddComponent<Cube>();
        road.GetComponent<Cube>().CreateCube(7);

        // Setting scale
        road.transform.localScale = size;
        // Setting position
        road.transform.position = position;
        // Setting rotation
        road.transform.rotation = rotation;

        return road;
    }
}
