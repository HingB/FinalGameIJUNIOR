using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player _player;

    private Rigidbody2D _rigidbody;
    private bool _controllingIsBlocked;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_controllingIsBlocked)
            return;

        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(x, y) * _speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        _player.OnDie += BlockControl;
    }

    private void OnDisable()
    {
        _player.OnDie -= BlockControl;   
    }

    private void BlockControl()
    {
        _controllingIsBlocked = true;
    }
}
