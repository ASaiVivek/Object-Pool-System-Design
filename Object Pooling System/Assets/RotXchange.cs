using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotXchange : MonoBehaviour
{
   public GameObject jet;
   // Vector3 jet_dir;
    Vector3 Ztrans;
    //float Zpos;
    // Start is called before the first frame update
    void Start()
    {
        jet = GameObject.FindGameObjectWithTag("Player");
       // Zpos = transform.position.z;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // Ztrans = transform.position;
        //jet_dir = new Vector3(jet.transform.position.x, jet.transform.position.y, jet.transform.position.z);
       // Ztrans = new Vector3(jet.transform.position.x, jet.transform.position.y, jet.transform.position.z+3);
        
        Vector3 dir = new Vector3(0, -1, 0);
        RaycastHit Hit;
         if(Physics.Raycast(transform.position,dir,out Hit,30f))
         {
            jet.transform.rotation = Quaternion.Euler(Hit.transform.rotation.x, 0, 0);
            //jet.transform.rotation = Quaternion.Euler(transform.rotation.x, 0, 0);
            Debug.DrawRay(transform.position, dir, Color.green);
         }
    }
}
