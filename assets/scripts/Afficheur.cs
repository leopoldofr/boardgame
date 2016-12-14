using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public static class Afficheur {

	//Affiche le jeu total
    public static void afficheJeu(Plateau p, Heroe h)
    {
        affichePlateau(p);
        afficheHeroe(h);
		updateItemsRotation (p,h);
    }

	public static void updateItemsRotation(Plateau p,Heroe heroe)
	{
		Case[,] cases = p.getCases();
		List<GameObject> objs;

		int width = cases.GetLength(0);
		int height = cases.GetLength(1);
		for (int i = 0; i < width; i++) {

			for (int j = 0; j < height; j++) {

				objs = cases [i, j].getGameObjects ();
				foreach (GameObject obj in objs) 
				{

					//On fait la rotation des objets
					Quaternion newRotation = Quaternion.LookRotation((obj.transform.position - Camera.main.transform.position), new Vector3(0,1,1));
					newRotation.x = 0.0f;
					newRotation.z = 0.0f;
					obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, newRotation * Quaternion.Euler(new Vector3(0,0,0)) , Time.deltaTime * 20);

				}
			}
		}

        //mise à jour de l'affichage du héros
		int[] posHeroe = heroe.getPosition ();
		int level = p.getCase (posHeroe [0], posHeroe [1]).getLevel();
		GameObject h = GameObject.Find("Heroe");
		h.transform.position = new Vector3( heroe.getPosition()[1] ,0.5f + (level * Variables.getCoeffHauteur ()), heroe.getPosition()[0] );
        Quaternion hRotation = Quaternion.LookRotation((h.transform.position - Camera.main.transform.position), new Vector3(0, 1, 1));
        hRotation.x = 0.0f;
        hRotation.z = 0.0f;
        h.transform.rotation = Quaternion.Slerp(h.transform.rotation, hRotation * Quaternion.Euler(new Vector3(0, 0, 180)), Time.deltaTime * 20);

    }

    private static void affichePlateau(Plateau p)
    {
        p.materializePlateau();
    }

    private static void afficheHeroe(Heroe h)
    {
		int width = h.getWidth();
		int height = h.getHeight();
        string file = Application.dataPath + "/Resources/Heroes/";

        int[] pos = h.getPosition();
        file = file + h.getImage();
		Debug.Log (pos [0] + "," + pos [1]);

        //On va crée un plan correspond au héros
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Quad);
		plane.transform.localScale = new Vector3(1f * (height/width), 1f, Variables.getCaseSize());
        plane.transform.position = new Vector3(pos[0], 0.5f, pos[1]);
        plane.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f,180f));
        plane.name = "Heroe";

        //Création d'un shader pour le plane
        Material mat = new Material(Shader.Find("Transparent/Diffuse"));
        string fichierTexture = "Heroes/"+h.getImage();
        mat.mainTexture = (Texture2D)Resources.Load(fichierTexture, typeof(Texture2D));
        mat.SetTextureScale("_MainTex", new Vector2(-1, -1));

        plane.GetComponent<Renderer>().material = mat;

    }




}