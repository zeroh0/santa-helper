using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gcaseres.SpriteAlphaMask.Showcase
{
	public class PlayerController : MonoBehaviour
	{
		void Update ()
		{
			if (Input.GetAxis ("Horizontal") != 0f || Input.GetAxis ("Vertical") != 0f) {
				float x = Input.GetAxis ("Horizontal") * Time.deltaTime * 60.0f;
				float y = Input.GetAxis ("Vertical") * Time.deltaTime * 60.0f;

				this.transform.position += new Vector3 (x, y, 0);
				this.GetComponent<Animator> ().SetBool ("running", true);
			} else {
				this.GetComponent<Animator> ().SetBool ("running", false);
			}
		}
	}
}