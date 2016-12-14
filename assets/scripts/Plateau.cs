using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Plateau{

	//Le plateau n'est rien autre qu'un tableau de Case.

	private int hauteur;
	private int largeur;
	private Case[,] plateau;

	public Plateau(int haut, int lar){
		this.hauteur = haut;
		this.largeur = lar;
		plateau = new Case[haut, lar];
		initiePlateau ();
	}

	public void initiePlateau(){

		int max = Variables.getMaxHeight ();

		for (int i =0; i<hauteur; i++) {
			
			for (int j=0; j<largeur; j++) {

				plateau [i, j] = new Case ();

				//Ici on va gérer les hauteurs des cases
				plateau [i, j].setLevel (Random.Range (0, max));

				//Textures
				plateau [i, j].setTexture (textureList.getTextureAleatoire ());
				plateau [i, j].addItemAleatoire ();

			}
		}
	}

	public Case[,] getCases()
	{
		return this.plateau;
	}
	public Case getCase(int x, int y)
	{
		return this.plateau [x, y];
	}

	public void setCase(int i, int j, bool sp, descrTexture type){

		//défini telle case à tel emplacement

		//On passe l'ancien spawn à false;
		if (sp == true) {
			for (int h =0; h < this.hauteur; h++) {

				for (int l=0; l<largeur; l++) {
					
					if(plateau[h,l].getSpawn()){
						plateau[h,l].setSpawn(false);
					}
					
				}
			}
		}

		plateau[i,j].setTexture(type);

	}

	public void toString(){
		string res = "";

		for (int i =0; i<hauteur; i++) {

						for (int j=0; j<largeur; j++) {
								
							res += plateau[i,j].getTexture().getNom(); 

						}
				res += "\r\n";

		}
		Debug.Log (res);
	}

	public void materializePlateau(){
		float caseSize = Variables.getCaseSize();
		int level = 0;
		float coeffHauteur = Variables.getCoeffHauteur();
		for (int i =0; i<hauteur; i++) {

			for (int j=0; j<largeur; j++) {

				//Création de l'objet Plane
				GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Quad);
                plane.name = "case" + i + ":" + j;

				level = plateau [i, j].getLevel ();

				plane.transform.localScale = new Vector3(1f,1f,1f);
				plane.transform.position = new Vector3 (j,(coeffHauteur * (float)level) ,i);
				plane.transform.Rotate(90, 0, 0);

				//On crée le cube qui accompagne le dessous des cases
				//Valable pour les cases de level>0
				if (level > 0) {
					GameObject under = GameObject.CreatePrimitive (PrimitiveType.Cube);
					under.name = "under" + i + ":" + j;
					under.transform.localScale = new Vector3 (1f, coeffHauteur * (float)level - 0.005f, 1f);
					under.transform.position = new Vector3 (j,plane.transform.position.y / 2 ,i);

					Material underMat = new Material(Shader.Find("Diffuse"));
					underMat.color = Variables.getPlateauMainColor();
					under.GetComponent<Renderer>().material = underMat;

				}

				//Création d'un shader pour le plane
				Material mat = new Material(Shader.Find("Diffuse"));
				string nomTexture = plateau[i,j].getTexture().getNom();
				string fichierTexture = textureList.getFichierTexture(nomTexture);
				mat.mainTexture = (Texture2D)Resources.Load(fichierTexture,typeof(Texture2D));
				mat.SetTextureScale ("_MainTex",new Vector2(1,1));

				plane.GetComponent<Renderer>().material = mat;

				//Afficher les items
				materializeItemCases (plateau [i, j], i, j);
		
			}

		}

		//Création du plateau en dessous 
		GameObject bottom = GameObject.CreatePrimitive (PrimitiveType.Cube);
		bottom.transform.localScale = new Vector3 ((largeur *5), 0.2f,(hauteur * 5));

		float larg = largeur - 1;
		float haut = hauteur - 1;

		bottom.transform.position = new Vector3 (larg/2, -0.11f, haut/2);
		Material matBottom = new Material(Shader.Find("Diffuse"));
		matBottom.color = Variables.getPlateauMainColor();
		bottom.GetComponent<Renderer>().material = matBottom;


	}

	public void materializeItemCases(Case c, int x, int z)
	{
		List<InterfaceItem> list = c.getItems ();
		float caseSize = Variables.getCaseSize ();
		float coeffHauteur = Variables.getCoeffHauteur();

		if (list != null) 
		{
			//Si les items ne sont pas vides, on les crée:
			foreach (InterfaceItem item in list) 
			{
				if (item.getType () == c.getTexture().getType()) {

					//On crée le plan
					GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Quad);
					float ratio = item.getWidth() / (float)item.getHeight();
					//Calcul de la taille de l'element
					if(ratio < 1)
						plane.transform.localScale = new Vector3 (1f * ratio* item.getFacto(), 1f* item.getFacto(), 1f* item.getFacto());
					else
						plane.transform.localScale = new Vector3 (1f * item.getFacto(), 1f / ratio * item.getFacto(), 1f * item.getFacto());
					
					plane.transform.localPosition = new Vector3 (z, (c.getLevel() * coeffHauteur) + (plane.transform.localScale.y / 2f), x);

					//Shader
					Material mat = new Material(Shader.Find("Transparent/Diffuse"));
					string nomTexture = item.getFichier();
					mat.mainTexture = (Texture2D)Resources.Load(nomTexture,typeof(Texture2D));
					mat.SetTextureScale ("_MainTex",new Vector2(1,1));

					plane.GetComponent<Renderer>().material = mat;

					c.addGameObjectOnCase (plane);

				} else {

					Debug.Log ("Erreur, type de Case/Texture incompatible : " + c.getTexture().GetType()+"/"+item.GetType ());

				}

			}

		}

	}



}



























