using UnityEngine;

class ColorChangable : MonoBehaviour, IColorChangable
{
    public void ChangeColor(Color color)
    {
        // ‚±‚±‚ÅF‚ğ•Ï‚¦‚éˆ—‚ğ‚·‚éB
        Debug.Log("change color to " + color);
    }
}