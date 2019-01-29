using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAndroid : MonoBehaviour
{
    static float Xrotate;
    static float DependetValue;

#if (UNITY_ANDROID || UNITY_IOS)

    #region rotation of an object around its axis
    public static void MoveRotateObject(GameObject Object, float sensitivity)
    {
        if (Input.touchCount == 1)
        {
            Touch one1 = Input.GetTouch(0);
            Vector2 PosOne1 = one1.position - one1.deltaPosition;
            float x = PosOne1.x - one1.position.x;
            Xrotate += x;
            Object.transform.localRotation = Quaternion.Euler(0, Xrotate * sensitivity, 0);
        }
    }
    #endregion

    #region object resizing
    public static void ScaleObject(GameObject Object, float MinSize, float MaxSize, float sensitivity)
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
            if (DependetValue < MinSize)
            {
                DependetValue = MinSize;
            }
            if (DependetValue > MaxSize)
            {
                DependetValue = MaxSize;
            }
            Vector3 Target = new Vector3(Mathf.Clamp(DependetValue, MinSize, MaxSize), Mathf.Clamp(DependetValue, MinSize, MaxSize), Mathf.Clamp(DependetValue, MinSize, MaxSize));
            Object.transform.localScale = Vector3.MoveTowards(Object.transform.localScale, Target, sensitivity);
        }

    }
    #endregion

#endif
}
