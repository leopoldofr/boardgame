using UnityEngine;
using System.Collections;

//Interface pour tous les items
public interface InterfaceItem {

	string getNom();
	string getFichier();
	string getDescr();
	ItemTypes.TypesCases getType ();
	ItemTypes.ItemOrientation getOrientation();
	int getWidth();
	int getHeight();
	float getFacto();


}
