using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintScore : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "Hi"; 
    }

    // Update is called once per frame
    void Update()
    {
       this.GetComponent<Text>().text = "Health : " + (Player.GetComponent<PersonneController>().getScore()).ToString();

    }
}
