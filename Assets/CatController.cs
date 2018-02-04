using UnityEngine;

public class CatController : MonoBehaviour {
    [SerializeField]
    private float _force = 100.0f;
    [SerializeField]
    private float _movementSpeed = 1.0f;
    private Rigidbody _rigidBody;
    private Animator _animator;
    private Renderer _catShader;
    private bool attacking;

    public void setColor(Color color)
    {
        _catShader = transform.GetChild(0).gameObject.GetComponent<Renderer>();
        _catShader.material.SetColor("_Color", color);
    }

    public void setAttackAnimation()
    {
        attacking = true;
        _animator.SetBool("Jump", true);
        print("HELLO");
    }

    public Color getColor()
    {
        _catShader = transform.GetChild(0).gameObject.GetComponent<Renderer>();
        return _catShader.material.GetColor("_Color");
    }

	void Start () {
        _rigidBody = transform.GetComponent<Rigidbody>();
        _animator = transform.GetComponent<Animator>();
        _catShader = transform.GetChild(0).gameObject.GetComponent<Renderer>();
        _catShader.material.shader = Shader.Find("Standard");
    }
	
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * _movementSpeed;


        if (z != 0)
        {
            _animator.SetBool("Run", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _animator.SetBool("Sprint", true);
                z *= 3;
            } else
            {
                _animator.SetBool("Sprint", false);
            }
        }
        else
        {
            _animator.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetBool("Jump", true);
            _rigidBody.AddForce(new Vector3(0.0f, 1.0f * _force, 1.0f * _force));
            setColor(Color.black);
        }
        else
        {
            _animator.SetBool("Jump", false);
        }

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}
