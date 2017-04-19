using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour {

    public IntVector2 posInGrid;
    /*
    // Added by me start
    public IntVector2 twinPosInGrid
    {
        get
        {
            IntVector2 iv2Ret = new IntVector2(0, 0);
            iv2Ret.x = ROW_COUNT - posInGrid.x;
            iv2Ret.y = posInGrid.y;
            return iv2Ret;
        }
    }

    /*
    public const int OBJECT_TYPE_EMPTY = 0;
    public const int OBJECT_TYPE_WALL = 1;
    public const int OBJECT_TYPE_GHOST = 2;
    public const int OBJECT_TYPE_MACMAN = 3;
    public const int OBJECT_TYPE_TELEPORT = 4;

    private int iObjectType;
    public int Index;
    private Vector3 vec3SpawnPosition;
    public Vector3 vec3TwinPosition
    {
        get
        {
            Vector3 v3Ret = new Vector3(0, 0, 0);
            v3Ret.x = vec3SpawnPosition.x;
            if (vec3SpawnPosition.z == 0)
            {
                v3Ret.z = COLUMN_COUNT - 1;
            }
            else if (vec3SpawnPosition.z == COLUMN_COUNT - 1)
            {
                v3Ret.z = 0;
            }
            return v3Ret;
        }
    }

    public void SetSpawnPosition(Vector3 inpPosition)
    {
        vec3SpawnPosition = inpPosition;
    }

    public void SetObjectType(int lObjectType)
    {
        iObjectType = lObjectType;
    }
    */
    // Added by me end
}
