using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gcaseres.SpriteAlphaMask.Core.Components;
using Gcaseres.SpriteAlphaMask.Core.Model;

namespace Gcaseres.SpriteAlphaMask.Showcase {
	[ExecuteInEditMode]
	[RequireComponent(typeof(AlphaMaskSprite))]
	public class AlphaMaskSpriteSortingOrderController : MonoBehaviour {

		public Renderer ReferenceRenderer;
		private AlphaMaskSprite alphaMaskSprite;
		public int Offset;

		void OnEnable () {
			this.alphaMaskSprite = this.GetComponent<AlphaMaskSprite> ();
		}

		void Update () {
			if (this.ReferenceRenderer != null) {
				this.alphaMaskSprite.SortingOrderInterval = new SortingOrderInterval (this.ReferenceRenderer.sortingOrder + this.Offset, this.alphaMaskSprite.SortingOrderInterval.To);			
			}

		}
	}
}