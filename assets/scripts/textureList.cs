using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class textureList{

	/*
	 * 		C'est ici que sont contenues toutes les textures nécessaire pour le jeu.
	 * 		Pour vulgariser, il s'agit de l'annuaire des textures.
	 * 
	 * 
	 */

	private static List<descrTexture> annuaireTextures = new List<descrTexture>() ;
	private static descrTexture DEFAULT;

	public static void initTexture(){

		//Fonction qui initie l'annuaire et ajoute ces textures

		ajouteTexture ("EAU","Une texture d'eau", "aqua", true, ItemTypes.TypesCases.EAU);
		ajouteTexture ("SAND","Texture de sable", "sand", false, ItemTypes.TypesCases.SABLE);
		ajouteTexture("SANDGRASS", "Sable et herbe", "sandGrass", false, ItemTypes.TypesCases.SABLE);

		//Si les recherches ne trouvent rien, on renvoie ça
		DEFAULT = new descrTexture ("DEFAULT", "Texture par defaut", "sandGrass", false, ItemTypes.TypesCases.SABLE);

	}

    //Permet d'ajouter une texture
	public static void ajouteTexture(string n, string d, string f, bool b, ItemTypes.TypesCases t){

        annuaireTextures.Add(new descrTexture(n, d, f, b, t));

	}

	public static string getFichierTexture(string nom){

		foreach (descrTexture texture in annuaireTextures) {
			if (texture.getNom () == nom) {
				
				return texture.getFile ();
			}

		}

		return DEFAULT.getFile();

	}

	public static descrTexture getTextureParNom(string nom)
	{
		
		foreach (descrTexture texture in annuaireTextures) {

			if (texture.getNom().Equals(nom)) {
				return texture;
			}

		}

		return DEFAULT;

	}

	public static void annuaireToString(){

		for (int i=0; i<annuaireTextures.Count; i++) {

			Debug.Log (i+": "+annuaireTextures[i].getNom()+", "+annuaireTextures[i].getDescr()+" ( "+annuaireTextures[i].getFile()+" )");
		}

	}

	public static descrTexture getTextureAleatoire()
	{

		int i = Random.Range(0, annuaireTextures.Count );
		return annuaireTextures [i];


	}

}

public class descrTexture{

	private string nom;
	private string description;
	private string fichier; //fichier sans l'extension
	private bool bloquante;
	private ItemTypes.TypesCases type;

	public descrTexture(string nom, string descr, string fichier, bool b, ItemTypes.TypesCases t){

		this.nom = nom;
		this.description = descr;
		this.fichier = fichier;
		this.bloquante = b;
		this.type = t;
	
	}

	public string getFile(){
		return this.fichier;
	}
	public string getNom(){
		return this.nom;
	}
	public string getDescr(){
		return this.description;
	}
	public bool getBlocante()
	{
		return this.bloquante;
	}
	public ItemTypes.TypesCases getType()
	{
		return this.type;
	}
		
}





























