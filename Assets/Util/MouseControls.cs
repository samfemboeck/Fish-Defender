using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;

// We need this class because InputActions don't work for Mouse smh...
public class MouseControls
{
    public delegate void MouseChange(Vector2Control mousePos);
	public event MouseChange OnMouseDown;
	public event MouseChange OnMouseUp;
    private bool isMouseDown;
    
    public void FixedUpdate()
    {
        if (Mouse.current.leftButton.IsPressed())
        {
            if (!isMouseDown)
            {
                isMouseDown = true;
                OnMouseDown?.Invoke(Mouse.current.position);
            }
        }
        else
        {
            if (isMouseDown)
            {
                isMouseDown = false;
                OnMouseUp?.Invoke(Mouse.current.position);
            }
        }
    }
}
