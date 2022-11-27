using UnityEngine;
using System.Collections;

public class PointerFunctions : MonoBehaviour {

	// Use this for initialization

	//this is the circle trigger with the loading effect bar:
	CircleTrigger loadingScript;

	void Start () 
	{
		loadingScript=GameObject.FindGameObjectWithTag("HUD").GetComponent<CircleTrigger>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// this is the function that will be called when trigger event "over" occurs
	public void onGazeOver()
	{
		loadingScript.prepareToClick(gameObject);
	}

	// this is the function that will be called when trigger event "exit" occurs
	public void onGazeExit()
	{
		loadingScript.cancelLoading();
	}
}
