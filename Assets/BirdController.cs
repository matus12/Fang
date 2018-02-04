using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {
    private Animator _animator;
    private GameObject _cat;
    private CatController _catController;
    private Rigidbody _rigidbody;
    private bool _flying = false;
    private float _timeStartedFlying;
    private bool deleteLock = false;

    // Use this for initialization
    void Start () {
        _animator = transform.GetComponent<Animator>();
        _cat = GameObject.Find("Fang");
        _catController = (CatController)_cat.GetComponent(typeof(CatController));
        _rigidbody = transform.GetComponent<Rigidbody>();
        //_catController.setColor();
    }
	
	// Update is called once per frame
	void Update () {
        if (_flying)
        {
            print(Time.realtimeSinceStartup - _timeStartedFlying);
            if (Time.realtimeSinceStartup - _timeStartedFlying > 10)
            {
                print("DOWN!!!");
                _rigidbody = transform.GetComponent<Rigidbody>();
                _rigidbody.AddForce(new Vector3(0.0f, -200.0f, 0.0f));
                _flying = false;
                deleteLock = false;
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !deleteLock)
        {
            _catController.setAttackAnimation();
                _catController.setColor(Color.white);
                Destroy(gameObject);
                LevelManager manager = (LevelManager)GameObject.Find("LevelManager").GetComponent(typeof(LevelManager));
                manager.subtract5Points();
            print("WHAT THE HELL");
        }
    }

    public void startFly()
    {
        _animator.SetBool("flying", true);
        _rigidbody.AddForce(new Vector3(0.0f, 200.0f, 0.0f));
        _flying = true;
        _timeStartedFlying = Time.realtimeSinceStartup;
    }

    public void setLock()
    {
        deleteLock = true;
    }
}
