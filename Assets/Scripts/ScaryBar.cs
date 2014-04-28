using UnityEngine;
using System.Collections;

public class ScaryBar : MonoBehaviour {


    Vector2 positionOnScreen;
    Rect rect;
    int width = 0;
    int backWidth = 35;
    int backHeight = 10;
    int height = 8;
    float ratio;
    public Texture healthBar;
    public Texture barFrame;

	void Start () 
	{
        ratio = (float)100 / backWidth; 
	}
	
	void Update () 
	{
        width = Mathf.CeilToInt(gameObject.GetComponent<NPC_AI>().fearLevel);
        if (width > 100)
        {
            width = 100;
        }
    }

    void OnGUI()
    {
        positionOnScreen.x = Camera.main.WorldToScreenPoint(transform.position).x;
        positionOnScreen.y = Screen.height - (Camera.main.WorldToScreenPoint(transform.position).y + 15);

        GUI.DrawTexture(new Rect(positionOnScreen.x - backWidth / 2, positionOnScreen.y - backHeight / 2, backWidth, backHeight), barFrame);
        GUI.DrawTexture(new Rect(positionOnScreen.x - backWidth / 2, positionOnScreen.y - height / 2, width / ratio, height), healthBar, ScaleMode.ScaleAndCrop);  
	}


}
