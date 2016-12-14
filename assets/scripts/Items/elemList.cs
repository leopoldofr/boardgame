using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class elemList {

	private static List<InterfaceItem> itemList = new List<InterfaceItem>();

    //Permet d'ajouter un element physique au jeu
	private static void ajouteElem(InterfaceItem item)
	{
		itemList.Add(item);
	}

    //Initialisation des éléments du jeu
	public static void initItems()
	{
        
		InterfaceItem coffre = new Decoration ("coffre", "Element de base à tout RPG", "Items/coffreItem01", 1526, 953, ItemTypes.TypesCases.SABLE, ItemTypes.ItemOrientation.HAUT, 0.5f);
		InterfaceItem sandRock = new Decoration ("sandRock", "Roches de sable", "Items/sandRock", 1920, 1080, ItemTypes.TypesCases.SABLE, ItemTypes.ItemOrientation.HAUT, 1f);
		InterfaceItem herbePiquante = new Decoration ("herbePiquante", "Herbe de sable piquante", "Decoration/herbePiquante", 1920, 1080, ItemTypes.TypesCases.SABLE, ItemTypes.ItemOrientation.HAUT, 1f);

        //On les ajoutes
        ajouteElem(sandRock);
		ajouteElem (coffre);
		ajouteElem (herbePiquante);
	}

	public static void afficheListeItems()
	{
		string msg = "";
		foreach(InterfaceItem item in itemList)
		{
			msg = string.Concat(item.getNom()," : ",item.getDescr()," (fichier ",item.getFichier(),", ",item.getWidth(),"x",item.getHeight()," )\n");
			Debug.Log(msg); 
		}

	}

    //Retourne un élément par son nom
	public static InterfaceItem getItemByName(string n)
	{
		foreach (InterfaceItem item in itemList) {
			if (item.getNom () == n)
				return item;

		}

		return null;

	}

    //Retourne un élément aléatoire
	public static InterfaceItem getItemAleatoire(ItemTypes.TypesCases t)
	{
		//Ceci est la proba que l'aléatoire ne produise pas d'item
		int noItemFactor = -1;
		List<InterfaceItem> listTemp = new List<InterfaceItem> ();
		foreach (InterfaceItem item in itemList) {

			if (item.getType () == t) {

				listTemp.Add (item);
			}
		}

		if (listTemp.Count == 0 || listTemp == null) {
			return null;
		}

		int i = Random.Range (noItemFactor, listTemp.Count);
		if (i < 0) {
			return null;
		}

		return listTemp [i];

	}



}
	