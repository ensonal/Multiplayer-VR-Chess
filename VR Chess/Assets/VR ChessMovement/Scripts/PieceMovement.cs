using UnityEngine;
using System.Collections;

public class PieceMovement : MonoBehaviour {

	// Use this for initialization
	// this is the piece that is selected
	public GameObject selectedGo;
	public int timeToMove=2;

	//these variables are used to un-do the movement in case of a collision between pieces
	public bool thereIsCollision=false;
	public Vector3 lastPosition;

	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void movePiece (GameObject groundPoint)
	{
		Debug.Log("move piece");
		StartCoroutine( moveToObjective(groundPoint.transform.position));
					
	}

	IEnumerator moveToObjective (Vector3 position)
	{
		float elapsed = 0;
		position += new Vector3 (0, 0.5f, 0);

		// linear movement
		while (elapsed <= timeToMove && thereIsCollision == false) 
		{
			selectedGo.transform.position = (position - selectedGo.transform.position) * elapsed / timeToMove + selectedGo.transform.position;
			elapsed += Time.fixedDeltaTime;

			yield return new WaitForFixedUpdate ();
		}

		if (thereIsCollision == true) 
		{
			elapsed = 0;
			while (elapsed <= timeToMove) 
			{
				selectedGo.transform.position = (lastPosition - selectedGo.transform.position) * elapsed / timeToMove + selectedGo.transform.position;
				elapsed += Time.fixedDeltaTime;

				yield return new WaitForFixedUpdate ();
			}
			// deactivate the piece
			selectedGo.transform.GetChild (0).GetComponent<Renderer> ().enabled = false;
			selectedGo.transform.position = lastPosition;
			selectedGo = null;
			thereIsCollision=false;

		}
		 else 
		 {
			

			// deactivate the piece
			selectedGo.transform.GetChild (0).GetComponent<Renderer> ().enabled = false;
			selectedGo.transform.position = position;
			selectedGo = null;
		}


			
		
	
	}
}
