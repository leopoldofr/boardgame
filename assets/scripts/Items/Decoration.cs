using UnityEngine;
using System.Collections;

/*	Decoration, element de base à la décoration,
 * pas d'interaction possible
 */


public class Decoration : InterfaceItem{

	private string nom;
	private string description;
	private string fichier;
	private int width;
	private int height;
	private ItemTypes.TypesCases type;
	private ItemTypes.ItemOrientation orientation;
	private float facto;

	public Decoration(string nom, string description, string fichier, int width, int height, ItemTypes.TypesCases type, ItemTypes.ItemOrientation orientation, float fct)
	{
		this.nom = nom;
		this.description = description;
		this.fichier = fichier;
		this.width = width;
		this.height = height;
		this.type = type;
		this.orientation = orientation;
		this.facto = fct;
	}

    /*Les getters et les setters */

	public string getNom()
	{
		return this.nom;
	}

	public string getFichier()
	{
		return this.fichier;
	}

	public string getDescr()
	{
		return this.description;
	}

	public int getWidth()
	{
		return this.width;
	}

	public int getHeight()
	{
		return this.height;
	}
	public ItemTypes.TypesCases getType()
	{
		return this.type;
	}
	public ItemTypes.ItemOrientation getOrientation()
	{
		return this.orientation;
	}
	public float getFacto(){
		return this.facto;
	}
}
