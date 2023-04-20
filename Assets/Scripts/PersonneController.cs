using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PersonneController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 offset = new Vector3(0.5f, 0, 0.5f);

    public GameObject scene;
    public GameObject Camera;
    
    public int Score = 100;
    private int height;
    private int width;
    private float CircelRaduis = 0.2f;
    private Vector3[] Directions;
    private float speed = 0.7f;

    void Start()
    {
        scene = GameObject.Find("Scene");
        Camera = GameObject.Find("PlayerCamera");
        height = scene.GetComponent<SceneCreator>().height;
        width = scene.GetComponent<SceneCreator>().width;
        Directions = new Vector3[] { new Vector3(CircelRaduis, 0, 0), new Vector3(0, 0, CircelRaduis), new Vector3(-CircelRaduis, 0, 0), new Vector3(0, 0, -CircelRaduis) };

    }

// Update is called once per frame
    void Update()
    {
        handleKeyDown();

    }
    public void setOffset(Vector3 v)
    {
        offset = v;
    }
    public int getVertex()
    {

        int vertex = ((int)transform.position.x) * scene.GetComponent<SceneCreator>().width + (int)transform.position.z;
        return vertex;
    }
    private void handleKeyDown()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 DirectionMvt = Directions[0];
            float Rotation = transform.rotation.eulerAngles.y;


            Vector3 DirectionAbsolu = Mult_Mat_Vect(ChangementDeBase(Rotation), DirectionMvt) ;

         

            DateTime debut = DateTime.Now;
            goInDirection(DirectionAbsolu);
            DateTime fin = DateTime.Now;
            TimeSpan tempsExecution = fin - debut;
            Debug.Log("Le temps d'exécution de MaFonction est de : " + tempsExecution.TotalMilliseconds + " ms");

           
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 DirectionCam = Directions[2];
            float Rotation = transform.rotation.eulerAngles.y;

            Vector3 DirectionAbsolu = Mult_Mat_Vect(ChangementDeBase(Rotation), DirectionCam);

            Debug.Log(DirectionAbsolu);
            goInDirection(DirectionAbsolu);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 DirectionCam = Directions[1];
            float Rotation = transform.rotation.eulerAngles.y;
            Vector3 DirectionAbsolu = Mult_Mat_Vect(ChangementDeBase(Rotation), DirectionCam);

            Debug.Log(DirectionAbsolu);
            goInDirection(DirectionAbsolu);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 DirectionCam = Directions[3];
            float Rotation = transform.rotation.eulerAngles.y;
            Vector3 DirectionAbsolu = Mult_Mat_Vect(ChangementDeBase(Rotation), DirectionCam);

            Debug.Log(DirectionAbsolu);
            goInDirection(DirectionAbsolu);
        }
    }
    private void goInDirection(Vector3 direction)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position + direction, CircelRaduis);

        bool seDeplacer = true;

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.name != "Capsule" && collider.gameObject.name != "Rifle")
            {
                Debug.Log("Detected " + collider.gameObject.name + " within the sphere");
                seDeplacer = false;
            }
        }
        if (seDeplacer)
        {
            transform.position = 
                Vector3.MoveTowards(transform.position, gameObject.transform.position + direction, speed * Time.deltaTime);
        }
    }
    private void goInDirection2(Vector3 direction)
    {
        Vector3 newPlace = transform.position + direction;
        int actuelVertex = getVertex();
        int DirectionVertex = (int)newPlace.x * scene.GetComponent<SceneCreator>().width + (int)newPlace.z;
        if (actuelVertex == DirectionVertex)
        {
            transform.position = transform.position + direction;
        }
        else foreach( Arc c in scene.GetComponent<SceneCreator>().g.sommets[Mathf.Min(actuelVertex, DirectionVertex)].brothers)
            {
                if(c.numVertex == DirectionVertex && c.trueBrother)
                {
                    transform.position = transform.position + direction;
                }
            }
        
    }

    private Vector3[] ChangementDeBase(float Rotation)
    {
        Vector3[] Mat_B_Bc = new Vector3[3];

        Mat_B_Bc[0] = new Vector3( Mathf.Cos(Rotation * Mathf.Deg2Rad), 0, Mathf.Sin(Rotation * Mathf.Deg2Rad) );
        Mat_B_Bc[1] = new Vector3(0, 1, 0);
        Mat_B_Bc[2] = new Vector3(-Mathf.Sin(Rotation * Mathf.Deg2Rad), 0, Mathf.Cos(Rotation * Mathf.Deg2Rad));

        return Mat_B_Bc;
    }
    private float Mul_vect_vect(Vector3 vect1, Vector3 vect2)
    {
        return vect1.x * vect2.x + vect1.y * vect2.y + vect1.z * vect2.z;
    }
    private Vector3 Mult_Mat_Vect(Vector3[] Mat, Vector3 vec)
    {
        Vector3 result = new Vector3( Mul_vect_vect( Mat[0],vec), Mul_vect_vect(Mat[1], vec), Mul_vect_vect(Mat[2], vec));
        return result;
    }
    public int getScore()
    {
        return Score;
    }
    
    

    public void Damaged()
    {
        if(Score >= 10)
        {
            Score -= 10;
        }
        if(Score <= 0)
        {
            //Destroy(gameObject , 0.5f);
            scene.GetComponent<SceneCreator>().EndGameDefait();
        }
    }
    public void EnnemieKilled()
    {
        Score = Score + 300;
        if(Score >= 1000)
        {
            scene.GetComponent<SceneCreator>().EndGameVictory();
        }
    }
}