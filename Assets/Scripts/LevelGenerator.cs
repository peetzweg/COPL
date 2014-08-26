using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour
{

		public GameObject housePrefab;
		public int numberOfObjects = 50;
		public float maxHouseLength = 32f;
		public float minHouseLength = 16;
		public float maxGapLength = 8f;
		public float minGapLength = 2f;



		// Use this for initialization
		void Start ()
		{

				// start ramp
				float lengthOfStartRamp = 100f;
				GameObject startRamp = Instantiate (housePrefab, new Vector3 (0, -4.8f, -0.1f), Quaternion.identity) as GameObject;
				startRamp.transform.localScale = new Vector3 (lengthOfStartRamp, 4f, 0);

				float totalLength = lengthOfStartRamp / 2;
				for (int i = 0; i < numberOfObjects; i++) {
						//Vector3 pos = new Vector3 (Mathf.Cos (angle), 0, Mathf.Sin (angle)) * radius;


						float houseLength = Random.Range (this.minHouseLength, this.maxHouseLength);
						float gapLength = Random.Range (this.minGapLength, this.maxGapLength);
						float xPosition = totalLength + gapLength + (houseLength / 2);
						totalLength += houseLength + gapLength;
						GameObject house = Instantiate (housePrefab, new Vector3 (xPosition, -4.8f, -0.1f), Quaternion.identity) as GameObject;
						house.transform.localScale = new Vector3 (houseLength, 4f, 0);
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
