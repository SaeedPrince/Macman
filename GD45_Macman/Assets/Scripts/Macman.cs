using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Macman : BaseUnit
{
    public Material MacmanNormalMaterial;
    public Material MacmanPowerupMaterial;

    // Update is called once per frame
    void Update ()
    {
        // Change Color when powerup
        MeshRenderer gameObjectRenderer = gameObject.GetComponent<MeshRenderer>();
        if (GameManager.instance.bPowerup)
        {
            gameObjectRenderer.material = MacmanPowerupMaterial;
        }
        else
        {
            gameObjectRenderer.material = MacmanNormalMaterial;
        }

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
        // macman can get powerup
        else if (otherCollider.GetComponent<PowerUp>() != null)
        {
            Destroy(otherCollider.gameObject);
            GameObject effect = PoolManager.instance.Spawn("EatPillEffect");
            effect.transform.position = otherCollider.transform.position;
            GameManager.instance.bPowerup = true;
            GameManager.instance.PowerupTimer = 5;
        }
        // when macman powersup can eat ghosts
        if (otherCollider.GetComponent<Ghost>() != null)
        {
            if (GameManager.instance.bPowerup)
            {
                Destroy(otherCollider.gameObject);
                GameObject effect = PoolManager.instance.Spawn("EatPillEffect");
                effect.transform.position = otherCollider.transform.position;
            }
        }
        // Added by me end
    }
}
