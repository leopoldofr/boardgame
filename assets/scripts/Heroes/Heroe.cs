using UnityEngine;
using System.Collections;

/* Permet la création basique d'un héro */


public class Heroe{

    private string nom;
    private int[] position;
    private string fichierHero;

    public Heroe(string n, int[] p, string file)
    {
        nom = n;
        position = p;
        fichierHero = file;

    }

    public int[] getPosition()
    {
        return position;
    }

    public string getImage()
    {
        return fichierHero;
    }

}
