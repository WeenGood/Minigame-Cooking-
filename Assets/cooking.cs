using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class cooking : MonoBehaviour {

    GameObject pan;
    public string[] recipe = {"Гречка с яйцом", "Картошка с мясом", "Борщ", "Рис с огурцом", "Овсянка с бананом", "Салат","Яичница", "Винегрет", "Доширак", "Гороховую кашу" };
    public List<GameObject> inPan2;
    public List<GameObject> egg;
    public List<GameObject> potato;
    public List<GameObject> soup;
    public List<GameObject> rice;
    public List<GameObject> oatmeal;
    public List<GameObject> salad;
    public List<GameObject> omelette;
    public List<GameObject>  vinaigrette;
    public List<GameObject> doshik;
    public List<GameObject> peas;
    public List<GameObject>[] a = new List<GameObject>[10];
    
    public GameObject cam;
    // Use this for initialization
    void Start () {
        pan = GameObject.Find("pan(Clone)");
        cam = GameObject.Find("Main Camera");
        egg.Add(cam.GetComponent<loadGame>().allObjects[3]);//3 - гречка
        egg.Add(cam.GetComponent<loadGame>().allObjects[6]);//6 - яйцо

        potato.Add(cam.GetComponent<loadGame>().allObjects[8]);//8 - мясо
        potato.Add(cam.GetComponent<loadGame>().allObjects[12]);// 12 - картоха

        soup.Add(cam.GetComponent<loadGame>().allObjects[12]);
        soup.Add(cam.GetComponent<loadGame>().allObjects[5]);//5 - морковь
        soup.Add(cam.GetComponent<loadGame>().allObjects[8]);
        soup.Add(cam.GetComponent<loadGame>().allObjects[1]);//1 - свекла
        soup.Add(cam.GetComponent<loadGame>().allObjects[4]);//4 - капуста

        rice.Add(cam.GetComponent<loadGame>().allObjects[13]);//13 - рис
        rice.Add(cam.GetComponent<loadGame>().allObjects[17]);//17 - огурец

        oatmeal.Add(cam.GetComponent<loadGame>().allObjects[9]);//9 - овсянка
        oatmeal.Add(cam.GetComponent<loadGame>().allObjects[19]);//19 - банан

        salad.Add(cam.GetComponent<loadGame>().allObjects[17]);
        salad.Add(cam.GetComponent<loadGame>().allObjects[18]);//18 - помидор
        salad.Add(cam.GetComponent<loadGame>().allObjects[4]);

        omelette.Add(cam.GetComponent<loadGame>().allObjects[6]);

        vinaigrette.Add(cam.GetComponent<loadGame>().allObjects[12]);
        vinaigrette.Add(cam.GetComponent<loadGame>().allObjects[5]);
        vinaigrette.Add(cam.GetComponent<loadGame>().allObjects[10]);
        vinaigrette.Add(cam.GetComponent<loadGame>().allObjects[17]);
        vinaigrette.Add(cam.GetComponent<loadGame>().allObjects[4]);
        
        doshik.Add(cam.GetComponent<loadGame>().allObjects[20]);

        peas.Add(cam.GetComponent<loadGame>().allObjects[11]);

        a[0] = egg.OrderBy(go => go.name).ToList();
        a[1] = potato.OrderBy(go => go.name).ToList();
        a[2] = soup.OrderBy(go => go.name).ToList();
        a[3] = rice.OrderBy(go => go.name).ToList();
        a[4] = oatmeal.OrderBy(go => go.name).ToList();
        a[5] = salad.OrderBy(go => go.name).ToList();
        a[6] = omelette.OrderBy(go => go.name).ToList();
        a[7] = vinaigrette.OrderBy(go => go.name).ToList();
        a[8] = doshik.OrderBy(go => go.name).ToList();
        a[9] = peas.OrderBy(go => go.name).ToList();
    }
	
	// Update is called once per frame
	void Update () {
            checkIn();
    }
    void checkIn()
    {
        int idRecipe = cam.GetComponent<loadGame>().idRecipe;
        inPan2 = pan.GetComponent<trigger>().inPan.OrderBy(go => go.name).ToList();
        if (inPan2.SequenceEqual(a[0]) && idRecipe == 0)
        {
            GameObject.Find("text(Clone)").GetComponent<TextMesh>().text = "Гречка с яйцом готова!";
        }
        if (inPan2.SequenceEqual(a[1]) && idRecipe == 1)
            {
                GameObject.Find("text(Clone)").GetComponent<TextMesh>().text = "Картошка с мясом готова!";
            }
        if (inPan2.SequenceEqual(a[2]) && idRecipe == 2)
            {
                GameObject.Find("text(Clone)").GetComponent<TextMesh>().text = "Борщ готов!";
            }
        if (inPan2.SequenceEqual(a[3]) && idRecipe == 3)
            {
                GameObject.Find("text(Clone)").GetComponent<TextMesh>().text = "Рис с огурцом готов!";
            }
        if (inPan2.SequenceEqual(a[4]) && idRecipe == 4)
        {
            GameObject.Find("text(Clone)").GetComponent<TextMesh>().text = "Овсянка с бананом готова!";
        }
        if (inPan2.SequenceEqual(a[5]) && idRecipe == 5)
            {
                GameObject.Find("text(Clone)").GetComponent<TextMesh>().text = "Салат готов!";
            }
        if (inPan2.SequenceEqual(a[6]) && idRecipe == 6)
            {
                GameObject.Find("text(Clone)").GetComponent<TextMesh>().text = "Яичница готова!";
            }
        if (inPan2.SequenceEqual(a[7]) && idRecipe == 7)
            {
                GameObject.Find("text(Clone)").GetComponent<TextMesh>().text = "Винегрет готов!";
            }
        if (inPan2.SequenceEqual(a[8]) && idRecipe == 8)
            {
                GameObject.Find("text(Clone)").GetComponent<TextMesh>().text = "Дошик готов!";
            }
        if (inPan2.SequenceEqual(a[9]) && idRecipe == 9)
            {
                GameObject.Find("text(Clone)").GetComponent<TextMesh>().text = "Гороховая каша готова!";
            }
    }

}
