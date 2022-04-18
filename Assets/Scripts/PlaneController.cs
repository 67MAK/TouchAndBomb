using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] float speed;
    [SerializeField] GameObject _bomb;
    [SerializeField] Transform _muzzle;
    bool _gameStarted = true, boost = false;
    bool turnLeft, turnRight;
    [SerializeField] Joystick _joystick;
    float horizontalMove = 0f, verticalMove = 0f;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_gameStarted)
        {
            TurnableMoveManager();
            if (boost) _rb.velocity = transform.forward * 2 * Time.deltaTime * speed;
            else _rb.velocity = transform.forward * Time.deltaTime * speed;
            horizontalMove = _joystick.Horizontal * 60;
            verticalMove = _joystick.Vertical * -50;
            transform.Rotate(0, horizontalMove * Time.deltaTime, 0);
            transform.Rotate(verticalMove * Time.deltaTime, 0, 0);
        }

        /*if (Input.GetKeyDown(KeyCode.W))
        {
            _gameStarted = true;
        }*/
        //Rotation Right and Left

        //Rotation Up and Down
        //Rotation Turn
        /*if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 0, -30 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, 0, 30 * Time.deltaTime);
        }*/
        //Bombing
        /*if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(_bomb, _muzzle.transform.position, Quaternion.identity);
        }*/
        //Boost
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            boost = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            boost = false;
        }
    }

    public void instantBomb()
    {
        if (!_gameStarted) _gameStarted = true;
        Instantiate(_bomb, _muzzle.transform.position, Quaternion.identity);
    }
    public void PointerDownLeft()
    {
        if (!_gameStarted) _gameStarted = true;
        turnLeft = true;
    }
    public void PointerUpLeft()
    {
        if (!_gameStarted) _gameStarted = true;
        turnLeft = false;
    }

    public void PointerDownRight()
    {
        if (!_gameStarted) _gameStarted = true;
        turnRight = true;
    }
    public void PointerUpRight()
    {
        if (!_gameStarted) _gameStarted = true;
        turnRight = false;
    }
    public void TurnableMoveManager()
    {
        if (!_gameStarted) _gameStarted = true;
        if (turnLeft)
        {
            transform.Rotate(0, 0, 30 * Time.deltaTime);
        }
        else if (turnRight)
        {
            transform.Rotate(0, 0, -30 * Time.deltaTime);
        }
    }
}
