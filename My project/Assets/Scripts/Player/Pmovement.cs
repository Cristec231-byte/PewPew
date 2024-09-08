using UnityEngine;
public class Pmovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundlayer;
    private Rigidbody2D body;
    private Animator anim;
    //private bool grounded;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
    
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal")* speed, body.velocity.y);

        //Flip player when moving left
        if(horizontalInput  > 0.01f)
        transform.localScale = Vector3.one*10;
        else if(horizontalInput < -0.01f)
        transform.localScale =  new Vector3(-10, 10, 10);

        if(Input.GetKey(KeyCode.Space))
        Jump();

        //Set animator parameter
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
    }

    private void Jump()
    {
        if(isGrounded())
        {
        body.velocity = new Vector2(body.velocity.x, speed);
         anim.SetTrigger("jump");
        }
        
         //grounded = false;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        grounded = true;
    }*/

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0,Vector2.down,0.1f,groundlayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
      return horizontalInput == 0 && isGrounded();
    }
}
