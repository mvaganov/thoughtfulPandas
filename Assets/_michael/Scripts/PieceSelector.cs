using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSelector : MonoBehaviour
{
	public GameObject visualizer;
	Camera cam;

	public Board board;

	public Piece selected;

	public Vector3Int selectedTile;

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
			if(board != null)
			{
				selectedTile = board.ConvertWorldPositionToBoardPosition(hitLocation);
			}
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
			selectedTile = board.ConvertWorldPositionToBoardPosition(hitLocation);
		}
		return null;
	}

	void TestPosition()
	{
		Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit whatTheMouseIsHitting = new RaycastHit();
		bool hitSomething = Physics.Raycast(mouseRay, out whatTheMouseIsHitting);
		if (hitSomething)
		{
			selectedTile = board.ConvertWorldPositionToBoardPosition(whatTheMouseIsHitting.point);
		}
		if(board != null)
		{
			board.SetSparkleTile(selectedTile);
		}
	}

	public void SetAllRenderersColors(Transform t, Color[] colorToAssign, out Color[] oldColorsFound)
	{
		Renderer[] renderers = t.GetComponentsInChildren<Renderer>();
		oldColorsFound = new Color[renderers.Length];
		for (int i = 0; i < renderers.Length; ++i) {
			oldColorsFound[i] = renderers[i].material.color;
			renderers[i].material.color = colorToAssign[i % colorToAssign.Length];
		}
	}

	private Color[] oldColors;
	void Update()
    {
		if (Input.GetMouseButtonDown(0)) // testing if the left mouse button was pressed this frame
		{
			Vector3 spot;
			Piece p = GetPieceAtMouse(out spot);
			if(selected == null && p != null) {
				selected = p;
				SetAllRenderersColors(p.transform, new Color[] { Color.yellow }, out oldColors);
			} else if (selected != null) {
				selected.transform.position = spot;
				SetAllRenderersColors(selected.transform, oldColors, out _); // set the colors back
				selected = null;
			}
		} else if (Input.GetMouseButton(0)) // tests if the left mouse button is being held
		{
			TestPosition();
		}
    }
}
