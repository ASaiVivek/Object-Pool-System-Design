using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlerpTest : MonoBehaviour
{


    [SerializeField] private float timeCount = 0.0f;
    [SerializeField] private float Restoring_Speed = 0.1f;


    Quaternion originalRotation;
    bool restoreRotation = false;



    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += (-transform.forward) * Time.deltaTime * Speed;


        Debug.Log(Restoring_Speed);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, timeCount);
            timeCount += Time.deltaTime * Restoring_Speed;
            Debug.Log(timeCount);
        

    }



}
