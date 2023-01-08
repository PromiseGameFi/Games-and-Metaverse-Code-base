using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGen : MonoBehaviour
{
    // Drag and drop the prefabs for each type of object into these fields in the inspector
    public GameObject buildingPrefab;
    public GameObject roadPrefab;
    public GameObject trafficLightPrefab;
    public GameObject carPrefab;
    public GameObject pedestrianPrefab;
    public GameObject parkPrefab;
    public GameObject landmarkPrefab;

    // Other variables you may want to adjust in the inspector
    public int numBuildings = 100;
    public int numRoads = 10;
    public int numTrafficLights = 10;
    public int numCars = 10;
    public int numPedestrians = 10;
    public int numParks = 5;
    public int numLandmarks = 5;

    void Start()
    {
        // Generate the grid of cells
        for (int x = 0; x < numRoads; x++)
        {
            for (int z = 0; z < numRoads; z++)
            {
                Vector3 cellPosition = new Vector3(x * cellSize, 0, z * cellSize);

                // Place a road prefab in the center of each cell
                GameObject road = Instantiate(roadPrefab, cellPosition, Quaternion.identity);
                road.transform.parent = transform;

                // Place buildings and other objects around the road
                int numCellBuildings = Random.Range(1, 5);
                for (int i = 0; i < numCellBuildings && numBuildings > 0; i++)
                {
                    Vector3 buildingPosition = GetRandomPositionAround(cellPosition, cellSize * 0.4f);
                    GameObject building = Instantiate(buildingPrefab, buildingPosition, Quaternion.identity);
                    building.transform.parent = transform;
                    numBuildings--;
                }

                int numCellTrafficLights = Random.Range(0, 2);
                for (int i = 0; i < numCellTrafficLights && numTrafficLights > 0; i++)
                {
                    Vector3 trafficLightPosition = GetRandomPositionAround(cellPosition, cellSize * 0.4f);
                    GameObject trafficLight = Instantiate(trafficLightPrefab, trafficLightPosition, Quaternion.identity);
                    trafficLight.transform.parent = transform;
                    numTrafficLights--;
                }

                int numCellCars = Random.Range(0, 5);
                for (int i = 0; i < numCellCars && numCars > 0; i++)
                {
                    Vector3 carPosition = GetRandomPositionAround(cellPosition, cellSize * 0.4f);
                    GameObject car = Instantiate(carPrefab, carPosition, Quaternion.identity);
                    car.transform.parent = transform;
                    numCars--;
                }

                int numCellPedestrians = Random.Range(0, 5);
                for (int i = 0; i < numCellPedestrians && numPedestrians > 0; i++)
                {
                    Vector3 pedestrianPosition = GetRandomPositionAround(cellPosition, cellSize * 0.4f);
                    GameObject pedestrian = Instantiate(pedestrianPrefab, pedestrianPosition, Quaternion.identity);
                    pedestrian.transform.parent = transform;
                    numPedestrians--;
                }
            }
        }

        // Place parks and landmarks randomly throughout the city
        for (int i = 0; i < numParks; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            GameObject park = Instantiate(parkPrefab, randomPosition, Quaternion.identity);
            park.transform.parent = transform;
        }

        for (int i = 0; i < numLandmarks; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            GameObject landmark = Instantiate(landmarkPrefab, randomPosition, Quaternion.identity);
            landmark.transform.parent = transform;
        }
    }

    // Utility function for getting a random position within the bounds of the city
    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-50, 50);
        float z = Random.Range(-50, 50);
        return new Vector3(x, 0, z);
    }

    // Utility function for getting a random position within a certain radius of a given center point
    Vector3 GetRandomPositionAround(Vector3 center, float radius)
    {
        float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
        float x = center.x + radius * Mathf.Cos(angle);
        float z = center.z + radius * Mathf.Sin(angle);
        return new Vector3(x, 0, z);
    }

}
