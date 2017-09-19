using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalFlock : MonoBehaviour {
    public GameObject cubePrefab;
    public static int tankSize = 5;
    static int numcube = 10;
    public static GameObject[] allCube = new GameObject[numcube];
    

    // Use this for initialization
    void Start () {
		for(int i =0; i< numcube; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tankSize, tankSize), Random.Range(-tankSize, tankSize), Random.Range(-tankSize, tankSize));
            allCube[i] = (GameObject)Instantiate(cubePrefab, pos, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
