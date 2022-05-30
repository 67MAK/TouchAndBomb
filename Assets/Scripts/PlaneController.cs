using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public static PlaneController Instance;
    Rigidbody _rb;
    public bool isDead = false;
    [SerializeField] float speed;
    [SerializeField] GameObject _bomb;
    [SerializeField] Transform _muzzle;
    bool _gameStarted = false, boost = false;
    bool turnLeft, turnRight;
    [SerializeField] Joystick _joystick;
    float horizontalMove = 0f, verticalMove = 0f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 0f;
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_gameStarted && !isDead)
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
        
        /*if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            boost = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            boost = false;
        }*/
    }

    public void instantBomb()
    {
        if (!_gameStarted)
        {
            Time.timeScale = 1f;
            _gameStarted = true;
        }
        else
        {
            LevelCalculator.Instance.usedBombCount++;
            LevelCalculator.Instance.score -= 10f;
            Instantiate(_bomb, _muzzle.transform.position, Quaternion.identity);
        }

    }
    public void PointerDownLeft()
    {
 
        turnLeft = true;
    }
    public void PointerUpLeft()
    {
 
        turnLeft = false;
    }

    public void PointerDownRight()
    {

        turnRight = true;
    }
    public void PointerUpRight()
    {
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
    private void OnCollisionEnter(Collision collision)
    {
        LevelManager.Instance.IsDeadProcess(); 
    }
}
