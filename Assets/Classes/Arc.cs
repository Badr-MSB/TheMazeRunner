using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arc 
{
    public int pere;
    public int numVertex;
    public int poid;
    public bool trueBrother;
    
    public Arc(int numBrother,int pere,int poid)
    {
        this.numVertex = numBrother;
        this.poid = poid;
        this.pere = pere;
        
        trueBrother = false;
    }
    public void setNumVertex(int number)
    {
        numVertex = number;
    }
   
}
