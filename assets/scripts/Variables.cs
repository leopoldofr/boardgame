using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Variables{

	/* Les variables ici ne sont pas faites pour etre modifiée durant 
	 * l'exécution du programme
	 */

	private static float caseSize = 0.1f;
	private static int MAX_HEIGHT_CELL = 3;
	private static Color32 mainColor= new Color32(219, 192, 134,1);
	private static float offsetHauteur = 0.1f;
	private static float coeffHeroe = 0.5f;

	public static float getCaseSize()
	{
		return caseSize;
	}
	public static int getMaxHeight()
	{
		return MAX_HEIGHT_CELL;
	}
	public static Color32 getPlateauMainColor()
	{
		return mainColor;
	}

	public static float getCoeffHauteur()
	{
		return offsetHauteur;
	}

	public static float getCoeffHeroe()
	{
		return coeffHeroe;
	}

}
