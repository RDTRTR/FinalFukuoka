using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
	/// <summary>
	/// Õ“Ë‚µ‚½
	/// </summary>
	/// <param name="collision"></param>
	private void OnCollisionEnter(Collision collision)
	{
		// Õ“Ë‚µ‚½‘Šè‚ÉPlayerƒ^ƒO‚ª•t‚¢‚Ä‚¢‚é‚Æ‚«
		if (collision.gameObject.tag == "Player")
		{
			// “–‚½‚Á‚½‘Šè‚ğ1•bŒã‚Éíœ
			Destroy(collision.gameObject, 1.0f);
		}
	}
}