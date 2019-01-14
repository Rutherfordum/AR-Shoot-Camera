using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ManagerSceneUI : MonoBehaviour {
	public int SceneID;
	public Slider SliderLoading;

	void Start(){
		StartCoroutine (Load ());
	}
	IEnumerator Load(){
		AsyncOperation operation = SceneManager.LoadSceneAsync (SceneID);
		while (!operation.isDone) {
			float progress = operation.progress/0.9f;
			SliderLoading.normalizedValue = progress;
			yield return null;
		}
	}
}
