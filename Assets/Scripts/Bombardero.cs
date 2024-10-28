using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Bombardero : Player
{
    float tiempoPulsacionActual = 0f;
    bool dedoPulsado = false;
    public override void Bombardear()
    {
        base.Bombardear();
        dedoPulsado = (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Stationary) ? true : false;
        if (dedoPulsado)
        {
            tiempoPulsacionActual += Time.deltaTime;
        }
        else
        {
            tiempoPulsacionActual = 0f;
        }
        if (tiempoPulsacionActual >= tiempoPulsacionRequerido)
        {
            InstanciarObjeto();
        }
        imagenLlenadoRadial.fillAmount = tiempoPulsacionActual / tiempoPulsacionRequerido;
    }
    void InstanciarObjeto()
    {
        Instantiate(bombaPrefab, transform.position, Quaternion.identity);
        tiempoPulsacionActual = 0f;
    }
}