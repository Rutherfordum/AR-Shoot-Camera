using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAndroid : MonoBehaviour {
	//Настройки Зума
	[Header("ZOOM SETINGS")] public bool ActivateZoom;
	[Space(5f)]
	public GameObject Subject;
	[Range(0.5f,1f)][Tooltip("Минимальное значение размера обьекта")]
	public float Min=0.5f;
	[Range(1f,5f)][Tooltip("Максимальное значение размера обьекта")]
	public float Max=5f;
	[Range(0.01f,1f)][Tooltip("Чувствительность зума")]
	public float SensitivityZoom=0.1f;
	Vector3 Target;
	float DependetValue;

	//Настройки Ротации
	[Space(10f)][Header("ROTATION SETTINGS")]public bool ActivateRotate;
	[Space(5f)]
	[Range(0.01f,1f)][Tooltip("Чувствительность вращения")]
	public float SensitivityRotate=0.1f;
	float Xrotate;
    int w;
    public GameObject MenuUI;

    public void ResetMenu()
    {
        w = 0;
    }

    public void OpenClouseMenu()
    {
        w += 1;
        if (w == 1)
        {
            MenuUI.SetActive(true);
        }
        if (w == 2)
        {
            MenuUI.SetActive(false);
            w = 0;
        }
    }

    void FixedUpdate(){
        MoveRotateObject();
        ScaleObject();
	}

    void MoveRotateObject()
    {
        if (ActivateRotate == true)
        {
            if (Input.touchCount == 1)
            {
                Touch one1 = Input.GetTouch(0);
                Vector2 PosOne1 = one1.position - one1.deltaPosition;
                float x = PosOne1.x - one1.position.x;
                Xrotate += x;
                Subject.transform.localRotation = Quaternion.Euler(0, Xrotate * SensitivityRotate, 0);
            }
        }
    }
    void ScaleObject()
    {
        if (ActivateZoom == true)
        {
            if (Input.touchCount == 2)
            {
                Touch zero = Input.GetTouch(0);
                Touch one = Input.GetTouch(1);
                Vector2 PosOne = one.position - one.deltaPosition;
                Vector2 PosZero = zero.position - zero.deltaPosition;
                float MagnOneAndTwo = (PosZero - PosOne).magnitude; //растояние между двумя точками т.е. находим его вектор
                float MagnOneAndTwoPos = (zero.position - one.position).magnitude;// также находим вектор толлько в зависимостит от касания это надо для обнуления координат 
                float Difference = MagnOneAndTwo - MagnOneAndTwoPos;//обнуление, это делается для того, чтобы при нажатиии повторный раз в другие позиции наш обьект не принемал их как новые а старался из исходного состояния изменять рамер
                DependetValue -= Difference / 100;
                if (DependetValue < Min)
                {
                    DependetValue = Min;
                }
                if (DependetValue > Max)
                {
                    DependetValue = Max;
                }
                Target = new Vector3(Mathf.Clamp(DependetValue, Min, Max), Mathf.Clamp(DependetValue, Min, Max), Mathf.Clamp(DependetValue, Min, Max));
                Subject.transform.localScale = Vector3.MoveTowards(Subject.transform.localScale, Target, SensitivityZoom);
            }
        }
    }
}
