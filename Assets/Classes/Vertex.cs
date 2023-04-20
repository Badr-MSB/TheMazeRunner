using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex 
{
    public int number;
    public List<Arc> brothers;
    public int _graphHeight;
    public int _graphWidth;
    /// Dijkstra atributs
    public int Cout;
    public int pere;
    // bool de pacman
    public bool ContientBool;

    public Vertex(int number,int height,int width)
    {
        this.number = number;
        brothers = new List<Arc>();
        if ( ( (int)number %width != width-1) && (int)number / height != height - 1)
        {
            
            brothers.Add(new Arc((number + 1)% (height*width), number, 1));
            brothers.Add(new Arc((number + width)% (height*width) , number, 1));
        }
        
        else if ((number % width == width - 1) && number != height * width - 1)
        {
          
            brothers.Add(new Arc((number + width) % (height * width), number, 1));
        }
        else if ((int)number / height == height - 1 && number != height * width - 1)
        {
            
            brothers.Add(new Arc((number + 1) % (height * width), number, 1));
        }
        Cout = height * width + 1;
        _graphHeight = height;
        _graphWidth = width;
        ContientBool = true;
    }
    public void setVertexNumber(int number)
    {
        this.number = number; 
    }
}
