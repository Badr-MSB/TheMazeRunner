using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }      

        
    }
    private void shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            if(hit.collider != null)
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ennemie"))
                {
                    Debug.Log("ennemie damaged");
                    hit.collider.gameObject.GetComponent<EnnemiController>().Damaged();
                } 
            }
        }
    }
}
