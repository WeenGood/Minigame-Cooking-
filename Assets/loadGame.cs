using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadGame : MonoBehaviour {

    static int quantity = 21;
    public GameObject[] allObjects = new GameObject[quantity];
    public GameObject quest;
    public int idRecipe;
    // Use this for initialization
    void Start ()
    {
        idRecipe = distribution();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    int distribution ()
    {
        Vector3[] places = new Vector3[quantity];
        places[0] = new Vector3(0, 1.3f, 0);
        places[1] = new Vector3(1, 0, 0);
        places[2] = new Vector3(0, 0, 1);
        places[3] = new Vector3(-1, 0, 0);
        places[4] = new Vector3(2, 0, 0);
        places[5] = new Vector3(-2, 0, 0);
        places[6] = new Vector3(3, 0, 0);
        places[7] = new Vector3(3, 0, 1);
        places[8] = new Vector3(3, 0, 2);
        places[9] = new Vector3(-1, 0, 2);
        places[10] = new Vector3(2, 0, 2);
        places[11] = new Vector3(-2, 0, 3);
        places[12] = new Vector3(-3, 0, 1);
        places[13] = new Vector3(-3, 0, 2);
        places[14] = new Vector3(-1, 0, -2);
        places[15] = new Vector3(-2, 0, 2);
        places[16] = new Vector3(-2, 0, -3);
        places[17] = new Vector3(3, 2, 3);
        places[18] = new Vector3(-3, 2, -2);
        places[19] = new Vector3(-4, 2, -2);
        places[20] = new Vector3(-3, 2, -4);
        for (int i = 0; i<places.Length; i++)
        allObjects[i] = Instantiate(allObjects[i], places[i], Quaternion.identity) as GameObject;

        int indexRecipe = Random.Range(0, 9);
        quest.GetComponent<TextMesh>().text = "Приготовь блюдо: " + GetComponent<cooking>().recipe[indexRecipe];
        Instantiate(quest, new Vector3(0, 3, 0), Quaternion.identity);
        return indexRecipe;
    }
}
