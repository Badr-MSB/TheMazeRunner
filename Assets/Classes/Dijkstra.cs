using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Dijkstra 
{
    //public GameObject _personne;
    static public List<int> plusCourChemin(int sommet_Depart,int Destination, Graph g)
    {
        List<int> liste_atraiter = new List<int>();
        Queue<int> liste_atteint = new Queue<int>();
        List<int> Chemin = new List<int>();

        initgraph(g);
        // le code sur le livre
        // trier la liste
        liste_atraiter.Add(sommet_Depart);
        g.sommets[sommet_Depart].Cout = 0;
        int u;
        while(liste_atraiter.Count != 0)
        {
            liste_atraiter.Sort( (s1,s2) =>  g.sommets[s1].Cout.CompareTo(g.sommets[s2].Cout)  );
            u = liste_atraiter[0];
            liste_atraiter.RemoveAt(0);
            Debug.Log("Dequeue est : " + u);
            if(u == Destination)
            {
                break;
            }
            else
            {
                liste_atteint.Enqueue(u);
                List<Arc> arc_de_u = g.VertexArcs(u);
                foreach (Arc i in arc_de_u)
                {
                    int distTMP = g.sommets[u].Cout + i.poid;
                    if ((distTMP < g.sommets[i.numVertex].Cout) && !liste_atteint.Contains(i.numVertex))
                    {
                        g.sommets[i.numVertex].Cout = distTMP;
                        g.sommets[i.numVertex].pere = u;
                        liste_atraiter.Add(i.numVertex);
                        Debug.Log("sommet : " + i.numVertex +" à :" + g.sommets[i.numVertex].Cout + "pere :" + g.sommets[i.numVertex].pere);
                    }

                }
            }
            
            
        }
        int j= Destination;
       
        while(j != sommet_Depart)
        {
            Chemin.Add(j);
            j = g.sommets[j].pere;
        }
        for(int e =0; e < Chemin.Count; e++)
        {
            Debug.Log(Chemin[e] + " --> ");
        }
        return Chemin;

    }
    static private void initgraph(Graph g)
    {
        for(int i = 0; i< g.sommets.Length; i++)
        {
            g.sommets[i].Cout = g.sommets.Length * g.sommets.Length + 1;
            g.sommets[i].pere = -1;
        }
    }
   
}


