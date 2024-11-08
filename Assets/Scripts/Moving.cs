using UnityEngine;

public class Moving : TouchSlide
{
    private void Update()
    {
        this.Movimiento();
    }
    public override void Movimiento()
    {
        base.Movimiento();
        screenResolution.x = Display.main.systemWidth;
        screenResolution.y = Display.main.systemHeight;

        if (Input.touchCount > 0)
        {
            touchInput = Input.GetTouch(0);

            if (touchInput.phase == TouchPhase.Began)
            {
                touchStartPos = touchInput.position;
            }

            if (touchInput.phase == TouchPhase.Ended)
            {
                touchLastPos = touchInput.position;
                ChequearTipoDeTouch(touchStartPos, touchLastPos);
            }
        }
    }
}