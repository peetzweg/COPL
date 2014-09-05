using UnityEngine;
using System.Collections;

public class CreditText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioClip[] soundtrack = Resources.LoadAll<AudioClip>("Soundtrack");

		string creditText ="Soundtrack:\n";
		foreach (AudioClip track in soundtrack){
			creditText +="\t"+ track.name + "\n";	
		}

		creditText += "\nCheck out their other stuff, it's awesome too!";
		this.guiText.text = creditText;
	}

}
