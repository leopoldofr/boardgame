using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Case{

	// La Case est l'unité de base sur le plateau de jeu.
	// Elle peut contenir: le spawn (limité à une seule case) et un code texture que l'on fixera
	// Il faut définir le nom de la texture par une chaine de caractère

	private bool spawn;
	private descrTexture texture;
	private List<InterfaceItem> itemsCase;
	private List<GameObject> gameObjects;
	private int level;

	//Constructeurs de Case

	public Case(){
		//constructeur de base, pas de spawn, texture à 1
		spawn = false;
		texture = textureList.getTextureParNom ("SAND");
		itemsCase =  new List<InterfaceItem>();
		gameObjects = new List<GameObject> ();
		level = 0;
	}

	public Case (descrTexture t)
	{
		spawn = false;
		texture = t;
		itemsCase =  new List<InterfaceItem>();
		gameObjects = new List<GameObject> ();
		level = 0;
	}

	public Case(bool sp, descrTexture t, List<InterfaceItem> items){
		spawn = sp;
		texture = t;
		itemsCase = items;
		level = 0;
	}

	//getters

	public bool getSpawn(){
		return this.spawn;
	}

	public int getLevel(){
		return this.level;
	}

	public descrTexture getTexture(){
		return this.texture;
	}

	//setters

	public void setSpawn(bool sp){
		//Ne pas oublier de parcourir le plateau pour enlever le Spawn initial
		Debug.Log("La case est maintenant le spawn");
		this.spawn = sp;
	}

	public void setTexture(descrTexture type){
		this.texture = type;
	}

	public void setLevel(int level){
		this.level = level;
	}

	//Annexes
	public void toString(){
		Debug.Log ("spawn : " + this.spawn + ", texture : " + this.texture.getNom());
	}

	public void addItemOnCase(InterfaceItem item)
	{
		if(item != null){
			itemsCase.Add(item);
		}
	}

	public void removeItemOnCase(InterfaceItem item)
	{
		itemsCase.Remove (item);
	}

	public List<InterfaceItem> getItems()
	{
		return itemsCase; 
	}

	public void addGameObjectOnCase(GameObject obj)
	{
		if(obj != null){
			gameObjects.Add(obj);
		}
	}

	public void removeGameObjectOnCase(GameObject obj)
	{
		gameObjects.Remove (obj);
	}

	public List<GameObject> getGameObjects()
	{
		return gameObjects; 
	}

	public void addItemAleatoire()
	{
		InterfaceItem item = elemList.getItemAleatoire (this.texture.getType ());
		this.addItemOnCase(item);
	}

}


























