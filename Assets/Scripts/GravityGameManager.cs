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
        //	ResizeBackGroundImage ();
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
        //player_rb_2.AddForce((HorizontalMoveVector * -moveSpeed));
        if (TesttingMode)
        {
            monkeyRb.AddForce((VerticalMoveVector * moveSpeed));
        }
        //player_rb_2.AddForce((VerticalMoveVector * moveSpeed));
        //		if (CrossPlatformInputManager.GetAxis ("Horizontal") > 0)
        //		{
        //			player_rb_1.AddForce (moveSpeed, 0, 0);
        //			player_rb_2.AddForce (-moveSpeed, 0, 0);
        //		}
        //			
        //	
        //		if (CrossPlatformInputManager.GetAxis ("Horizontal") < 0)
        //		{
        //			player_rb_1.AddForce (-moveSpeed,0,0);
        //			player_rb_2.AddForce (moveSpeed,0,0);
        //		}
        //
        //
        //		if (CrossPlatformInputManager.GetAxis ("Vertical") > 0)
        //		{
        //			player_rb_1.AddForce (0, 0, moveSpeed);
        //			player_rb_2.AddForce (0, 0, moveSpeed);
        //		}
        //
        //
        //		if (CrossPlatformInputManager.GetAxis ("Vertical") < 0) 
        //		{
        //			player_rb_1.AddForce (0, 0, -moveSpeed);
        //			player_rb_2.AddForce (0, 0, -moveSpeed);
        //		}
    }


    private Vector3 HorizontalInput()
    {
        Vector3 dir = Vector3.zero;

        dir.x = joystick.Horizontal();
        //dir.z = joystick.Vertical ();

        if (dir.magnitude > 1)
            dir.Normalize();

        return dir;
    }

    private Vector3 VerticalInput()
    {
        Vector3 dir = Vector3.zero;

        //dir.x = joystick.Horizontal ();
        dir.z = joystick.Vertical();

        if (dir.magnitude > 1)
            dir.Normalize();

        return dir;
    }


    


    void ResizeBackGroundImage()
    {
        if (bgSpriteRenderer == null) return;

        transform.localScale = new Vector3(1, 1, 1);

        float width = bgSpriteRenderer.sprite.bounds.size.x;
        float height = bgSpriteRenderer.sprite.bounds.size.y;


        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 xWidth = BackGroundImg.transform.localScale;
        xWidth.x = worldScreenWidth / width;
        BackGroundImg.transform.localScale = xWidth;
        //transform.localScale.x = worldScreenWidth / width;
        Vector3 yHeight = BackGroundImg.transform.localScale;
        yHeight.y = worldScreenHeight / height;
        BackGroundImg.transform.localScale = yHeight;
        //transform.localScale.y = worldScreenHeight / height;
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
