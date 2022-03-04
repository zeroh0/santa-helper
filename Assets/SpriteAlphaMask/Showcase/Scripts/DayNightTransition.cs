using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gcaseres.SpriteAlphaMask.Showcase
{
	public class DayNightTransition : MonoBehaviour
	{

		private bool opening = true;

		// Update is called once per frame
		void Update ()
		{
			if (opening) {
				if (this.transform.localScale.x < 20) {
					this.transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
				} else {
					opening = !opening;
				}
			} else {
				if (this.transform.localScale.x > 0) {
					this.transform.localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
				} else {
					opening = !opening;
				}
			}
		}
	}
}