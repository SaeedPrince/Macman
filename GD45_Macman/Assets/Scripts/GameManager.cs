﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const int ROW_COUNT = 16;
    public const int COLUMN_COUNT = 18;
    public static GameManager instance;

    public BaseObject[] objectPrefabs;
    //this is a jagged array. Which means an array of arrays
    //The difference between a jagged array and a 2D array, is that a jagged array can have multiple sub-arrays with different lengths
    //public int[][] jaggedGrid;

    //This is a 2D array
    //0 = pill, 1 = wall, 2 = ghost, 3 = macman, 4 = teleport place, 5 = powerup

    public int[,] grid = new int[,]
    {
        { 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 1, 3, 1, 5, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1},
        { 1, 0, 0, 1, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1},
        { 1, 0, 0, 0, 0, 1, 1, 1, 2, 0, 0, 0, 0, 1, 0, 0, 0, 1},
        { 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1},
        { 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 1, 2, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1},
        { 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1},
        { 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1, 5, 0, 0, 1},
        { 1, 0, 1, 0, 1, 0, 1, 2, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1},
        { 1, 0, 1, 0, 1, 5, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1},
        { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 1, 1, 1, 1},
    };

    public bool bPowerup = false;
    public float PowerupTimer = 0;


void Awake ()
    {
        GameManager.instance = this;
    }

    // Use this for initialization
    void Start()
    {
        int gridSizeX = grid.GetLength(0);
        int gridSizeY = grid.GetLength(1);
        //for (startvalue of variable 'i'; condition to stay in loop; operation done to variable 'i' every loop
        for (int i = 0; i < gridSizeX; i++)
        {
            //We use a nested for-loop, because we have to iterate through a 2D array
            for (int j = 0; j < gridSizeY; j++)
            {
                //We can get each different value in the array by using i,j as an index
                int valueInGrid = grid[i, j];
                //We use valueInGrid as an index, to get the BaseObject, corresponding to the value in the grid
                BaseObject objectClone = Instantiate(objectPrefabs[valueInGrid]);
                //We set the grid object to the right position based on where it is in the grid
                objectClone.transform.localPosition = new Vector3(i, 0, j);
                //We set the posInGrid of our object, so our Units don't get moved to 0,0
                objectClone.posInGrid = new IntVector2(i, j);
            }
        }
    }

    // Update is called once per frame
    // Powerup expires after 5 seconds
    void Update()
    {
        if (PowerupTimer>0)
        {
            PowerupTimer -= Time.deltaTime;
        }
        else
        {
            bPowerup = false;
        }
    }
}
