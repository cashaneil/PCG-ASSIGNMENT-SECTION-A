using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    void Start()
    {
        GameObject plane = new GameObject();
        plane.name = "Plane";
        plane.transform.parent = this.transform;
        plane.AddComponent<Cube>();
        plane.GetComponent<Cube>().CreateCube(0);

        // Setting scale
        plane.transform.localScale = new Vector3(30, 0.1f, 30);
        // Setting position
        plane.transform.position = new Vector3(0, -0.1f, 0);

        plane.AddComponent<BoxCollider>();

        GameObject marker = new GameObject();
        marker.name = "Marker"; // giving road an index so that it can be uniquely identified
        marker.AddComponent<Cube>();
        marker.GetComponent<Cube>().CreateCube(4);
        marker.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        marker.transform.position = new Vector3(25, 0.4f, -25);
        marker.AddComponent<BoxCollider>();
        marker.AddComponent<Marker>();

        // Specifying player start position
        Vector3 startPos = new Vector3(-20, 0.2643999f, 20);
        // Loading car controller prefab from Resources folder
        GameObject car = Resources.Load<GameObject>("Car_Controller");
        Instantiate(car, startPos, Quaternion.identity);

        GenerateBuildings();
        GenerateRoads();
    }

    void GenerateBuildings()
    {
        // Instance of Building
        Building building = new Building();

        for (int i = 1; i <= 10; i++)
        {
            Vector3 randomSize = new Vector3(
                Random.Range(1, 3),
                Random.Range(3, 10),
                Random.Range(1, 3)
            );

            // The X and Z coordinates are subtracted by their random size axi so that building doesn't appear off plane
            Vector3 randomPos = new Vector3(
                Random.Range((-24 + randomSize.x), (24 - randomSize.x)),
                randomSize.y, // y-axis pos needs to be equal y-axis scale so that building is above city plane
                Random.Range((-24 + randomSize.z), (24 - randomSize.z))
            );

            GameObject newBuilding = building.CreateBuilding(i, randomSize, randomPos, Random.Range(0, 7));
            newBuilding.AddComponent<BoxCollider>();
            // Make the generated building a child for a city according to the passed index
            newBuilding.transform.parent = this.transform;
        }
    }

    void GenerateRoads()
    {
        // Instance of Road
        Road road = new Road();

        for (int i = 1; i <= 10; i++)
        {
            Vector3 randomSize = new Vector3(
                1,
                0.01f,
                Random.Range(5, 15)
            );

            Vector3 randomPos = new Vector3(
                Random.Range(-17.5f, 17.5f),
                randomSize.y, // y-axis pos needs to be equal y-axis scale so that road is above city plane
                Random.Range(-17.5f, 17.5f)
            );

            // Road can only be rotated around the Y-axis at 0, 90, 180, 270 or 360 deg
            int[] possibleYRot = {0, 90, 180, 270, 360};
            // Random value from array for Y-axis rotation
            Quaternion randomRot = Quaternion.Euler(0, possibleYRot[Random.Range(0, 4)], 0);

            GameObject newRoad = road.CreateRoad(i, randomSize, randomPos, randomRot);
            newRoad.AddComponent<BoxCollider>();
            // Make the generated road a child for a city according to the passed index
            newRoad.transform.parent = this.transform;
        }
    }
}
