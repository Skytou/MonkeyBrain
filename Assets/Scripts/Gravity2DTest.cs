using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gravity2DTest : MonoBehaviour {
    Rigidbody2D monkeyRb;
    public int gravityScale;
    public bool gravityUp;
    public bool gravityDown;
    public bool gravityLeft;
    public bool gravityRight;
    public float moveSpeed;
    public Image gravity_Dir;
    // Use this for initialization
    void Start ()
    {
        monkeyRb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        GravityChange();
	}

    public void Gravity()
    {
        gravityScale += 1;
        switch (gravityScale)
        {
            case 1:
                gravityDown = true;
                gravityLeft = false;
                gravityRight = false;
                gravityUp = false;
                gravity_Dir.transform.Rotate(0, 0, 90);

                break;
            case 2:

                gravityDown = false;
                gravityLeft = true;
                gravityRight = false;
                gravityUp = false;

                break;
            case 3:

                gravityDown = false;
                gravityLeft = false;
                gravityRight = false;
                gravityUp = true;
                break;
            case 4:

                gravityDown = false;
                gravityLeft = false;
                gravityRight = true;
                gravityUp = false;

                break;


        }
        if (gravityScale > 3)
        {
            gravityScale = 0;
        }
    }
    public void GravityChange()
    {
        if (gravityDown)
        {
            monkeyRb.AddForce(Vector2.down*moveSpeed);
        }
        if (gravityLeft)
        {
            monkeyRb.AddForce(Vector2.left*moveSpeed);
        }
        if (gravityUp)
        {
            monkeyRb.AddForce(Vector2.up*moveSpeed);
        }
        if (gravityRight)
        {
            monkeyRb.AddForce(Vector2.right*moveSpeed);
        }
    }
}
