using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

	public bool on;

	public bool visible = false;
	private int frames = 20;
	private int counter = 0;
	private Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
		transform.localScale = new Vector3(4f, 4f, 4f);
	}

	// Update is called once per frame
	void Update ()
	{
		if (on == true && visible == false)
		{	//fade in
			if (counter < frames)
			{
				counter++;
				image.color = new Color(1f,1f,1f,((float)counter / (float)frames));
				transform.localScale -= new Vector3(0.1f,0.1f,0.1f);
			}
			if (counter == frames)
			{
				image.color = new Color(1f,1f,1f,1f);
				visible = true;
			}
		}
		else if (on == false && visible == true)
		{	//fade out
			if (counter > 0)
			{
				counter--;
				image.color = new Color(1f,1f,1f,((float)counter / (float)frames));
				transform.localScale += new Vector3(0.1f,0.1f,0.1f);
			}
			if (counter == 0)
			{
				image.color = new Color(1f,1f,1f,0f);
				visible = false;
			}
		}
		else if (on == true && visible == true)
		{
			transform.localScale = new Vector3(2f,2f,2f);
			image.color = new Color(1f,1f,1f,1f);
		}
		else
		{
			transform.localScale = new Vector3(4f,4f,4f);
			image.color = new Color(1f,1f,1f,0f);
		}
	}
}
