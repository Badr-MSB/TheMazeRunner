using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partition 
{
    public int[] table_des_pere;
    public int[] table_des_hauteur;
    public Partition(int taille)
    {
        table_des_pere = new int[taille];
        table_des_hauteur = new int[taille];
        for(int i = 0; i < taille; i++)
        {
            table_des_pere[i] = i;
            table_des_hauteur[i] = 0;
        }
    }


    public int recuperer_classe(int k)
    {

        int classe = k;
        while (table_des_pere[classe] != classe)
        {
            classe = table_des_pere[classe];
        }
        return classe;

    }
    public void fusionner(int x,int y)
    {
        int classe_x = recuperer_classe(x);
        int classe_y = recuperer_classe(y);

        if (table_des_hauteur[classe_x] < table_des_hauteur[classe_y])
        {

            table_des_pere[classe_x] = classe_y;
            table_des_hauteur[classe_y] = max(1 + table_des_hauteur[classe_x], table_des_hauteur[classe_y]);
            table_des_hauteur[classe_x] = -1;

        }
        else
        {

            table_des_pere[classe_y] = classe_x;
            table_des_hauteur[classe_x] += max(1 + table_des_hauteur[classe_y],table_des_hauteur[classe_x]);
            table_des_hauteur[classe_y] = -1;

        }
    }
    public int max(int x, int y)
    {

        int c = y;
        if (x > y)
        {
            c = x;
        }
        return c;

    }
}
