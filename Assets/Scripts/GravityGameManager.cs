using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class GravityGameManager : MonoBehaviour

{
    public static GravityGameManager instance = null;
    public GameObject BackGroundImg;
    public SpriteRenderer bgSpriteRenderer;
    public GameObject monkey;
    public VirtualJoystick joystick;
    public float moveSpeed;
    private Rigidbody monkeyRb;
    private Vector3 HorizontalMoveVector, VerticalMoveVector;
    public int gravityScale=1;
    public bool gravityUp;
    public bool gravityDown;
    public bool gravityLeft;
    public bool gravityRight;
    public bool TesttingMode;
    public GameObject gravity_Dir_Down;
    public GameObject gravity_Dir_Up;
    public GameObject gravity_Dir_Right;
    public GameObject gravity_Dir_Left;
    float Angle=360;



    void Awake()
    {
        instance = this;
    }


    void Start()
    {
        
        monkeyRb = monkey.GetComponent<Rigidbody>();
    }


    void Update()
    {
        HorizontalMoveVector = HorizontalInput();
        VerticalMoveVector = VerticalInput ();
        MovePlayer();
        GravityChange();
    }


    void MovePlayer()
    {
        monkeyRb.AddForce((HorizontalMoveVector * moveSpeed));
        
        if (TesttingMode)
        {
            monkeyRb.AddForce((VerticalMoveVector * moveSpeed));
        }
       
    }


    private Vector3 HorizontalInput()
    {
        Vector3 dir = Vector3.zero;

        dir.x = joystick.Horizontal();
        

        if (dir.magnitude > 1)
            dir.Normalize();

        return dir;
    }


    private Vector3 VerticalInput()
    {
        Vector3 dir = Vector3.zero;

       
        dir.z = joystick.Vertical();

        if (dir.magnitude > 1)
            dir.Normalize();

        return dir;
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
                gravity_Dir_Down.SetActive(true);
                gravity_Dir_Left.SetActive(false);
                gravity_Dir_Up.SetActive(false);
                gravity_Dir_Right.SetActive(false);
                break;
            case 2:
                
                gravityDown = false;
                gravityLeft = true;
                gravityRight = false;
                gravityUp = false;
                gravity_Dir_Down.SetActive(false);
                gravity_Dir_Left.SetActive(true);
                gravity_Dir_Up.SetActive(false);
                gravity_Dir_Right.SetActive(false);
                break;
            case 3:
               
                gravityDown = false;
                gravityLeft = false;
                gravityRight = false;
                gravityUp = true;
                gravity_Dir_Down.SetActive(false);
                gravity_Dir_Left.SetActive(false);
                gravity_Dir_Up.SetActive(true);
                gravity_Dir_Right.SetActive(false);
                break;
            case 4:
                
                gravityDown = false;
                gravityLeft = false;
                gravityRight = true;
                gravityUp = false;
                gravity_Dir_Down.SetActive(false);
                gravity_Dir_Left.SetActive(false);
                gravity_Dir_Up.SetActive(false);
                gravity_Dir_Right.SetActive(true);
                break;
               

        }
        if (gravityScale > 3)
        {
            gravityScale = 0;
        }

    }


    public void GravityChange()
    {
        if(gravityDown)
        {
            monkeyRb.AddForce(0, 0, -moveSpeed);
           

        }
        if(gravityLeft)
        {
            monkeyRb.AddForce(-moveSpeed, 0,0);
            
        }
        if(gravityUp)
        {
            monkeyRb.AddForce(0, 0, moveSpeed);
            
        }
        if(gravityRight)
        {
            monkeyRb.AddForce(moveSpeed, 0, 0);
            
        }
    }


    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
