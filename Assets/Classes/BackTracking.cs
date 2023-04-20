using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BackTracking 
{
    
    public static void Backtrack(Graph g )
    {
        var rng = new System.Random();

        Stack<int> Path = new Stack<int>();
        List<int> Visited = new List<int>();

        int pos = rng.Next(0, g.height * g.width - 1);

        Path.Push(pos);
        Visited.Add(pos);

       

        while (Path.Count > 0 )
        {
            pos = Path.Pop();
            var Voisins = getUnvisitedVoisins(pos, g, Visited);
            if(Voisins.Count > 0)
            {
                Path.Push(pos);
                int randindex = rng.Next(0, Voisins.Count);
                RendreTrueBrother( Mathf.Min( pos, Voisins[randindex]), Mathf.Max(pos, Voisins[randindex]), g);
               // Debug.Log("rendre voisin : " + pos + " et " + Voisins[randindex]);
                Visited.Add(Voisins[randindex]);
                Path.Push( Voisins[randindex]);
            }
            
        }
    }

    public static List<int> getUnvisitedVoisins(int sommet , Graph g , List<int> Visited)
    {
        List<int> unvisitedVoisins = new List<int>();
        foreach(Arc c in g.sommets[sommet].brothers)
        {
            if( !Visited.Contains(c.numVertex))
            {
                unvisitedVoisins.Add(c.numVertex);
            }
        }
        if(sommet % g.width > 0  )
        {
            if ( !Visited.Contains(sommet - 1) )
            {
                unvisitedVoisins.Add(sommet - 1);
            }
        }
        if(sommet - g.width >= 0 )
        {
            if (!Visited.Contains(sommet - g.width))
            {
                unvisitedVoisins.Add(sommet - g.width);
            }
        }
        //Debug.Log("sommet :" + sommet);
        foreach(int i in unvisitedVoisins)
        {
            //Debug.Log("vois :" + i);

        }
        //Debug.Log("//////////");

        return unvisitedVoisins;
    }
    public static void RendreTrueBrother(int a, int b , Graph g)
    {
        foreach(Arc c in g.sommets[a].brothers)
        {
            if(c.numVertex == b)
            {
                c.trueBrother = true;
            }
        }
    }


}
