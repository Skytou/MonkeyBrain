using UnityEngine;
using System.Collections;

public class CollisionSystem : MonoBehaviour {

    public GameObject gameOver_Panel;
    public GameObject win_Panel;
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
            win_Panel.SetActive(true);
        }

        else if(col.gameObject.tag=="Brick")
        {
            Debug.Log("you are out");
            gameOver_Panel.SetActive(true);
}
    }
}
