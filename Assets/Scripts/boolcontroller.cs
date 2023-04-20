using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boolcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Person;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( (Person.transform.position.x == gameObject.transform.position.x) && (Person.transform.position.z == gameObject.transform.position.z)  )
        {
            Destroy(gameObject);
        } 
    }
 
}
