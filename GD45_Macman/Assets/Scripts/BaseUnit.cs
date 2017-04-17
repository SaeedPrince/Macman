using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : BaseObject {

    public float speed;

    protected IntVector2 direction;

    protected IntVector2 nextPosInGrid;

    private Vector3 posInWorld;
    private Vector3 nextPosInWorld;

    protected float moveTimer = Mathf.Infinity;

	// Use this for initialization
	void Start () {
        //We assign nextPosInGrid, because when moveTimer >=1, the posInGrid gets set to that
        nextPosInGrid = posInGrid;
	}
	
    protected void Move ()
    {
        if (moveTimer >= 1f)
        {
            posInGrid = nextPosInGrid;
            //We calculate the next position, based on the current position and direction
            nextPosInGrid = posInGrid + direction;

            if (GameManager.instance.grid[nextPosInGrid.x, nextPosInGrid.y] == 1)
            {
                nextPosInGrid = posInGrid;
            }

            //We convert the IntVector2, to a Vector3 to place our object in 3D space
            posInWorld = new Vector3(posInGrid.x, 0, posInGrid.y);
            nextPosInWorld = new Vector3(nextPosInGrid.x, 0, nextPosInGrid.y);

            moveTimer = 0;
        }
        //We increment the moveTimer by the duration of the last frame
        moveTimer += Time.deltaTime * speed;
        transform.localPosition = Vector3.Lerp(posInWorld, nextPosInWorld, moveTimer);
    }
}
