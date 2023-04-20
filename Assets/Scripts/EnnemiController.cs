using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiController : MonoBehaviour
{
    public float MovementSpeed;
    public GameObject scene;
    public GameObject Player;

    
    private int width;
    public int health = 60;

    private float speed = 0.4f;
    //free to mode
    private bool freetoMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
        width = scene.GetComponent<SceneCreator>().width;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (freetoMove)
        {
            handle_Dijkstra(Player.GetComponent<PersonneController>().getVertex());
        }
        
    }
    IEnumerator go_left()
    {
       // int ActualVertex = getVertex();
       // if (ActualVertex - width >= 0)
        {
           // foreach (Arc a in scene.GetComponent<SceneCreator>().g.sommets[ActualVertex - width].brothers)
            {
               // if (a.numVertex == ActualVertex && a.trueBrother)
                {
                    //for (int i = 0; i < 10; i++)
                    {
                        gameObject.transform.position = Vector3.MoveTowards(transform.position, gameObject.transform.position + new Vector3(-1.0f, 0, 0), speed * Time.deltaTime);
                        // yield return new WaitForSeconds(0.3f);
                    }
                    yield return new WaitForSeconds(0.3f);
                }
            }
        }
    }
    IEnumerator go_down()
    {
       // int ActualVertex = getVertex();
        //if (ActualVertex % width != 0)
        {
            //foreach (Arc a in scene.GetComponent<SceneCreator>().g.sommets[ActualVertex - 1].brothers)
            {
               // if (a.numVertex == ActualVertex && a.trueBrother)
                {
                   // for (int i = 0; i < 10; i++)
                    {
                        gameObject.transform.position = Vector3.MoveTowards(transform.position, gameObject.transform.position + new Vector3(0, 0, -1.0f), speed * Time.deltaTime);

                        // yield return new WaitForSeconds(0.3f);
                    }
                    yield return new WaitForSeconds(0.3f);
                }
            }
        }
    }
    IEnumerator go_right()
    {
       // int ActualVertex = getVertex();
        //foreach (Arc a in scene.GetComponent<SceneCreator>().g.sommets[ActualVertex].brothers)
        {
          //  if ((a.numVertex == ActualVertex + width) && (a.trueBrother))
            {
               // for (int i = 0; i < 10; i++)
                {
                    gameObject.transform.position = Vector3.MoveTowards(transform.position, gameObject.transform.position + new Vector3(1.0f, 0, 0), speed * Time.deltaTime);


                }
                yield return new WaitForSeconds(0.3f);
            }
        }

    }
    IEnumerator go_up()
    {
        //int ActualVertex = getVertex();
       // foreach (Arc a in scene.GetComponent<SceneCreator>().g.sommets[ActualVertex].brothers)
        {
           // if ((a.numVertex == ActualVertex + 1) && (a.trueBrother == true))

            {
               // for(int i = 0; i < 10 ; i++)
                {
                    gameObject.transform.position = Vector3.MoveTowards(transform.position, gameObject.transform.position + new Vector3(0, 0, 1.0f),speed * Time.deltaTime);


                }
                yield return new WaitForSeconds(0.3f);
            }
        }
    }
    private int getVertex()
    {

        int vertex = ((int)transform.position.x) * scene.GetComponent<SceneCreator>().width + (int)transform.position.z;
        return vertex;
    }
    public void handle_Dijkstra(int PlayerVertex)
    {
        freetoMove = false;
        int depart = getVertex();
        List<int> chemin = Dijkstra.plusCourChemin(depart, PlayerVertex, scene.GetComponent<SceneCreator>().g);
        for (int e = chemin.Count - 1; e > 0; e--)
        {
            //yield return new WaitForSeconds(5);
            int v = getVertex();
            if (v == chemin[e] - 1)
            {
                StartCoroutine(go_up());

            }
            if (v == chemin[e] + width)
            {
                StartCoroutine(go_left());
            }
            if (v == chemin[e] + 1)
            {
                StartCoroutine(go_down());
            }
            if (v == chemin[e] - width)
            {
                StartCoroutine(go_right());
            }

            Debug.Log(v);
            //yield return new WaitForSeconds(MovementSpeed);
        }
        freetoMove = true;
    }
    public void Damaged() { 
    
        health -= 20;
        
        if(health <= 0)
        {
            freetoMove = true;
            gameObject.SetActive(false);
            Player.GetComponent<PersonneController>().EnnemieKilled();
            GameObject.Find("Scene").GetComponent<SceneCreator>().CreatHunter();
            
        }
    }
}
