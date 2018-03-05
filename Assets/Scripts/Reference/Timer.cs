using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

	Image fillImg;
	float timeAmt = 2.5f;
	float time;
	float badTime;
	bool run;
	bool pause;

	// Use this for initialization
	void Start()
	{
		fillImg = this.GetComponent<Image>();
		time = timeAmt;
		run = false;
		pause = false;
		badTime = -3;
	}

	// Update is called once per frame
	void Update()
	{
		if (pause) return;
		if (run&&time > 0)
		{
			time -= Time.deltaTime;
			fillImg.fillAmount = time / timeAmt;
		}
		else if(time<=0)
		{
			this.transform.parent.gameObject.GetComponent<draggable>().setFinish(true);
			if (run)
			{
				if (time > badTime)
				{
					time -= Time.deltaTime;
				}
				else if(time <= badTime)
				{
					this.transform.parent.gameObject.GetComponent<Image>().sprite= this.transform.parent.gameObject.GetComponent<DishImage>().Wrong.GetComponent<SpriteRenderer>().sprite;
					this.transform.parent.gameObject.GetComponent<draggable>().setFinish(false);
					this.transform.parent.gameObject.GetComponent<DropMe>().setDish(Menu.Dish.Wrong);
				}
			}


		}
	}

	public void RunTime()
	{
		run = true;
	}

	public void ClearTime()
	{
		time = timeAmt;
		fillImg.fillAmount = 1;
		run = false;
		pause = false;
	}

	public void Pause()
	{
		pause = true;
	}



	public void Resume()
	{
		pause = false;
	}
}
