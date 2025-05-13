using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public bool isAlive = true;
    public float runSpeed;
    public float HorizontalSpeed; 
    public Rigidbody rb;
    float Horizontalinput;

    [SerializeField] private float jumpforce = 100; // 350
    [SerializeField] private LayerMask GroundMask;

    // for dashing 
    [SerializeField] private float dashForce = 10f;
    [SerializeField] private float dashCooldown = 1f;
    private int dashCount = 0;
    private float lastDashTime = -999f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if(isAlive){
            Vector3 forwardMovement = transform.forward * runSpeed * Time.fixedDeltaTime;
            Vector3 horizaontalMovement = transform.right * Horizontalinput *HorizontalSpeed* Time.fixedDeltaTime;
            rb.MovePosition(rb.position + forwardMovement +  horizaontalMovement);
        }
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Horizontalinput = Input.GetAxis("Horizontal");

        float playerHieght = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position,Vector3.down,(playerHieght / 2) + 0.1f,GroundMask);
        if(Input.GetKeyDown(KeyCode.Space) && isAlive && isGrounded){
            Jump();
            dashCount = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCount < 2 && Time.time > lastDashTime + dashCooldown)
        {
        Dash();
        }
        runSpeed = 20f + GameManager.myInstance.Score * 0.2f;
    }

    public void Jump (){
        rb.AddForce(Vector3.up* jumpforce);
    }
// for dash 
 IEnumerator DashRoutine()
{
    float originalGravity = rb.useGravity ? 1 : 0;
    rb.useGravity = false; // disable gravity for clean dash
    rb.linearVelocity = transform.forward * dashForce;

    yield return new WaitForSeconds(0.2f); // dash lasts 0.2 seconds

    rb.linearVelocity = Vector3.zero;
    rb.useGravity = originalGravity == 1;
}
    void Dash()
{
    rb.linearVelocity = transform.forward * dashForce;
    dashCount++;
    lastDashTime = Time.time;
}
    void OnCollisionEnter(Collision collision)
    {
        // if(collision.gameObject.name == "Graphic"){
        //     Dead();
        // }
        if(collision.gameObject.name == "Coin (Clone)"){
            Destroy(collision.gameObject);
            GameManager.myInstance.Score++;
        }
        if(collision.gameObject.CompareTag("obj")){
            Dead();
        }
    }

    public void Dead(){
        isAlive= false;
        GameManager.myInstance.GameoverPanel.SetActive(true);
    }
}
