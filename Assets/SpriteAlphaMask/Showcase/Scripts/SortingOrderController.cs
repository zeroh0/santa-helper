using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gcaseres.SpriteAlphaMask.Showcase {
	[RequireComponent(typeof(Renderer))]
	[ExecuteInEditMode]
	public class SortingOrderController : MonoBehaviour {

		private new Renderer renderer;
	
		void OnEnable () {
			this.renderer = this.GetComponent<Renderer> ();
		}
		

		void Update () {
			this.renderer.sortingOrder = -(int)this.transform.position.y / 4;
		}


	}
}