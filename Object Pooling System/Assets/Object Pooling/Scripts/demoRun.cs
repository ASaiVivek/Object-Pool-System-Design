using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoRun : MonoBehaviour
{
    private float xInp;
    private float yInp;
    //float sensitivity = 50;
    // public Transform playerHead;
    float xMin = -20f;
    float xMax = 20f;
    float xLim = 0.0f;
    float yLim = 0.0f;

    bool started;
    GameObject canvas;

    [Space]
    [Header("Pooling Elements")]

    public ObjectPooler Pool;

    // Start is called before the first frame update
    void Start()
    {

        canvas = GameObject.FindGameObjectWithTag("Canvas");
        Pool = GameObject.FindGameObjectWithTag("GameController").GetComponent<ObjectPooler>();//objectpooler
        // playerHead = gameObject.GetComponent<Transform>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("speed");
            transform.position += transform.forward * Time.deltaTime * 60.0f;
            //transform.rotation = Quaternion.Euler(xLim * 10, yLim * 20, yLim * 20);
        }
    }
    private void Update()
    {
//        started = canvas.GetComponent<MenuController>().started;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       

       // if (started == true)
       // {

            xInp = Input.GetAxis("Vertical");
            yInp = Input.GetAxis("Horizontal");

            //  RaycastHit Hit;
            //up and down movement limiters
            if (transform.position.y <= 2.0f)
            {
                transform.position = new Vector3(transform.position.x, 2.0f, transform.position.z);

            }
            else if (transform.position.y >= 10.0f) //maxinmum height a player can go
            {
                transform.position = new Vector3(transform.position.x, 10.0f, transform.position.z);

            }
            //left and right movement limiters
            if (transform.position.x <= -2.0f)
            {
                transform.position = new Vector3(-2.0f, transform.position.y, transform.position.z);

            }
            else if (transform.position.x >= 8.0f)
            {
                transform.position = new Vector3(8.0f, transform.position.y, transform.position.z);
            }


            // if (Input.GetButton("Fire1"))//give condition when its near the ground  //to move it forward
            // {
            //     transform.position += transform.forward * Time.deltaTime * 40.0f;
            // }

            xLim = Mathf.Clamp(xInp, xMin, xMax);
            yLim = Mathf.Clamp(yInp, xMin, xMax);
            transform.rotation = Quaternion.Euler(xLim * 10, yLim * 20, yLim * 15);


            //old raycasts
            // Vector3 dir = new Vector3(0, -1, 0);

            // if (Physics.Raycast(transform.position, dir, out Hit, 30f))
            // {
            //    Quaternion target = Quaternion.Euler(Hit.transform.rotation.x, Hit.transform.rotation.y, Hit.transform.rotation.z);
            // transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.fixedDeltaTime * 5.0f);
            //   Debug.DrawRay(transform.position, dir * Hit.distance, Color.green);

            //transform.rotation = Quaternion.Euler(Hit.collider.transform.position.x, 0,0);
            // }


            transform.position += transform.forward * Time.fixedDeltaTime * 10.0f;


            // if (xinp != null)
            // {
            //     transform.position += transform.forward * Time.deltaTime * 10.0f;
            // }
            // if(yinp != null)
            //{
            //    transform.position += transform.forward * Time.deltaTime * 10.0f;
            // }
            // transform.Rotate(xlim, 0.0f, 0.0f);
            //Vector3 playerHeadEulerAngles = playerHead.rotation.eulerAngles;
            //playerHeadEulerAngles.x = Mathf.Clamp(playerHeadEulerAngles.x, xMin, xMax);
            //playerHead.rotation = Quaternion.Euler(playerHeadEulerAngles);

            //transform.Rotate(playerHead.rotation.x, 0.0f, 0.0f);
        //}
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spawner"))
        {
           // Debug.Log("Spawned");
            Pool.Spawner();
        }
    }





}
