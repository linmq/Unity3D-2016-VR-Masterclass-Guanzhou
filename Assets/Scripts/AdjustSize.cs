using UnityEngine;
using System.Collections;

public class AdjustSize : MonoBehaviour
{
	public GameObject cam;
	public float basicDis;   //-400
	public float farestDis;  //210
	RaycastHit rayHit;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out rayHit, 300f)) {
			transform.localPosition = new Vector3 (0, 0, basicDis + rayHit.distance * 8);
		} else
			transform.localPosition = new Vector3 (0, 0, farestDis);
	}
    /*
	void OnGUI()
	{
		GUI.Label (new Rect (20, 20, 500, 50), rayHit.distance.ToString ());
	}
    */
}
