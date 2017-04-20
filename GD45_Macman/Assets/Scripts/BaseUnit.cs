using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : BaseObject {

    // Assigning numbers as constants to clarify
    public const int COLUMN_COUNT = 18;
    public const int ROW_COUNT = 16;

    public float speed;

    protected IntVector2 direction;

    protected IntVector2 nextPosInGrid;

    private Vector3 posInWorld;
    private Vector3 nextPosInWorld;
    public Macman macMan;

    protected float moveTimer = Mathf.Infinity;

	// Use this for initialization
	void Start ()
    {
        //We assign nextPosInGrid, because when moveTimer >=1, the posInGrid gets set to that
        nextPosInGrid = posInGrid;
	}
	
    protected void Move ()
    {
        bool bTeleport = false;
        if (moveTimer >= 1f)
        {
            //We calculate the next position, based on the current position and direction
            nextPosInGrid = posInGrid + direction;
            if (GameManager.instance.grid[nextPosInGrid.x, nextPosInGrid.y] == 1)
            {
                nextPosInGrid = posInGrid;
            }
            else if (GameManager.instance.grid[nextPosInGrid.x, nextPosInGrid.y] == 4)
            {
                nextPosInGrid = myTwinPosInGrid(nextPosInGrid);
                bTeleport = true;
            }

            //We convert the IntVector2, to a Vector3 to place our object in 3D space
            posInWorld = new Vector3(posInGrid.x, 0, posInGrid.y);
            nextPosInWorld = new Vector3(nextPosInGrid.x, 0, nextPosInGrid.y);

            moveTimer = 0;
        }
        //We increment the moveTimer by the duration of the last frame
        moveTimer += Time.deltaTime * speed;
        if (bTeleport)
        {
            bTeleport = false;
            // teleporting in 3 steps to avoid passing from center of the scene
            Vector3 vStep1 = new Vector3(posInWorld.x, posInWorld.y - 1000, posInWorld.z);
            Vector3 vStep2 = new Vector3(nextPosInWorld.x, -1000, nextPosInWorld.y);
            Vector3 vStep3 = new Vector3(nextPosInWorld.x, 0, nextPosInWorld.y);
            transform.localPosition = vStep1;
            transform.localPosition = vStep2;
            transform.localPosition = vStep3;
        }
        else
        {
            transform.localPosition = Vector3.Lerp(posInWorld, nextPosInWorld, moveTimer);
        }
        posInGrid = nextPosInGrid;
    }

    public IntVector2 myTwinPosInGrid(IntVector2 inpPos)
    {
        IntVector2 iv2Ret;
        iv2Ret.x = ROW_COUNT - inpPos.x - 1;
        iv2Ret.y = COLUMN_COUNT - inpPos.y - 1;
        return iv2Ret;
    }
}
