using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ColourPanel : MonoBehaviour {
	private Color[] Col=new Color[3];
	public  float LerpSpeed=1;
	private float _time;

	void Update() {
		_time += Time.deltaTime;
		Col[0] = Color.Lerp (Col[1], Col[2], _time* LerpSpeed);
		if (Col[0] == Col[2]) {
			Col[1]=Col[2];
			Col[2] = new Color (Random.value,Random.value,Random.value);
			_time=0;
		}
		GetComponent<Image> ().color = Col[0];
		}
	}
