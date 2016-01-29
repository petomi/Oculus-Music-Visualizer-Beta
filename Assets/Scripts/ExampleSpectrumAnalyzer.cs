using UnityEngine;
using System.Collections;

/*  Purpose of this script is to control 5 cubes based on sound
 *   written in C#
*/
public class ExampleSpectrumAnalyzer : MonoBehaviour {
	
	public GameObject cube01;
	public GameObject cube02;
	public GameObject cube03;
	public GameObject cube04;
	public GameObject cube05;
	
	public float juice = 20f;
	
	public float[] spec;
	
	public float specMag01;
	public float specMag02;
	public float specMag03;
	public float specMag04;
	public float specMag05;
	
	public Transform startMarker;
	public Transform endMarker;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	void Start() {
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}

	// Update is called once per frame
	void Update () {
		//spec = AudioListener.GetSpectrumData(64,0,FFTWindow.Hamming); // this works on audio source
		spec = AudioListener.GetOutputData (64,0);  // this gives much  better values.

		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;

		specMag01 = spec[2] + spec[4];
		specMag02 = spec[12] + spec[14];
		specMag03 = spec[22] + spec[24];
		specMag04 = spec[32] + spec[34];
		specMag05 = spec[57] + spec[60];
		
		float C1 = distCovered/specMag01*juice;
		float C2 = distCovered/specMag02*juice;
		float C3 = distCovered/specMag03*juice;
		float C4 = distCovered/specMag01*juice;
		float C5 = distCovered/specMag01*juice;

		Vector3 C1trans = Vector3.Lerp(startMarker.position, endMarker.position,C1);
		Vector3 C2trans = Vector3.Lerp(startMarker.position, endMarker.position,C2);
		Vector3 C3trans = Vector3.Lerp(startMarker.position, endMarker.position,C3);
		Vector3 C4trans = Vector3.Lerp(startMarker.position, endMarker.position,C4);
		Vector3 C5trans = Vector3.Lerp(startMarker.position, endMarker.position,C5);


		cube01.gameObject.transform.localScale = C1trans;
		cube02.gameObject.transform.localScale = C2trans;
		cube03.gameObject.transform.localScale = C3trans;
		cube04.gameObject.transform.localScale = C4trans;
		cube05.gameObject.transform.localScale = C5trans;


//		cube01.gameObject.transform.localScale = new Vector3(1f,specMag01*juice,1f);
//		cube02.gameObject.transform.localScale = new Vector3(1f,specMag02*juice,1f);
//		cube03.gameObject.transform.localScale = new Vector3(1f,specMag03*juice,1f);
//		cube04.gameObject.transform.localScale = new Vector3(1f,specMag04*juice,1f);
//		cube05.gameObject.transform.localScale = new Vector3(1f,specMag05*juice,1f);
	}
}﻿