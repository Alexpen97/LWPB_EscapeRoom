using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    public List<List<GameObject>> PlantList_prefabs;
    public List<GameObject> Arctium_lappa;
    [Range(0, 10)]
    public List<int> Arctium_lappa_nutrientvalue;
    public List<GameObject> Pteropsida;
    public List<GameObject> Ignis_Herba;
    public List<GameObject> Corona_Flos;
    public List<GameObject> Taraxacum;
    public List<GameObject> Pluma;
    public List<GameObject> Brassica_oleracea;
    public List<GameObject> harambe_plumbus;
    public List<GameObject> Zizania;
    public List<GameObject> Vrouwentong;
    public List<GameObject> Heracleum_sphondylium;
    public List<GameObject> Kopstekel_Flora;

    public enum PlantList
    {
        Arctium_lappa,
        Pteropsida,
        Ignis_Herba,
        Corona_Flos,
        Taraxacum,
        Pluma,
        Brassica_oleracea,
        harambe_plumbus,
        Zizania,
        Vrouwentong,
        Heracleum_sphondylium,
        Kopstekel_Flora
    }

    private void Start()
    {
        PlantList_prefabs.Add(Arctium_lappa);
        PlantList_prefabs.Add(Pteropsida);
        PlantList_prefabs.Add(Ignis_Herba);
        PlantList_prefabs.Add(Corona_Flos);
        PlantList_prefabs.Add(Taraxacum);
        PlantList_prefabs.Add(Pluma);
        PlantList_prefabs.Add(Brassica_oleracea);
        PlantList_prefabs.Add(harambe_plumbus);
        PlantList_prefabs.Add(Zizania);
        PlantList_prefabs.Add(Vrouwentong);
        PlantList_prefabs.Add(Heracleum_sphondylium);
        PlantList_prefabs.Add(Kopstekel_Flora);
    }


}

  

