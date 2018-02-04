using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonManager : MonoBehaviour {
    [SerializeField]
    private GameObject _pigeon;
    [SerializeField]
    private GameObject _point;
    [SerializeField, Range(0, 100)]
    private int _numberOfPigeons;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < _numberOfPigeons; i++)
        {
            Instantiate(
                _pigeon,
                new Vector3(Random.value * 500.0f, -1.59f, Random.value * 500.0f),
                Quaternion.Euler(0.0f, Random.value * 360.0f, 0.0f));
            Instantiate(
                _point,
                new Vector3(Random.value * 500.0f, -1.37f, Random.value * 500.0f),
                Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
