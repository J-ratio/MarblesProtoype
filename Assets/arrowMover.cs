using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowMover : MonoBehaviour
{

    public float speed = 1.0f;
    public float range = 1.0f;
    public float offset = 0.0f;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        MoveArrow();
    }


    void MoveArrow()
    {
        StartCoroutine("Oscillate");
    }


    IEnumerator Oscillate()
    {
        while(true)
        {
            yield return new WaitForEndOfFrame();
            float x = Mathf.Sin(Time.time * speed + offset) * range;
            transform.position = startPosition + new Vector3(x, 0, 0);
        }

        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

    

