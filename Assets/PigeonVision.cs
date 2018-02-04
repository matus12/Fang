using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonVision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CatController catController = (CatController) other.GetComponentInParent(typeof(CatController));
            if (catController.getColor() != Color.black)
            {
                BirdController birdController = (BirdController)gameObject.GetComponentInParent(typeof(BirdController));
                birdController.startFly();
                birdController.setLock();
            }
        }
    }
}
