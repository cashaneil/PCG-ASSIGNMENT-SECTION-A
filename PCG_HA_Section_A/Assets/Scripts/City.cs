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
        GameObject car = Resources.Load<GameObject>("CarController");
        Instantiate(car, startPos, Quaternion.identity);

        GenerateBuildings();
        GenerateRoads();
    }

    void GenerateBuildings()
    {
        // Instance of Building
        Building building = new Building();

        // Possible Building Positions
        Vector3 buildPos1 = new Vector3(-17.5f, 0, 16.75f);
        Vector3 buildPos2 = new Vector3(-11.75f, 0, 16.75f);
        Vector3 buildPos3 = new Vector3(-6, 0, 16.75f);
        Vector3 buildPos4 = new Vector3(-1.75f, 0, 16.75f);
        Vector3 buildPos5 = new Vector3(3, 0, 16.75f);
        Vector3 buildPos6 = new Vector3(-17.5f, 0, 13.25f);
        Vector3 buildPos7 = new Vector3(-17.5f, 0, 10);
        Vector3 buildPos8 = new Vector3(-17.5f, 0, 6.75f);
        Vector3 buildPos9 = new Vector3(-17.5f, 0, 3.25f);
        Vector3 buildPos10 = new Vector3(-12, 0, 3.25f);
        Vector3 buildPos11 = new Vector3(-5.5f, 0, 3.25f);
        Vector3 buildPos12 = new Vector3(-0.25f, 0, 3.25f);
        Vector3 buildPos13 = new Vector3(13, 0, 14.5f);
        Vector3 buildPos14 = new Vector3(13, 0, 8.25f);
        Vector3 buildPos15 = new Vector3(13, 0, 0.5f);
        Vector3 buildPos16 = new Vector3(10.25f, 0, -11.25f);
        Vector3 buildPos17 = new Vector3(0, 0, -11.25f);
        Vector3 buildPos18 = new Vector3(-9.5f, 0, -11.25f);

        Vector3[] buildingPositions = { buildPos1,
            buildPos2,
            buildPos3,
            buildPos4,
            buildPos5,
            buildPos6,
            buildPos7,
            buildPos8,
            buildPos9,
            buildPos10,
            buildPos11,
            buildPos12,
            buildPos13,
            buildPos14,
            buildPos15,
            buildPos16,
            buildPos17,
            buildPos18
        };

        for (int i = 1; i <= 10; i++)
        {
            Vector3 randomSize = new Vector3(
                Random.Range(1, 3),
                Random.Range(3, 10),
                Random.Range(1, 3)
            );

            // Get buildings generated so far
            GameObject[] genBuildings = GameObject.FindGameObjectsWithTag("Building");

            // Generate random building position
            Vector3 randomPos = buildingPositions[Random.Range(0, 18)];
            // For every building generated so far
            foreach (GameObject g in genBuildings)
            {
                if (g.transform.position == randomPos)
                {
                    // If building's position is the same as the generated random position
                    // Keep generating another random position until it is different from building's
                    do
                    {
                        randomPos = buildingPositions[Random.Range(0, 18)];
                    } while (g.transform.position == randomPos);
                }
            }

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

        // Initializing static road sizes
        Vector3 road1Size = new Vector3(1.5f, 0.01f, 23.7486401f);
        Vector3 road2Size = new Vector3(1.5f, 0.01f, 20.2499981f);
        Vector3 road3Size = new Vector3(1.5f, 0.01f, 14.7503996f);
        Vector3 road4Size = new Vector3(1.5f, 0.01f, 20.75f);
        Vector3 road5Size = new Vector3(1.5f, 0.01f, 10.3086815f);
        Vector3 road6Size = new Vector3(1.5f, 0.01f, 7.75040007f);
        Vector3 road7Size = new Vector3(1.5f, 0.01f, 20.2108269f);

        Vector3[] roadsSizes = { road1Size, road2Size, road3Size, road4Size, road5Size, road6Size, road7Size };

        // Initializing static road positions
        Vector3 road1Pos = new Vector3(-22, 0.01f, -0.875007629f);
        Vector3 road2Pos = new Vector3(-0.375f, 0.01f, -23);
        Vector3 road3Pos = new Vector3(-5.75000095f, 0.01f, -2);
        Vector3 road4Pos = new Vector3(18.5f, 0.01f, -0.75f);
        Vector3 road5Pos = new Vector3(7.5f, 0.01f, 9.81600189f);
        Vector3 road6Pos = new Vector3(-1.625f, 0.01f, 11);
        Vector3 road7Pos = new Vector3(-0.288599998f, 0.01f, 21.4f);

        Vector3[] roadsPos = { road1Pos, road2Pos, road3Pos, road4Pos, road5Pos, road6Pos, road7Pos };

        // Initializing static road rotations
        Quaternion road1Rot = Quaternion.Euler(0, 0, 0);
        Quaternion road2Rot = Quaternion.Euler(0, 90, 0);
        Quaternion road3Rot = Quaternion.Euler(0, 90, 0);
        Quaternion road4Rot = Quaternion.Euler(0, 0, 0);
        Quaternion road5Rot = Quaternion.Euler(0, 0, 0);
        Quaternion road6Rot = Quaternion.Euler(0, 90, 0);
        Quaternion road7Rot = Quaternion.Euler(0, 90, 0);

        Quaternion[] roadsRot = { road1Rot, road2Rot, road3Rot, road4Rot, road5Rot, road6Rot, road7Rot };

        for (int i = 0; i < 7; i++)
        {
            GameObject newRoad = road.CreateRoad(i, roadsSizes[i], roadsPos[i], roadsRot[i]);
            newRoad.AddComponent<BoxCollider>();
            // Make the generated road a child for a city according to the passed index
            newRoad.transform.parent = this.transform;
        }
    }
}
