using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasBinaire 
{
    private int[] tas;
    private int taille = 0;
    private Graph g;
   // private int infini;
    public TasBinaire(int l, Graph g)
    {
        tas = new int[l];
        //taille = l;
        this.g  =  g;
        //infini = l * l + 1;
    }
 
    public int DeleteMin()
    {
        int minElement, lastElement, child, now;
        minElement = tas[0];
        lastElement = tas[taille--];

        for (now = 1; now * 2 <= taille; now = child)
        {
            child = now * 2;
            
            if (child != taille && (g.sommets[ tas[child + 1] ].Cout < g.sommets[ tas[child] ].Cout ))
            {
                child++;
            }
            if (g.sommets[lastElement].Cout > g.sommets[tas[child]].Cout)
            {
                tas[now] = tas[child];
            }
            else /* It fits there */
            {
                break;
            }
        }
        tas[now] = lastElement;

        return minElement;
    }
    public void Insert(int element)
    {
        taille++;
        tas[taille] = element; /*Insert in the last place*/
        /*Adjust its position*/
        int now = taille;
        while ( g.sommets[tas[now / 2]].Cout > g.sommets[element].Cout )
        {
            tas[now] = tas[now / 2];
            now /= 2;
        }
        tas[now] = element;
    }
}
