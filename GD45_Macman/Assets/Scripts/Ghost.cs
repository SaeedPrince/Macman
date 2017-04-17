using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : BaseUnit {

    //We store all directions for the AI to move in, in an array
    IntVector2[] directions = new IntVector2[]
    {
        new IntVector2(0,1),
        new IntVector2(0,-1),
        new IntVector2(1,0),
        new IntVector2(-1,0)
    };

    // Update is called once per frame
    void Update()
    {
        if (moveTimer >= 1f)
        {
            //We create a list to store the directions we can move in
            List<IntVector2> options = new List<IntVector2>();
            foreach (IntVector2 dir in directions)
            {
                //0 == pill, 1 == wall
                //We use the position where we currently are (nextPosInGrid) + each direction, to determine the points around us
                int adjacentObjInGrid = GameManager.instance.grid[nextPosInGrid.x + dir.x, nextPosInGrid.y + dir.y];
                //If the adjacent object is not a wall....
                //If dir is not the opposite of my current direction (it shouldn't go from forward to backward)
                //E.g. if direction = 0,1 and dir = 0,-1
                // if 0 == (-0) && 1 == -(-1), don't add it to options
                if (adjacentObjInGrid != 1 && !(dir.x == -direction.x && dir.y == -direction.y))
                {
                    //Add this to my options
                    options.Add(dir);
                }
            }

            //If there are no options (= dead end), go back where you came from
            if (options.Count == 0)
            {
                direction = -direction;
            }
            else
            {
                //We set our direction to a random option
                direction = options[Random.Range(0, options.Count)];
            }

        }
        Move();
    }
}