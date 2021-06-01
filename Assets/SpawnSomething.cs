using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSomething : MonoBehaviour
{

    public GameObject cubePrefab;
    public int length = 10;
    public List<GameObject> allCubes = new List<GameObject>();
    void Start()
    {
        Spawn3DArray();
    }
    void Update()
    {
        SineMove();
    }

    void SineMove()
    {
        for(int i = 0; i < allCubes.Count; i++)
        {
            GameObject currentCube = allCubes[i];

            float sine = Mathf.Sin(Time.time + Random.Range(1,10000)) * Time.deltaTime;

            Vector3 newPosition = new Vector3(
                currentCube.transform.position.x + sine,
                currentCube.transform.position.y + sine,
                currentCube.transform.position.z + sine
                );

            currentCube.transform.position = newPosition;

        }
    }


    void Spawn2DArray()
    {
        for(int x = 0; x < length; x++)
        {
            for(int y = 0; y < length; y++)
            {
                GameObject currentCube = Instantiate(cubePrefab);
                allCubes.Add(currentCube);
                currentCube.transform.position = new Vector3(x, y, 0);
            }
        }
    }

    void Spawn3DArray()
    {
        for(int x = 0; x < length; x++)
        {
            for(int y = 0; y < length; y++)
            {

                for (int z = 0; z < length; z++)
                {
                    GameObject currentCube = Instantiate(cubePrefab);
                    currentCube.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();

                    allCubes.Add(currentCube);
                    Vector3 newPos = new Vector3(x * 2 , y * 2, z * 2);
                    currentCube.transform.position = newPos;
                }
            }
        }
    }
}
