using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneCreator : MonoBehaviour
{
    public GameObject _Plane;
    public GameObject _Wall;
    public GameObject _Personnage;
    public GameObject _Score;
    public GameObject _bool;
    public GameObject _hunter;
    public GameObject Canvas;
    public int difficulte;
    public int height;
    public int width;
    public Vector3 Initialposition;
    public Graph g;
    private List<GameObject> walls = new List<GameObject>();

    private Vector3 offset = new Vector3(0.5f, 0, 0.5f);
    //private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
       
        
    }

    public void Create()
    {
        g = new Graph(height, width);
        if (difficulte == 0)
        {
            Kruskal kruskal = new Kruskal(g);
            kruskal.arbre_couverante(g);
            Kruskal kruskal2 = new Kruskal(g);
            kruskal2.arbre_couverante(g);
        }
        if (difficulte == 1)
        {
            BackTracking.Backtrack(g);
        }
        else
        {
            Kruskal kruskal = new Kruskal(g);
            kruskal.arbre_couverante(g);
        }
        printScene(g);
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
    void printScene(Graph g)
    {
        createPlan(height, width);
        for (int i = 0; i < height * width; i++)
        {
            foreach (Arc frere in g.sommets[i].brothers)
            {
                if ((!frere.trueBrother) && (frere.numVertex == (g.sommets[i].number + 1)) )
                {
                    putCube(_Wall, (i / height), (i % width) + 1, 1.0f, 0.1f);
                }
                if ((!frere.trueBrother) && (frere.numVertex == (g.sommets[i].number + width))  )
                {
                    putCube(cube: _Wall, (i / height) + 1, i % width, 0.1f, 1.0f);
                }
            }
        }
        
        for(int i = 0; i < height; i++) 
        {
            putCube(_Wall, i, 0, 1.0f, 0.1f);
            putCube(_Wall, i, width, 1.0f, 0.1f);

        }

        for (int i = 0; i < width; i++) 
        {
            putCube(_Wall, 0, i, 0.1f, 1.0f);
            putCube(_Wall, height, i, 0.1f, 1.0f);

        }
        CreatPersonnage();
        CreatHunter();
        _Score.SetActive(true);
    }

    void putCube(GameObject cube, float x,float z, float h,float w)
    {
        GameObject newCube = GameObject.Instantiate(cube);
        newCube.transform.localScale = new Vector3(h, 1, w);
        newCube.transform.position = new Vector3( x +h/2, transform.localScale.y/2, z+w/2) ;
        newCube.SetActive(true);
        walls.Add(newCube);
    }
    void createPlan(int height,int width)
    {
        GameObject plane = GameObject.Instantiate(_Plane, new Vector3(height/2, 0, width/2), Quaternion.Euler(0,0,0));
        plane.transform.localScale= new Vector3(height, 1, width);
        plane.SetActive(true);
        walls.Add(plane);
    }

    public void CreatPersonnage()
    {
        Vector3 position = new Vector3(0.5f, transform.localScale.y / 2, 0.5f);
        Quaternion rotation =  Quaternion.Euler(0.0f, 0.0f, 0.0f);
        Vector3 localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //GameObject personne = GameObject.Instantiate(_Personnage,Initialposition + position ,rotation);
        _Personnage.transform.localScale = localScale;
        _Personnage.transform.position = Initialposition + position;
        _Personnage.transform.rotation = rotation;
       // _Personnage.AddComponent<PersonneController>();
        _Personnage.SetActive(true);
    }
    public void CreatHunter()
    {
        System.Random rand = new System.Random();
        int nombreAleatoireX = rand.Next(height);
        int nombreAleatoireZ = rand.Next(width);



        Vector3 position = new Vector3( nombreAleatoireX - 0.5f, transform.localScale.y / 2 , nombreAleatoireZ - 0.5f);
        Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        Vector3 localScale = new Vector3(0.5f, 0.5f, 0.5f);
        _hunter.transform.localScale = localScale;
        _hunter.transform.position =  position;
        _hunter.transform.rotation = rotation;
        _hunter.GetComponent<EnnemiController>().health = 60;
        _hunter.SetActive(true);
    }

    public void EndGameVictory()
    {
        foreach(GameObject wall in walls)
        {
            Destroy(wall);
        }
        walls.Clear();
        _hunter.SetActive(false);
        _Personnage.GetComponent<PersonneController>().Score = 100;
        _Personnage.SetActive(false);
        Canvas.GetComponent<MainMenu>().gameover();
        
    }
    public void EndGameDefait()
    {
        foreach (GameObject wall in walls)
        {
            Destroy(wall);
        }
        walls.Clear();
        _hunter.SetActive(false);
        _Personnage.GetComponent<PersonneController>().Score = 100;
        _Personnage.SetActive(false);
        Canvas.GetComponent<MainMenu>().gameover();

    }
}