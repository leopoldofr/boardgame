﻿using UnityEngine;

public class Main : MonoBehaviour {

	public int caseSize = 3;
	public Plateau plat;
	public static int[] spawn = { 3, 2 };
	Heroe heroe = new Heroe("Leo", spawn, "hero2", 357, 595,10);
	Case currentCase;

    // Use this for initialization
    void Awake(){

		Debug.Log ("Initialisation des textures...");
		textureList.initTexture ();

		Debug.Log ("Initialisation de la liste des éléments...");
		elemList.initItems ();
		//elemList.afficheListeItems ();

		Debug.Log ("Creation du plateau...");
		plat = new Plateau (50,50);

	}

	void Start () {

		Debug.Log ("Lancement des affichages...");
        Afficheur.afficheJeu(plat, heroe);
		currentCase = plat.getCase(heroe.getPosition ()[1],heroe.getPosition ()[0]);
		Debug.Log (heroe.getPosition ()[1]+" + " +heroe.getPosition ()[0]);
    }

	//GUI
	void OnGUI()
	{
		Actions.joueTour ();
	}

	// Update is called once per frame
	void Update () {
	
        //Permet d'actualiser les affichages
		Afficheur.updateItemsRotation (plat,heroe);
		if (Input.GetKey (KeyCode.Z)) {
			Vector3 vect = new Vector3 (0.2f, 0f, 0f);
			Camera.main.transform.position += vect;
		}
		if (Input.GetKey (KeyCode.S)) {
			Vector3 vect = new Vector3 (-0.2f, 0f, 0f);
			Camera.main.transform.position += vect;
		}
		if (Input.GetKey (KeyCode.Q)) {
			Vector3 vect = new Vector3 (0f, 0f, 0.2f);
			Camera.main.transform.position += vect;
		}
		if (Input.GetKey (KeyCode.D)) {
			Vector3 vect = new Vector3 (0f, 0f, -0.2f);
			Camera.main.transform.position += vect;
		}

        //Interaction Utilisateurs
        if (Input.GetMouseButtonDown(0))
        {
			Mouvements.deplaceHeroe(plat, Mouvements.UserClick(), heroe);
        }



    }


}
