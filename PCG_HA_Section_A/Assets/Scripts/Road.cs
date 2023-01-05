using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public void CreateRoad(int roadIdx, Vector3 size, Vector3 position, Quaternion rotation)
    {
        GameObject road = new GameObject();
        road.name = "Road " + roadIdx; // giving road an index so that it can be uniquely identified
        road.transform.parent = GameObject.Find("City").transform;
        road.AddComponent<Cube>();
        road.GetComponent<Cube>().CreateCube(7);

        // Setting scale
        road.transform.localScale = size;
        // Setting position
        road.transform.position = position;
        // Setting rotation
        road.transform.rotation = rotation;
    }
}
