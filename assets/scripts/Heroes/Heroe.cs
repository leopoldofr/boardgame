using UnityEngine;
using System.Collections;

/* Permet la création basique d'un héro */


public class Heroe{

    private string nom;
    private int x;
	private int y;
    private string fichierHero;
	private int height;
	private int width;
	private int PM;

	public Heroe(string n, int[] p, string file, int width, int height, int PM)
    {
        nom = n;
        x = p[1];
		y = p [0];
        fichierHero = file;
		this.width = width;
		this.height = height;
		this.PM = PM;
    }

    public int[] getPosition()
    {
		return new int[] {x,y};
    }

	public void setPosition(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

    public string getImage()
    {
        return fichierHero;
    }

	public int getWidth()
	{
		return width;
	}
	public int getHeight()
	{
		return height;
	}

	public int getPM()
	{
		return PM;
	}

}
