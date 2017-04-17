using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Macman : BaseUnit
{
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = new IntVector2(-1, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = new IntVector2(1, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = new IntVector2(0, 1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = new IntVector2(0, -1);
        }
        Move();
	}

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.GetComponent<Pill> () != null)
        {
            Destroy(otherCollider.gameObject);
            GameObject effect = PoolManager.instance.Spawn("EatPillEffect");
            effect.transform.position = otherCollider.transform.position;
        }

        // Added by me start
        /*
        else if (otherCollider.GetComponent<Teleport>() != null)
        {
            GameObject effect = PoolManager.instance.Spawn("GoTeleportEffect");  // need to be build later
            effect.transform.position = otherCollider.transform.position;
            //if 
        }
        */
    }

        //Added by me end
}
