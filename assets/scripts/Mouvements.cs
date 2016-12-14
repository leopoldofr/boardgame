using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/*
 *  Ce script concerne les Interactions Utilisateurs sur les mouvements
 *  des personnages 
 * 
 */

public class Mouvements : MonoBehaviour {

	
    //Permet de détecter le click utilisateur
    public static List<GameObject> UserClick()
    {
        Debug.Log("Tu as clické !");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit[] elems = Physics.RaycastAll(ray);
        List<GameObject> caseFull = new List<GameObject>();
        foreach(RaycastHit h in elems)
        {
          GameObject e = h.collider.gameObject;
            caseFull.Add(e);
        }


        return caseFull;
         

    }


    //Permet de déplacer le héros sur la case cible
    public static void deplaceHeroe(List<GameObject> caseFull)
    {
        int[] coords = { -1, -1 };
        string nom = "";
        foreach(GameObject e in caseFull)
        {

            if(e.name.Contains("case"))
            {
                nom = e.name.Replace("case", "");
                coords[0] = int.Parse(nom.Substring(0, nom.IndexOf(":")));
                coords[1] = int.Parse(nom.Substring(nom.IndexOf(":") + 1));
                break;
            }


        }

        Debug.Log(coords[0] + ", " + coords[1]);


    } 



}
