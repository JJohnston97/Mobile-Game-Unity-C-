using UnityEngine;
using System.Collections;

public class Character_Cont : MonoBehaviour
{

	public float moveSpeed = 20.0f; // Player movement speed

	private Rigidbody rb;           // player rigidbody
	private Vector3 moveInput;      // the move input
	private Vector3 moveVelocity;   // how much movement
	private Vector3 dirx;           // x direction

    //private bool gyroEnabled;
    private Gyroscope gyro;         // used for gyro broken


	public GunController theGun;        // the gun object

	void Start()
	{
        
		rb = GetComponent<Rigidbody>();
        //gyroEnabled = EnableGyro();                   // ALL COMMENTED OUT LINES ARE GYRO ATTEMPS
        //gx = Input.gyro.attitude.eulerAngles.x;       // LEFT IN TO SHOW DEVELOPMENT FROM GYRO TO ACC

    }

	void Update()
	{
       /* if (gyroEnabled == true)
        {


         //dirx.x = Input.gyro.attitude.eulerAngles.x - gx * moveSpeed;
         gameObject.transform.Translate(dirx * Time.deltaTime);


        }
        else
        {*/


        //}

		// Check if device has gyro if not run with acc
		// Input.gyro.enabled

        dirx.x = Input.acceleration.x * moveSpeed;                  // Character movement with accelerometer
        gameObject.transform.Translate (dirx * Time.deltaTime);

		moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0f, Input.GetAxisRaw ("Vertical"));   // Input movement 
		moveVelocity = moveInput * moveSpeed;
	}

	void FixedUpdate()
	{
		rb.velocity = moveVelocity;     // Move velocity
	}

    private bool EnableGyro()               // Used to check if gyro works now doesn't
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;


        }

        return false;
    }
}