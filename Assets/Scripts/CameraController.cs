using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //[SerializeField] Transform _target;
    [SerializeField] Transform _anchor;
    [SerializeField] Transform _secondAnchor;
    Quaternion target;
    float _cameraSpeed = 5.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("SecondCam"))
        {
            transform.position = new Vector3(_secondAnchor.position.x, _secondAnchor.position.y, _secondAnchor.position.z);
            transform.rotation = Quaternion.Euler(_secondAnchor.rotation.eulerAngles.x, _secondAnchor.rotation.eulerAngles.y, _secondAnchor.rotation.eulerAngles.z);
        }
        else
        {
            target = Quaternion.Euler(_anchor.rotation.eulerAngles.x, _anchor.rotation.eulerAngles.y, _anchor.rotation.eulerAngles.z);
            transform.position = new Vector3(_anchor.position.x, _anchor.position.y, _anchor.position.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _cameraSpeed);
        }
        
    }
}
