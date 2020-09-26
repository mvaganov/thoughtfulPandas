using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
	public GameObject prefab_redSquare, prefab_blackSquare;
	public GameObject prefab_redToken, prefab_blackToken;

	public GameObject[][] boardtiles;

	int height = 8, width = 8;

	// checkers board game with elevators <-- one line design
	// 
	// peices
	//	that move
	//		user can select them with a click
	//		user can click on a valid square to make it move
	//			the game marks valid squares with a particle effect when the peice is selected
	//			are bound to the grid
	//			can't move on non-black square
	//			can only move 'forward' (toward the opponent's side)
	//			if there's an enemy peice in the way of a valid move, and an empty space after
	//				the enemy can me 'jumped' and captured
	//			once the piece reaches the opponents side
	//				X (NOPE) that piece becomes 'kinged', and can move backward
	//				(twist) an elevator travels to the peice to take it up to the next level where another game of checkers happens
	//			game goes until there are no valid moves. person with the most moving pieces wins
	//	8 peices for each of the 2 teams, red and black
	//		r r r r
	//		 r r r r
	//		. . . . 
	//       . . . .
	//      . . . .
	//       . . . .
	//		b b b b
	//		 b b b b
	//	
	//	peices - 3d models?
	//	peice selection code - a script that turns mouse raycast into determining if a piece is selected
	//	function that can tell what piece is at what square
	//	a list of all the open squares
	//	function that determines what squares are open for a piece to move to
	//	elevator
	//		model
	//		logic - how can we tell if the elevator is in use?
	//	game piece script
	//		keep track of col (x)/height (y)/row (z), color, is it a king or not
	//		is the peice selected
	//	game board script
	//		keeps track of the empty squares
	//		what peice is where

	public void GenerateBoard()
	{
		boardtiles = new GameObject[height][];
		for(int row = 0; row < height; ++row)
		{
			boardtiles[row] = new GameObject[width];
			for(int col = 0; col < width; ++col)
			{
				GameObject srcTile = ((col + row) % 2 == 0) ? prefab_redSquare : prefab_blackSquare;
				GameObject tile = Instantiate(srcTile);
				tile.transform.SetParent(transform);
				tile.transform.localPosition = new Vector3(col, 0, row);
			}
		}
	}

    void Start()
    {
		GenerateBoard();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
