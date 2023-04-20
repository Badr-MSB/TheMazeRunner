using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph 
{
    public int height;
    public int width;
    public Vertex[] sommets;

    public Graph(int height,int width)
    {
        this.height = height;
        this.width = width;
        this.sommets = new Vertex[height * width];
        for(int i = 0;i<height*width ; i++)
        {
            this.sommets[i] = new Vertex(i,height,width);
        }
    }
    public void printGraph()
    {
        for (int i = 0; i < height * width; i++)
        {
            Debug.Log( " *** " +sommets[i].number + " : ");
            foreach(Arc c in sommets[i].brothers)
            {
                Debug.Log(c.numVertex +" : " + c.trueBrother +  " , ");
            }
                //+ sommets[i].brothers[0].numVertex + " , " + sommets[i].brothers[1].numVertex);

        }
    }
    public List<Arc> toArcs()
    {
        List<Arc> graphArcs = new List<Arc>();
        for(int i = 0; i < sommets.Length; i++)
        {
            foreach(Arc c in sommets[i].brothers)
            {
                if (c.trueBrother)
                {
                    graphArcs.Add(new Arc(c.numVertex, c.pere, 1));
                }
                
            }
        }
        return graphArcs;
    }
    public List<Arc> VertexArcs(int i)
    {
        List<Arc> Vertex_arcs = new List<Arc>();
 
        foreach(Arc c in sommets[i].brothers)
        {
            if (c.trueBrother)
            {
                Vertex_arcs.Add(c);
            }
        }
        if(i - width >= 0)
        {
            foreach (Arc c in sommets[i-width].brothers)
            {
                if ((c.trueBrother) && (c.numVertex == i))
                {
                    Vertex_arcs.Add(new Arc(i-width,i,1)) ;
                }
            }
        }
        if (i - 1 >= 0)
        {
            foreach (Arc c in sommets[i - 1].brothers)
            {
                if ((c.trueBrother) && (c.numVertex == i))
                {
                    Vertex_arcs.Add(new Arc(i-1,i,1));
                }
            }
        }
        return Vertex_arcs;
    }
}
