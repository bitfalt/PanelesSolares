using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridGenerator : MonoBehaviour
{
    public GameObject prefab; // Drag your prefab here in the inspector
    public int rows = 4;
    public int columns = 10;
    public float spacing = 2.0f; // Distance between each GameObject

    void Start()
    {
        SpawnGrid();
    }

    void SpawnGrid()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // Calculate the position for the current GameObject
                Vector3 position = new Vector3(j * spacing + 50, 0, i * spacing + 50);
                // Instantiate the GameObject
                Instantiate(prefab, position, Quaternion.identity, this.transform);
            }
        }
    }
}
