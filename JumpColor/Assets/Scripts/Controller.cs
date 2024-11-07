using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private int _speed;
    [SerializeField] private int _jumpforce;
    [SerializeField] private bool _ground;
    [SerializeField] public float rayDistance = 0.6f;
    private int _jumpcounter;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rigidbody.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            _ground = true;
        }
        if (_ground == true)
        {
            _jumpcounter = 0;
        }
        if (_jumpcounter != 1)
        {
            _ground = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);

        }
        if (Input.GetKeyDown(KeyCode.Space) && _jumpcounter != 1 || Input.GetKeyDown(KeyCode.W) && _jumpcounter != 1)
        {
            _jumpcounter++;
            _rigidbody.AddForce(new Vector2(0, _jumpforce), ForceMode2D.Impulse);
            _ground = false;
        }
    }
}
