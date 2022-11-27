using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CircleTrigger : MonoBehaviour
{
    
	// these are the color propierties of the loading bar
    public Color start;
    public Color end;
    public Color current;
	float speed;



    // these are the values of the filling amount that are displayed for the developper
	public Image[] CircleImage;
	public float initialValue;
	public float endValue;
	public float value;
	public float elapsed;

	//this is the selected gameobject, in case actions have to be performed
	public GameObject selectedGameobject;
	public PointerEventData pointer;
	public PointerEventData lookData;
	private bool _guiRaycastHit;

	//this is the final time it takes to the loading bar to complete
	public float FinalTime;


    void Start ()
	{
		//set the loading bar characteristics
		for (int i = 0; i < 2; i++) {
			CircleImage[i].type = Image.Type.Filled;
			CircleImage[i].fillMethod = Image.FillMethod.Radial360;
			CircleImage[i].fillOrigin = 0;
		}
		// get the filling speed and set the evolutionary time variables
		speed=1/FinalTime;



    }


    

    // this part prepares the loading efffect 
	public void prepareToClick(GameObject go)
    {
		Debug.Log ("preparing click on: " + go.name);
		selectedGameobject = go;

		//call the corrutines that simulate the loading bar effect
		StopAllCoroutines ();
		StartCoroutine (Corr_loadingBar ());
	}

  
 
	// cancel loading
	public void cancelLoading ()
	{
		StopAllCoroutines ();
		for (int i = 0; i < 2; i++) {
			CircleImage [i].fillAmount = 0;
		}
	}




	// ************* CORRUTINES***********
	// corrutine for loading the bar
	// ***********************************
	IEnumerator Corr_loadingBar ()
	{

		value = initialValue;
		elapsed = 0;

		while (value <= endValue) {
			
			elapsed += Time.fixedDeltaTime;

			value = elapsed * speed;
			current = Color.Lerp (start, end, value + 0.001f);

			for (int i = 0; i < 2; i++) {
				CircleImage [i].fillAmount = value;

				//set colors
				CircleImage[i].color = (Color)current;
			}
			yield return new WaitForEndOfFrame();
		}

		/// *********** this is the space to perform actions or call functions*************** ////
		// pointer enter data is called
		newPointerSubmitData();		
		cancelLoading();			
	}




	// this is used to submit the actions inside the gameobject (for example, change the color of the render)
	void newPointerSubmitData()
	{
		pointer = new PointerEventData(EventSystem.current);
		ExecuteEvents.Execute(selectedGameobject, pointer, ExecuteEvents.submitHandler);
	}
     
}
