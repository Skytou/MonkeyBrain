using UnityEngine;
using System.Collections;

public class CollisionSystem : MonoBehaviour {

	
	void Start ()
    {
	
	}
	
	
	void Update ()
    {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Finish")
        {
            Debug.Log("LevelComplete");
        }

        else if(col.gameObject.tag=="Brick")
        {
            Debug.Log("you are out");
        }
    }
}
