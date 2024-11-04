using UnityEngine.Events;
using UnityEngine;

public class TouchSlide : MonoBehaviour
{
    public static Touch touchInput;
    public static Vector2 touchStartPos, touchLastPos;
    public static Vector2 screenResolution;
    public static float minimoPorcentajeDesplazamiento = 0.1f; // 10 porciento de ancho o alto
    public UnityEvent onRightSlide, onLeftSlide, onUpSlide, onDownSlide;
    public virtual void Movimiento() { }
    public void ChequearTipoDeTouch(Vector3 startPos, Vector3 endPos)
    {
        float deltaX = endPos.x - startPos.x;
        float deltaY = endPos.y - startPos.y;


        float porcentajeDesplazamientoX = Mathf.Abs(deltaX) / screenResolution.x;
        float porcentajeDesplazamientoY = Mathf.Abs(deltaY) / screenResolution.y;


        if (porcentajeDesplazamientoX < minimoPorcentajeDesplazamiento && porcentajeDesplazamientoY < minimoPorcentajeDesplazamiento)
        {
            //print("se movio muy poquito");
            return;
        }



        if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
        {
            if (deltaX > 0)
            {
                //print("derecha");
                onRightSlide.Invoke();
            }
            else
            {
                //print("izquierda");
                onLeftSlide.Invoke();
            }

        }
        else
        {
            if (deltaY > 0)
            {
                //print("arriba");
                onUpSlide.Invoke();
            }
            else
            {
                //print("abajo");
                onDownSlide.Invoke();
            }
        }
    }
}