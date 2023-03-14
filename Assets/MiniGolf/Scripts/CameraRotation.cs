using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script which makes camera rotate around ball
/// </summary>
public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 0.2f;    //rotation speed
    int rotationDirection;

    public static CameraRotation instance;

    Coroutine RotationInstance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartRotatingCamera(bool toLeft)           
    {
        if(toLeft) rotationDirection = 1; else rotationDirection = -1;

        if(RotationInstance == null)    RotationInstance = StartCoroutine("RotateCam");
    }

    public void StopRotating()
    {

        if(RotationInstance != null){
            StopCoroutine(RotationInstance);
            RotationInstance = null;
        }
    }

    IEnumerator RotateCam()
    {
        while(true)
        {
            transform.Rotate(rotationDirection*Vector3.down, rotationSpeed); //rotate the camera
            yield return new WaitForEndOfFrame();
        }
        yield break;
    }

}
