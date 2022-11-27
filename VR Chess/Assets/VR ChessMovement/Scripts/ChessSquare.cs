using UnityEngine;
using System.Collections;

public class ChessSquare : MonoBehaviour {

	// Use this for initialization
	// this it the scrpt that manages the piece movement
	PieceMovement piecemovScript;
	// this is the over material used when focusing on the square
	public Material overMat;
	// the origignal material of the squate
	Material origMat;
	// pointer functions is used to call the pepare to click
	PointerFunctions pointerF;

	void Start ()
	{
		piecemovScript=GameObject.FindGameObjectWithTag("pieceMovement").GetComponent<PieceMovement>();
		pointerF=GetComponent<PointerFunctions>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//this function is trigger on the onOver() trigger event
	public void onOverSquare ()
	{
		origMat=gameObject.GetComponent<Renderer>().material;
		if (piecemovScript.selectedGo != null) {

			// pawn movement is 1 distance forth
			if (piecemovScript.selectedGo.tag == "pawn") 
			{
				//this are the two points that mus be compared
				Vector2 pos1=new Vector2(piecemovScript.selectedGo.transform.position[0],piecemovScript.selectedGo.transform.position[2]);
				Vector2 pos2=new Vector2(gameObject.transform.position[0],gameObject.transform.position[2]);
				Vector2 dist = ( pos2- pos1);

				//Debug.Log("overSquare dist = "+dist[1]);
				//only advance forward
				if (dist.magnitude < 1.05f && dist.magnitude > 0.95f && dist[1]>0)
				{
					gameObject.GetComponent<Renderer>().material=overMat;

					// get loading bar working
					pointerF.onGazeOver();
				}
			}

			// knight movement is L shaped  square(5) distance in any direction
			if (piecemovScript.selectedGo.tag == "knight") 
			{
				//this are the two points that mus be compared
				Vector2 pos1=new Vector2(piecemovScript.selectedGo.transform.position[0],piecemovScript.selectedGo.transform.position[2]);
				Vector2 pos2=new Vector2(gameObject.transform.position[0],gameObject.transform.position[2]);
				Vector2 dist = ( pos2- pos1);

				//Debug.Log("overSquare dist = "+dist[1]);
				//only advance forward
				if (dist.magnitude < Mathf.Sqrt(5)+ 0.01 && dist.magnitude > Mathf.Sqrt(5)- 0.01 )
				{
					gameObject.GetComponent<Renderer>().material=overMat;

					// get loading bar working
					pointerF.onGazeOver();
				}
			}

			// bishop movement is "diagonal" shaped in any direction
			if (piecemovScript.selectedGo.tag == "bishop") 
			{
				//this are the two points that mus be compared
				Vector2 pos1=new Vector2(piecemovScript.selectedGo.transform.position[0],piecemovScript.selectedGo.transform.position[2]);
				Vector2 pos2=new Vector2(gameObject.transform.position[0],gameObject.transform.position[2]);
				Vector2 dist = ( pos2- pos1);

				// diagonal means that the two components of the vector must be the same
				if ( Mathf.Abs(dist[1]-dist[0])<0.01f ||  Mathf.Abs(dist[1]+dist[0])<0.01f)
				{
					gameObject.GetComponent<Renderer>().material=overMat;

					// get loading bar working
					pointerF.onGazeOver();
				}
			}


			// tower movement is "linear" shaped in any direction
			if (piecemovScript.selectedGo.tag == "tower") 
			{
				//this are the two points that mus be compared
				Vector2 pos1=new Vector2(piecemovScript.selectedGo.transform.position[0],piecemovScript.selectedGo.transform.position[2]);
				Vector2 pos2=new Vector2(gameObject.transform.position[0],gameObject.transform.position[2]);
				Vector2 dist = ( pos2- pos1);

				//Debug.Log("overSquare dist = "+dist[1]);
				//only advance in linear wat (one component is equal to zero)
				if (Mathf.Abs(dist[1])<0.01f ||  Mathf.Abs(dist[0])<0.01f)
				{
					gameObject.GetComponent<Renderer>().material=overMat;

					// get loading bar working
					pointerF.onGazeOver();
				}
			}


			// king movement is "linear and diagonar" shaped in any direction only 1 square
			if (piecemovScript.selectedGo.tag == "king") 
			{
				//this are the two points that mus be compared
				Vector2 pos1=new Vector2(piecemovScript.selectedGo.transform.position[0],piecemovScript.selectedGo.transform.position[2]);
				Vector2 pos2=new Vector2(gameObject.transform.position[0],gameObject.transform.position[2]);
				Vector2 dist = ( pos2- pos1);

				//Debug.Log("overSquare dist = "+dist[1]);
				//only advance forward
				if (   dist.magnitude > 1- 0.01 && dist.magnitude < 1 + 0.01
					|| dist.magnitude > Mathf.Sqrt(2)- 0.01 && dist.magnitude < Mathf.Sqrt(2) + 0.01
					)
				{
					gameObject.GetComponent<Renderer>().material=overMat;

					// get loading bar working
					pointerF.onGazeOver();
				}
			}

			// queen movement is "diagonal and linear" shaped in any direction and any number of squares (max 8)
			if (piecemovScript.selectedGo.tag == "queen") 
			{
				//this are the two points that mus be compared
				Vector2 pos1=new Vector2(piecemovScript.selectedGo.transform.position[0],piecemovScript.selectedGo.transform.position[2]);
				Vector2 pos2=new Vector2(gameObject.transform.position[0],gameObject.transform.position[2]);
				Vector2 dist = ( pos2- pos1);

				//Debug.Log("overSquare dist = "+dist[1]);
				//only advance forward
				if ( Mathf.Abs(dist[1])<0.01f ||  Mathf.Abs(dist[0])<0.01f 
					|| Mathf.Abs(dist[1]-dist[0])<0.01f ||  Mathf.Abs(dist[1]+dist[0])<0.01f
					)
				{
					gameObject.GetComponent<Renderer>().material=overMat;

					// get loading bar working
					pointerF.onGazeOver();
				}
			}
		}
	}






	//*****************
	// similar structure that the on over, but with call to the movement function in this case
	//*******************
	public void onClickSquare ()
	{
		if (piecemovScript.selectedGo != null) {

			// pawn movement is 1 distance forth
			if (piecemovScript.selectedGo.tag == "pawn") 
			{
				Vector2 pos1=new Vector2(piecemovScript.selectedGo.transform.position[0],piecemovScript.selectedGo.transform.position[2]);
				Vector2 pos2=new Vector2(gameObject.transform.position[0],gameObject.transform.position[2]);
				Vector2 dist = ( pos2- pos1);

				//Debug.Log("overSquare dist = "+dist);
				//only advance forward
				if (dist.magnitude < 1.05f && dist.magnitude > 0.95f && dist[1]>0)
				{
					//Debug.Log("call movement");
					piecemovScript.movePiece(gameObject);
				}
			}


			// knight movement is L shaped  square(5) distance in any direction
			if (piecemovScript.selectedGo.tag == "knight") 
			{
				//this are the two points that mus be compared
				Vector2 pos1=new Vector2(piecemovScript.selectedGo.transform.position[0],piecemovScript.selectedGo.transform.position[2]);
				Vector2 pos2=new Vector2(gameObject.transform.position[0],gameObject.transform.position[2]);
				Vector2 dist = ( pos2- pos1);

				//Debug.Log("overSquare dist = "+dist[1]);
				//only advance forward
				if (dist.magnitude < Mathf.Sqrt(5)+ 0.01 && dist.magnitude > Mathf.Sqrt(5)- 0.01 )
				{
					piecemovScript.movePiece(gameObject);
				}
			}

			// bishop movement is "diagonal" shaped in any direction
			if (piecemovScript.selectedGo.tag == "bishop") 
			{
				//this are the two points that mus be compared
				Vector2 pos1=new Vector2(piecemovScript.selectedGo.transform.position[0],piecemovScript.selectedGo.transform.position[2]);
				Vector2 pos2=new Vector2(gameObject.transform.position[0],gameObject.transform.position[2]);
				Vector2 dist = ( pos2- pos1);

				//Debug.Log("overSquare dist = "+dist[1]);
				//only advance forward
				if ( Mathf.Abs(dist[1]-dist[0])<0.01f ||  Mathf.Abs(dist[1]+dist[0])<0.01f)
				{
					piecemovScript.movePiece(gameObject);
				}
			}


			// tower movement is "linear" shaped in any direction
			if (piecemovScript.selectedGo.tag == "tower") 
			{
				//this are the two points that mus be compared
				Vector2 pos1=new Vector2(piecemovScript.selectedGo.transform.position[0],piecemovScript.selectedGo.transform.position[2]);
				Vector2 pos2=new Vector2(gameObject.transform.position[0],gameObject.transform.position[2]);
				Vector2 dist = ( pos2- pos1);

				//Debug.Log("overSquare dist = "+dist[1]);
				//only advance in linear wat (one component is equal to zero)
				if (Mathf.Abs(dist[1])<0.01f ||  Mathf.Abs(dist[0])<0.01f )
				{
					piecemovScript.movePiece(gameObject);
				}
			}


			// king movement is "linear and diagonar" shaped in any direction only 1 square
			if (piecemovScript.selectedGo.tag == "king") 
			{
				//this are the two points that mus be compared
				Vector2 pos1=new Vector2(piecemovScript.selectedGo.transform.position[0],piecemovScript.selectedGo.transform.position[2]);
				Vector2 pos2=new Vector2(gameObject.transform.position[0],gameObject.transform.position[2]);
				Vector2 dist = ( pos2- pos1);

				//Debug.Log("overSquare dist = "+dist[1]);
				//only advance forward
				if (   dist.magnitude > 1- 0.01 && dist.magnitude < 1 + 0.01
					|| dist.magnitude > Mathf.Sqrt(2)- 0.01 && dist.magnitude < Mathf.Sqrt(2) + 0.01
					)
				{
					piecemovScript.movePiece(gameObject);
				}
			}


			// queen movement is "diagonal and linear" shaped in any direction and any number of squares (max 8)
			if (piecemovScript.selectedGo.tag == "queen") 
			{
				//this are the two points that mus be compared
				Vector2 pos1=new Vector2(piecemovScript.selectedGo.transform.position[0],piecemovScript.selectedGo.transform.position[2]);
				Vector2 pos2=new Vector2(gameObject.transform.position[0],gameObject.transform.position[2]);
				Vector2 dist = ( pos2- pos1);

				//Debug.Log("overSquare dist = "+dist[1]);
				// it advances like a bishop + tower
				if (Mathf.Abs(dist[1])<0.01f ||  Mathf.Abs(dist[0])<0.01f 
					|| Mathf.Abs(dist[1]-dist[0])<0.01f ||  Mathf.Abs(dist[1]+dist[0])<0.01f
					)
				{
					piecemovScript.movePiece(gameObject);
				}
			}
		}
	}

	public void onExitSquare ()
	{
		gameObject.GetComponent<Renderer> ().material = origMat;
	}
}
