using UnityEngine;
using System.Collections;

public class piece : MonoBehaviour {


	public int[] values;
	public float speed;
	float realRotation;


	public GameManager gm;


	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	

		if (transform.root.eulerAngles.z != realRotation) {
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0, 0, realRotation), speed);
		}

	}



	void OnMouseDown()
	{

		int difference = -gm.QuickSweep((int)transform.position.x,(int)transform.position.y);



		RotatePiece ();


		difference += gm.QuickSweep((int)transform.position.x,(int)transform.position.y);




		gm.puzzle.curValue += difference;



		if (gm.puzzle.curValue == gm.puzzle.winValue)
			gm.Win ();


		
	}

	public void RotatePiece()
	{
		realRotation += 90;

		if (realRotation == 360)
			realRotation = 0;

		RotateValues ();
	}



	public void RotateValues()
	{

		int aux = values [0];

		for (int i = 0; i < values.Length-1; i++) {
			values [i] = values [i + 1];
		}
		values [3] = aux;
	}



}
