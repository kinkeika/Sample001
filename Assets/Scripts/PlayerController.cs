using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	enum PlayerState
	{
		Idle = 0,
		Walk,
		Run,
		Attack,
		Skill,
		Die
	}
	private PlayerState pState = PlayerState.Idle;


	//记录鼠标点击的3D坐标点
	private Vector3 point;
	private float time;
	private Animation animation;

	void OnEnable(){
		EasyJoystick.On_JoystickMove += On_JoystickMove;	
		EasyJoystick.On_JoystickMoveEnd += On_JoystickMoveEnd;
		EasyButton.On_ButtonPress += On_ButtonPress;
		EasyButton.On_ButtonUp += On_ButtonUp;	
	}
	
	
	void OnDisable(){
		EasyJoystick.On_JoystickMove -= On_JoystickMove;	
		EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
		EasyButton.On_ButtonPress -= On_ButtonPress;
		EasyButton.On_ButtonUp -= On_ButtonUp;	
	}
	
	void OnDestroy(){
		EasyJoystick.On_JoystickMove -= On_JoystickMove;	
		EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
		EasyButton.On_ButtonPress -= On_ButtonPress;
		EasyButton.On_ButtonUp -= On_ButtonUp;	
	}


	/***** ----------------------------------------------------- ******/

	/**
	 * Occurs when a finger touch the screen hover the joystick
	 */
	void On_JoystickTouchStart(MovingJoystick move)
	{

	}

	/**
	 * Occurs when joystick is starting to move.
	 */
	void On_JoystickMoveStart(MovingJoystick move)
	{

	}

	/**
	 * Occurs when joystick is moving.
	 */
	void On_JoystickMove( MovingJoystick move){
		
		float angle = move.Axis2Angle(true);
		transform.rotation  = Quaternion.Euler( new Vector3(0,angle,0));
//		transform.Translate( Vector3.forward * move.joystickValue.magnitude * Time.deltaTime);	

		SetGameState(PlayerState.Run);
		
	}

	/**
	 * Occurs when joystick is ending to move
	 */
	void On_JoystickMoveEnd (MovingJoystick move)
	{
		//model.animation.CrossFade("idle");
		SetGameState(PlayerState.Idle);
	}

	/*
	 * Occurs when a finger was lifted from the joystick , and the time elapsed since the beginning of 
	 * the touch is less than the time required for the detection of a long tap
	 */
	void On_JoysticTap(MovingJoystick move)
	{

	}

	/**
	 * Occurs when the number of taps is egal to 2 in a short time hover the joystick
	 */
	void On_JoystickDoubleTap(MovingJoystick move)
	{

	}

	/**
	 * Occurs when a finger hover the joystick was lifted from the screen.
	 */
	void On_JoystickTouchUp(MovingJoystick move)
	{

	}



	/***** ----------------------------------------------------- ******/

	void On_ButtonPress (string buttonName)
	{
		if (buttonName == "Fire")
		{
			//Instantiate( bullet, gun.transform.position, gun.rotation);
			SetGameState(PlayerState.Attack);

		}
		else if (buttonName == "Skill")
		{
			SetGameState(PlayerState.Skill);
		}
	}
	
	void On_ButtonUp (string buttonName)
	{
		if (buttonName == "Stop")
		{

		}
	}	



	/***** ----------------------------------------------------- ******/

	// Use this for initialization
	void Start () 
	{
		animation = this.transform.FindChild("Player").GetComponent<Animation>();
		//初始设置人物为站立状态
		SetGameState(PlayerState.Idle);
	}


	// Update is called once per frame
//	void Update () 
//	{
//		//按下鼠标左键后
//		if(Input.GetMouseButtonDown(0))
//		{
//			//从摄像机的原点向鼠标点击的对象身上设法一条射线
//			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//			RaycastHit hit;
//			//当射线彭转到对象时
//			if(Physics.Raycast(ray, out hit))
//			{
//				//目前场景中只有地形
//				//其实应当在判断一下当前射线碰撞到的对象是否为地形。
//
//
//				//得到在3D世界中点击的坐标
//				point = hit.point;
//
//				//设置主角面朝这个点，主角的X 与 Z轴不应当发生旋转，
//				//注解1
//				//transform.LookAt(new Vector3(point.x,transform.position.y,point.z));
//				transform.LookAt(new Vector3(point.x, 0, point.z));
//
//				//用户是否连续点击按钮
//				/*
//				if(Time.realtimeSinceStartup - time <=0.2f)
//				{
//					//连续点击 进入奔跑状态
//					SetGameState(PlayerState.Run);
//				}
//				else
//				{
//					//点击一次只进入走路状态
//					SetGameState(PlayerState.Walk);
//				}
//				*/
//				//连续点击 进入奔跑状态
//				SetGameState(PlayerState.Run);
//
//
//				//记录本地点击鼠标的时间
//				//time = Time.realtimeSinceStartup;
//			}
//		}
//
//	}
//
//	void FixedUpdate()
//	{
//		switch(pState)
//		{
//			case PlayerState.Idle:
//			
//			break;
//			case PlayerState.Walk:
//			//移动主角 一次移动长度为0.05
//			Move(0.05f);
//			break;
//			case PlayerState.Run:
//			//奔跑时移动的长度为0.1
//			Move(0.1f);
//			break;
//		}
//	}


	private void SetGameState(PlayerState _pState)
	{
		switch(_pState)
		{
			case PlayerState.Idle:
			//播放站立动画
			point = transform.position;
			animation.Play("idle");
			break;
			case PlayerState.Walk:
			//播放行走动画
			animation.Play("walk");
			break;
			case PlayerState.Run:
			//播放奔跑动画
			animation.Play("run");
			break;
			case PlayerState.Attack:
			animation.Play("attack3");
			break;
			case PlayerState.Skill:
			animation.Play("attack1");
			break;
		}
		this.pState = _pState;
	}


	private void Move(float speed)
	{
		//注解2
		//主角没到达目标点时，一直向该点移动
		if(Mathf.Abs(Vector3.Distance(point, transform.position)) >= 1.3f)
		{
			//得到角色控制器组件
			CharacterController controller  = GetComponent<CharacterController>();
			//注解3 限制移动
			Vector3 v = Vector3.ClampMagnitude(point -  transform.position, speed);

			//Debug.Log("Vector point::::" + v);

			//可以理解为主角行走或奔跑了一步
			controller.Move(v);
		}
		else
		{
			//到达目标时 继续保持站立状态。
			SetGameState(PlayerState.Idle);
		}
	}


}
