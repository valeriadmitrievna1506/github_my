using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireShotScript : MonoBehaviour
{
	public float speed = 10; // скорость пули
	public Rigidbody2D bullet; // префаб нашей пули
	public Transform gunPoint; // точка рождения
	public float fireRate = 1; // скорострельность
	public bool facingRight = true; // направление
	private float curTimeout;

	public int fullGunMagazine = 10; // полный магазин
	public int currentGunMagazine; // текущий магазин
	public Text gunMagazine; // текст

	void Start()
	{
		currentGunMagazine = 10;
	}

	void Update()
	{
		gunMagazine.text = currentGunMagazine.ToString() + " / " + fullGunMagazine.ToString();
		if (Input.GetMouseButton(0))
		{
			if (currentGunMagazine > 0)
			{
				Fire();
			}
		}
		else
		{
			curTimeout = 100;
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			currentGunMagazine = fullGunMagazine;
			SoundEffector.Instance.MakeReChargeSound();
		}
	}

	void Fire()
	{
		curTimeout += Time.deltaTime;
		if (curTimeout > fireRate)
		{
			curTimeout = 0;
			Rigidbody2D clone = Instantiate(bullet, gunPoint.position, Quaternion.identity) as Rigidbody2D;
			clone.velocity = transform.TransformDirection(gunPoint.right * speed * direction());
			clone.transform.right = gunPoint.right;
			currentGunMagazine -= 1;
			SoundEffector.Instance.MakeShootSound();
		}
	}

	int direction ()
	{
		bool is_right = gameObject.GetComponent<PlayerBS>().isRight;
		if (is_right) return 1;
		else return -1;
	}

}
