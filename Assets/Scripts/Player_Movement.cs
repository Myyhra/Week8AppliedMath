// using System.Numerics;
using System.Linq;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] AABB_Box footCollider;
    [SerializeField] AABB_Box XCollider;
    [SerializeField] AABB_Box ZCollider;
    [SerializeField] AABB_Box negaXCollider;
    [SerializeField] AABB_Box negaZCollider;



    //Might do 5 Colliders hardcoding instead if things get confusing
    //if so must have an array of all floors and walls and just use isoverlapping instead
    //because right now the collision manager is killing everything




    public float speed;
    public float gravity;
    public float gravityMultiplier;
    public float jumpforce;

    public bool isGrounded;
    [SerializeField]float verticalVelocity;
    [SerializeField]float XVelocity;
    [SerializeField]float ZVelocity;


    void Start()
    {
        
    }
    
    void Update()
    {
        GroundCheck();
        Gravity();
        XMove();
        ZMove();
        Vector3 move = new Vector3(XVelocity,0f, ZVelocity);

        // Movement();

        Jump();
        transform.position += Vector3.up * verticalVelocity * Time.deltaTime;

       
        transform.position += move * speed * Time.deltaTime;
        
    }
 
    void GroundCheck()
    {
        isGrounded = footCollider.isColliding;
    }


    void Gravity()
    {     
        if (!isGrounded)
        {
            verticalVelocity -= (gravity * gravityMultiplier) * Time.deltaTime;
        }
        else
        {
            verticalVelocity = 0f;
        }
        
    }

    void Jump()
    {
        if(isGrounded && Input.GetButton("Jump"))
        {
            verticalVelocity = jumpforce;
        }

    }

    void XMove()
    {
        XVelocity = Input.GetAxis("Horizontal");
        if(XCollider.isColliding)
        {
            XVelocity = 0f;
        }
    }
    void ZMove()
    {
        ZVelocity = Input.GetAxis("Vertical");
        if(ZCollider.isColliding)
        {
            ZVelocity = 0f;
        }
    }





    
}

/* 
 void Gravity()
    {
        if(isGrounded) return;
        
        Vector3 down = new Vector3(transform.position.x,(gravity * gravityMultiplier) * Time.deltaTime, transform.position.z);
        lastYlocation = transform.position.y;
        transform.position -= down;
        
    }

    void StayGround()
    {
        if(!isGrounded) return;
        Vector3 ground = new Vector3(transform.position.x,lastYlocation,transform.position.z);
        transform.position= ground;
        
    } */