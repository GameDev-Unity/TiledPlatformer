using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    public float Speed;
    public float JumpSpeed;
    public bool onLadder;
    public bool onRope;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (onRope || onLadder)
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
        else
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
        }

        transform.position += new Vector3(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpSpeed*100));

        } 
        if (onRope || onLadder)
        {
            transform.position += new Vector3(0, Input.GetAxis("Vertical") * Speed * Time.deltaTime, 0);
        }

	}
}
