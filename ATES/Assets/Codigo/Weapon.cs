using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	//Inicio declaracion de variables 
	public GameObject bulletPrefab;
	public GameObject shooter;
	private Transform _firePoint;



	void Awake()
	{
		_firePoint = transform.Find("FirePoint");
	}

	

	public void Shoot()
	{
		if (bulletPrefab != null && _firePoint != null && shooter != null) {
			GameObject myBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;

			Bullet bulletComponent = myBullet.GetComponent<Bullet>();

			if (shooter.transform.localScale.x < 0f) {
				// Izquierda
				bulletComponent.direction = Vector2.left; // nuevo Vector2(-1f, 0f)
			} else {
				// Derecha
				bulletComponent.direction = Vector2.right; // nuevo Vector2(1f, 0f)
			}
		}
	}
}
