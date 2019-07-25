using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4f;
    public float jumpPower = 5f;
    new Rigidbody rigidbody;
    
    Animator animator;
    Vector3 movement;
    float h;
    float v;
    bool isJumping = false;
    //int jumpCount = 0;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //animator.SetBool("isMoving", false);
    }
   
    void Update()// 키 입력
    {
        //if()
        h = Input.GetAxisRaw("Horizontal"); // 키보드가 x축방향으로 눌렸는지 왼쪽 멈춤 오른쪽
        v = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }
    void FixedUpdate() // 물리적 처리
    {
      /*  float h = Input.GetAxisRaw("Horizontal"); // 키보드가 x축방향으로 눌렸는지 왼쪽 멈춤 오른쪽
        float v = Input.GetAxisRaw("Vertical");*/
        // 키보드 y축 방향으루 눌렸는지 방향 위쪽 멈춤 아래쪽
        Run();
        if(isJumping)
        {
            Jump();
            
        }
       

        if (h == 0 && v == 0)
        {
            animator.SetBool("isMoving", false);

        }
        else
        {
            animator.SetBool("isMoving", true);
            if (h == 0 && v == 1)
            {
                animator.SetInteger("direction", 0);
            }
            else if (h == 0 && v == -1)
            {
                animator.SetInteger("direction", 1);
            }
            else if (h ==1 && v == 0)
            {
                animator.SetInteger("direction", 2);
            }
            else if (h == -1 && v == 0)
            {
                animator.SetInteger("direction", 3);
            }
           
        }
        if (Input.GetKey(KeyCode.R))
        {
            transform.localRotation = Quaternion.Euler(1.0f, 0, 1.0f);
        }
    }
    public 
    void Run()
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;
        rigidbody.MovePosition(transform.position + movement);
    }
    void Jump()
    {
       
           
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJumping = false;
       
       
    }
    //public void ResetJumpCount()
    
  
}
    /*public int speed;
    Vector3 movement;
    public bool jumpable = true;
    Animator animator;
    public bool keypress = false;
     void Start()
    {
        
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            //keypress = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            //keypress = true;
                
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //keypress = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            //keypress = true;
        }
        if ((Input.GetKey(KeyCode.Space)))
        {
            if (jumpable)
            {
                transform.position += Vector3.up;
                jumpable = false;
                //keypress = true;
            }
            transform.position -= Vector3.down;
            jumpable = true;
        }
    }
    void AnimationUpdate()
    {
        animator.SetBool("isMoving", false);
    }*/


