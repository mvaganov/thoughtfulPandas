using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSelector : MonoBehaviour
{
	public GameObject visualizer;
	Camera cam;

	public Piece selected;

    void Start()
    {
		cam = GetComponent<Camera>();
    }

	public Piece GetPieceAtMouse(out Vector3 hitLocation)
	{
		Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit whatTheMouseIsHitting = new RaycastHit();
		bool hitSomething = Physics.Raycast(mouseRay, out whatTheMouseIsHitting);
		if (hitSomething)
		{
			visualizer.transform.position = whatTheMouseIsHitting.point;
			hitLocation = whatTheMouseIsHitting.point;
			if (whatTheMouseIsHitting.collider != null)
			{
				Piece p = whatTheMouseIsHitting.collider.transform.parent.GetComponent<Piece>();
				if (p != null)
				{
					return p;
				}
			}
		} else {
			hitLocation = Vector3.zero;
		}
		return null;
	}

	void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 spot;
			Piece p = GetPieceAtMouse(out spot);
			if(selected == null)
			{
				selected = p;
			} else {
				selected.transform.position = spot;
				selected = null;
			}
		}
    }
}
