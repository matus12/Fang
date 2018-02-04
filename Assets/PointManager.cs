using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour {
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LevelManager manager = (LevelManager)GameObject.Find("LevelManager").GetComponent(typeof(LevelManager));
            manager.addPoint();
            Destroy(gameObject);
            print(manager.getPoints());
            if(manager.getPoints() > 4)
            {
                CatController catController = (CatController)GameObject.Find("Fang").GetComponent(typeof(CatController));
                catController.setColor(Color.black);
            }
        }
    }
}
