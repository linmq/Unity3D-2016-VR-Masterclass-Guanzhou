using UnityEngine;
using System.Collections;

public class GUIDepth : MonoBehaviour
{
	public GameObject crosshairs;
	private RectTransform rt;
	// Use this for initialization
	void Start ()
	{
		rt = crosshairs.GetComponent<RectTransform>();
	}

	// Update is called once per frame
	void Update ()
	{
		Ray ray = GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			print("I'm looking at " + hit.transform.name + " And its Z is " + hit.transform.position.z);
			rt.transform.position = new Vector3(rt.transform.position.x, rt.transform.position.y, hit.transform.position.z);
		}

		else
			print("I'm looking at nothing!");
	}
}