using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{   //Inicio declaracion de variables 
	public GameObject prefab;
	public Transform point;
	public float livingTime;

    public void Instantiate()
	{
		GameObject instantiatedObject = Instantiate(prefab, point.position, Quaternion.identity) as GameObject;

		if (livingTime > 0f) 
		{
			Destroy(instantiatedObject, livingTime);
		}
	}
}
