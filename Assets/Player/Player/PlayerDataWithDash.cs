using UnityEngine;

[CreateAssetMenu(menuName = "Player Data With Dash")] 
public class PlayerDataWithDash : ScriptableObject
{
	[Header("Gravity")]
	[HideInInspector] public float gravityStrength;
	[HideInInspector] public float gravityScale; 

	[Space(5)]
	public float fallGravityMult;
	public float maxFallSpeed; 
	[Space(5)]
	public float fastFallGravityMult; 
									  
	public float maxFastFallSpeed; 
	
	[Space(20)]

	[Header("Run")]
	public float runMaxSpeed;
	public float runAcceleration; 
	[HideInInspector] public float runAccelAmount; 
	public float runDecceleration;
	[HideInInspector] public float runDeccelAmount; 
	[Space(5)]
	[Range(0f, 1)] public float accelInAir;
	[Range(0f, 1)] public float deccelInAir;
	[Range(0f, 1)] public float accelInDash;
	[Range(0f, 1)] public float deccelInDash;
	[Space(5)]
	public bool doConserveMomentum = true;

	[Space(20)]

	[Header("Jump")]
	public float jumpHeight;
	public float jumpTimeToApex; 
	[HideInInspector] public float jumpForce;

	[Header("Both Jumps")]
	public float jumpCutGravityMult; 
	[Range(0f, 1)] public float jumpHangGravityMult;
	public float jumpHangTimeThreshold;  
	[Space(0.5f)]
	public float jumpHangAccelerationMult; 
	public float jumpHangMaxSpeedMult; 				

	[Header("Wall Jump")]
	public Vector2 wallJumpForce; 
	[Space(5)]
	[Range(0f, 1f)] public float wallJumpRunLerp;
	[Range(0f, 1.5f)] public float wallJumpTime; 
	public bool doTurnOnWallJump; 

	[Space(20)]

	[Header("Slide")]
	public float slideSpeed;
	public float slideAccel;

    [Header("Assists")]
	[Range(0.01f, 0.5f)] public float coyoteTime; //Grace period after falling off a platform, where you can still jump
	[Range(0.01f, 0.5f)] public float jumpInputBufferTime; //Grace period after pressing jump where a jump will be automatically performed once the requirements (eg. being grounded) are met.

	[Space(20)]

	[Header("Dash")]
	public int dashAmount;
	public float dashSpeed;
	public float dashSleepTime; //Duration for which the game freezes when we press dash but before we read directional input and apply a force
	[Space(5)]
	public float dashAttackTime;
	[Space(5)]
	public float dashEndTime; //Time after you finish the inital drag phase, smoothing the transition back to idle (or any standard state)
	public Vector2 dashEndSpeed; //Slows down player, makes dash feel more responsive (used in Celeste)
	[Range(0f, 1f)] public float dashEndRunLerp; //Slows the affect of player movement while dashing
	[Space(5)]
	public float dashRefillTime;
	[Space(5)]
	[Range(0.01f, 0.5f)] public float dashInputBufferTime;
	

	//Unity Callback, called when the inspector updates
    private void OnValidate()
    {
		//Calculate gravity strength using the formula (gravity = 2 * jumpHeight / timeToJumpApex^2) 
		gravityStrength = -(2 * jumpHeight) / (jumpTimeToApex * jumpTimeToApex);
		
		//Calculate the rigidbody's gravity scale (ie: gravity strength relative to unity's gravity value, see project settings/Physics2D)
		gravityScale = gravityStrength / Physics2D.gravity.y;

		//Calculate are run acceleration & deceleration forces using formula: amount = ((1 / Time.fixedDeltaTime) * acceleration) / runMaxSpeed
		runAccelAmount = (50 * runAcceleration) / runMaxSpeed;
		runDeccelAmount = (50 * runDecceleration) / runMaxSpeed;

		//Calculate jumpForce using the formula (initialJumpVelocity = gravity * timeToJumpApex)
		jumpForce = Mathf.Abs(gravityStrength) * jumpTimeToApex;

		#region Variable Ranges
		runAcceleration = Mathf.Clamp(runAcceleration, 0.01f, runMaxSpeed);
		runDecceleration = Mathf.Clamp(runDecceleration, 0.01f, runMaxSpeed);
		#endregion
	}
}
