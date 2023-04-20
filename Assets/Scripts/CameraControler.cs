using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float SenceX = 100f;
    public float SenceY = 100f;
    private float xRotation;
    private float yRotation;


    //public Transform playerbody;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked ; // cursor in the midle of the screen
        Cursor.visible = false ; // cursor invisible
        xRotation = player.transform.rotation.x;
        yRotation = player.transform.rotation.y;

    }

    // Update is called once per frame
    void Update()
    {
        float mousX = Input.GetAxisRaw("Mouse X") * SenceX * Time.deltaTime;
        float mousY = Input.GetAxisRaw("Mouse Y") * SenceY * Time.deltaTime;


        yRotation += mousX;

        //xRotation -= mousY;

        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        player.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        
    }
}
