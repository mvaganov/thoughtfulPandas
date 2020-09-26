using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSelector : MonoBehaviour
{
	public GameObject visualizer;
	Camera cam;

    void Start()
    {
		cam = GetComponent<Camera>();
    }

    void Update()
    {
		Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit whatTheMouseIsHitting = new RaycastHit();
		bool hitSomething = Physics.Raycast(mouseRay, out whatTheMouseIsHitting);
		if (hitSomething)
		{
			visualizer.transform.position = whatTheMouseIsHitting.point;
		}
    }
}
