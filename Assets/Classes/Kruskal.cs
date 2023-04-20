using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kruskal 
{
    private Partition p1;
    public Kruskal(Graph g)
    {
        p1 = new Partition(g.height*g.width);
    }
    public void arbre_couverante(Graph g)
    {
        int[] liste = new int[g.height * g.width];
        for(int j =0; j < g.width * g.height; j++)
        {
            liste[j] = j;
        }
        for(int j = 0;j < g.width*g.height; j++)
        {
            int c = Random.Range(0, g.height * g.width );
            int temp = liste[j];
            liste[j] = liste[c];
            liste[c] = temp;
        }
        
        foreach(int i in liste)
        {
            foreach (Arc arc in g.sommets[i].brothers)
            {
                if ((p1.recuperer_classe(i) != p1.recuperer_classe(arc.numVertex)))
                {
                    arc.trueBrother = true;
                    p1.fusionner(i, arc.numVertex);
                }

            }
        } 
    }
}
