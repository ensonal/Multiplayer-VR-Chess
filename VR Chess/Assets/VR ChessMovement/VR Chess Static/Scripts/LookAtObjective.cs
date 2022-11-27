using UnityEngine;
using System.Collections;

public class LookAtObjective : MonoBehaviour {

	// this will be the objective, the object is going to look towards to
	public Transform Objective;
	//this is to stop rotations in the given axis
	public bool Vertical,Zeta;
    // Use this for initialization

    private void Start()
    {
        Objective =GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate () 
	{
		transform.LookAt(2*transform.position-Objective.position);

		if(Vertical)
		{
			transform.rotation=Quaternion.Euler(0,transform.rotation.eulerAngles[1],0);
		}


	}
	

}
