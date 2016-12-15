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
	public static void deplaceHeroe(Plateau p, List<GameObject> caseFull, Heroe heroe)
    {
        int[] caseAddr = { -1, -1 };
        string nom = "";
        foreach(GameObject e in caseFull)
        {
            if(e.name.Contains("case"))
            {
                nom = e.name.Replace("case", "");
                caseAddr[0] = int.Parse(nom.Substring(0, nom.IndexOf(":")));
                caseAddr[1] = int.Parse(nom.Substring(nom.IndexOf(":") + 1));
                break;
            }
			if(e.name.Contains("under"))
			{
				nom = e.name.Replace("under", "");
				caseAddr[0] = int.Parse(nom.Substring(0, nom.IndexOf(":")));
				caseAddr[1] = int.Parse(nom.Substring(nom.IndexOf(":") + 1));
				break;
			}
        }
		Debug.Log ("Clicked = " + caseAddr [0] + ", " + caseAddr [1]);

		//Si la case n'existe pas, on return
		if (caseAddr [0] == -1)
			return;

		int PM = heroe.getPM ();
		int x = heroe.getPosition () [0];
		int y = heroe.getPosition () [1];

		while (PM > 0 && (x != caseAddr[0] || y != caseAddr[1])) 
		{

			if (Mathf.Abs (x - caseAddr [0]) >= Mathf.Abs (y - caseAddr [1])) {

				if (x - caseAddr [0] > 0)
					x = x - 1;
				else
					x = x + 1;

			} else {
				if (y - caseAddr [1] > 0)
					y = y - 1;
				else
					y = y + 1;
			}
			heroe.setPosition (x, y);
			PM = PM - 1;
			Debug.Log ("PM = " + PM);
		}
		Debug.Log ("GC = " + x + ", " + y);
     
    } 
		
}
