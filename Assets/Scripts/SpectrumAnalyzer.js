#pragma strict

public var amp : float = 2f;


function Start () {

}

function Update () {
	var spectrum : float[] = AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);

	/*
	c1 = 64hz
	c3 = 256hz
	c4 = 512hz
	c5 = 1024
	*/
	
	var c1 : float = (spectrum[3] + spectrum[2] + spectrum[4])*amp;
	var c3 : float = (spectrum[11] + spectrum[12] + spectrum[13])*amp;
	var c4 : float = (spectrum[22] + spectrum[23] + spectrum[24])*amp;
	var c5 : float = (spectrum[44] + spectrum[45] + spectrum[46] + spectrum[47] + spectrum[48] + spectrum[49])*amp;

	var cubes : GameObject[] = GameObject.FindGameObjectsWithTag("cubes");
	for(var i = 0; i < cubes.length; i++) {
		switch (cubes[i].name) {
			case "c1": cubes[i].transform.localScale.y = c1; break;
			case "c3": cubes[i].transform.localScale.y = c3; break;
			case "c4": cubes[i].transform.localScale.y = c4; break;
			case "c5": cubes[i].transform.localScale.y = c5; break;
			
		}
	
	}
	
	
	
	
}