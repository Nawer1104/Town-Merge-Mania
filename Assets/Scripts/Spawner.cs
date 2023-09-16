using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] childs;
    public GameObject prefabToSpawn;
    public static Spawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (GameManager.Instance.objects.Count > 3)
        {
            return;
        }

        foreach(Transform trans in childs)
        {
            GameObject green = Instantiate(prefabToSpawn, trans.position, Quaternion.identity) as GameObject;
            GameManager.Instance.objects.Add(green);
        }
    }

    public static List<GameObject> GetAllChilds(GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < Go.transform.childCount; i++)
        {
            list.Add(Go.transform.GetChild(i).gameObject);
        }
        return list;
    }
}
