using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	public Transform[] backgrounds; //Array of all the back and foregrounds to be parallaxed
	private float[] parallaxScales;  //The proportion of the camera's movement you move the background by
	public float smoothing = 1f; //How smooth the parallax is going to be. (Must be above 0)

	private Transform cam; //Reference to the main cameras transform
	private Vector3 previousCamPos; //Position of the camera in the previous frame

	//Is called before Start(). Great for references.
	void Awake(){
		//Set up the cam reference
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		//The previous frame had the current frame's camera position
		previousCamPos = cam.position;

		// assigning coresponding parallaxScales
		parallaxScales = new float[backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z*-1;
		}
	}
	
	// Update is called once per frame
	void Update () {

		//for each background
		for (int i = 0; i < backgrounds.Length; i++) {
			//the parallax is the opposite of the camera movement 
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			//set a target x position which is the current position plus the parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			//create a target positon which is the background's current position with it's target x position
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			//fade between current position and the target position using lerp
			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}

		//set the previous cam position to the cam position at the end of the frame
		previousCamPos = cam.position;
	}
}
