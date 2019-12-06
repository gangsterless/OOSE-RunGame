using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tag.ball)
        {
            other.transform.parent.parent.SendMessage("HitBallDoor",SendMessageOptions.RequireReceiver);
            gameObject.transform.parent.parent.SendMessage("ShootAGoal",(int) other.transform.position.x);
        }
    }
}
