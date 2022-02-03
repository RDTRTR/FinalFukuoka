using UnityEngine;
using TMPro;

[ExecuteInEditMode]
[RequireComponent(typeof(TextMeshPro))]
public class TextMeshProMaxVisibleCharaController : MonoBehaviour
{
	public int maxVisibleCharacters;
	private TextMeshPro text;

	private void Update()
	{
		if (this.text == null)
			this.text = GetComponent<TextMeshPro>();

		this.text.maxVisibleCharacters = this.maxVisibleCharacters;
	}
}