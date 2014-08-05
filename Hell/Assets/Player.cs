using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public int moveSpeed;
	public LayerMask whatIsGround;
	public float groundCheckRadius;
	public int jumpForce;
	bool grounded;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		//rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rigidbody2D.velocity.y);
		rigidbody2D.AddForce(Vector2.right * Input.GetAxis("Horizontal") * moveSpeed);
		grounded = false;
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("GroundCheck"))
		if (Physics2D.OverlapCircle(go.transform.position, groundCheckRadius, whatIsGround) != null)
			grounded = true;
		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			rigidbody2D.AddForce(Vector2.up * jumpForce);
		}
	}
}
