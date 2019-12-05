using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Movement
	public float MoveSpeed = 3.0f;

	// Gravity
	public float Gravity = -3.0f;
	
	// Jump
	public float Jump = 5.0f;
	
	// View
	public Camera Cam;
	public float LookSpeed = 400.0f;
	public float MaxYRotation = 40.0f;
	private Quaternion _originalCamRotation;
	private Vector3 _velocity;
	
	private CharacterController _cc;

    public Animator MyAnimator;

	protected virtual void Awake()
	{
		_cc = GetComponent<CharacterController>();
		_originalCamRotation = Cam.transform.localRotation;
	}
	
	protected virtual void FixedUpdate()
	{
		// Movement
		var x = Input.GetAxis("Horizontal") * MoveSpeed;
		var z = Input.GetAxis("Vertical") * MoveSpeed;
		var move = new Vector3(x, 0, z);

		move = transform.TransformDirection(move);
		_velocity.x = move.x;
		_velocity.z = move.z;

		// Gravity
		if (!_cc.isGrounded)
		{
			var gravity = Vector3.up * Gravity;
			_velocity += gravity;
		}
		
		// Jump
		if (_cc.isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			var jump = Vector3.up * Jump;
			_velocity.y = jump.y;
		}
		
		_cc.Move(_velocity);
        MyAnimator.SetFloat("Z", z);

		// Rotate view up/down
		var lookY = Input.GetAxis("Mouse Y") * LookSpeed;
		var newRotation = Cam.transform.localRotation * Quaternion.AngleAxis(-lookY, Vector3.right);;
		if (Mathf.Abs(Quaternion.Angle(_originalCamRotation, newRotation)) < MaxYRotation)
		{
			Cam.transform.Rotate(-lookY, 0, 0);
		}
		
		// Rotate view right/left
		var lookX = Input.GetAxis("Mouse X") * LookSpeed;
		transform.Rotate(0, lookX, 0);
	}
}