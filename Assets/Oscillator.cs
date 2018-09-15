using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector;

    [Range(0, float.MaxValue)]
    [SerializeField] float period;

    //[Range(0, 1)]
    //[SerializeField]
    //float movementFactor;

    static Vector3 startingPos;

    // Use this for initialization
    void Start () {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if(period <= float.Epsilon) { return; }
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(tau * cycles);

        Vector3 delta = rawSineWave * movementVector;
        transform.position = startingPos + delta;
	}
}
