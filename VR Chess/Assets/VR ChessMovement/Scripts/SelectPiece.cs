using UnityEngine;
using System.Collections;

public class SelectPiece : MonoBehaviour {

	// Use this for initialization
	// the renderer is changed to give the selection sensation
	public Renderer groundRend;
	// this it the scrpt that manages the piece movement
	PieceMovement piecemovScript;
	void Start ()
	{
		piecemovScript=GameObject.FindGameObjectWithTag("pieceMovement").GetComponent<PieceMovement>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// these are the actions performed by trigge calls that simulate the over effect for selection
	public void onPieceOver ()
	{
		//Debug.Log("over	");	
		groundRend.transform.rotation=Quaternion.Euler(90,0,0);
		groundRend.enabled=true;
	}
	public void onPieceExit ()
	{
		if (piecemovScript.selectedGo != gameObject) 
		{
			groundRend.enabled=false;
		}


	}

	//this is the function that allows piece selection
	public void onPieceClick ()
	{
		// set lastest piece render to false (unselect) only of there is one selected and is not the same as clicked
		if (piecemovScript.selectedGo != null && piecemovScript.selectedGo != gameObject) {
			piecemovScript.selectedGo.transform.GetChild (0).GetComponent<Renderer> ().enabled = false;
		}
		piecemovScript.selectedGo=transform.gameObject;
		// set position as this one:
		piecemovScript.lastPosition=transform.position;
	}


	// this part of the code detects collision betweem pieces
	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag != "Untagged") {
			Debug.Log ("Collision Has occur");
			piecemovScript.thereIsCollision = true;
		}

	}
}
