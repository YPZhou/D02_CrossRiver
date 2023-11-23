
using Godot;

public class InteractManager
{
    // 单例------------------------begin
    private InteractManager()
    {
    }

    private static InteractManager instance;

    public static InteractManager Instance => instance ??= new InteractManager();

    // 单例--------------------------end

    
    /// <summary>
    /// 等待区的事件注册。
    /// </summary>
    /// <param name="area2D"></param>
    public void LoginLeftAreaInput(Area2D area2D)
    {
        if (area2D == null)
        {
            return;
        }
        

        area2D.InputEvent += (viewport, @event, idx) =>
        {
            if (@event is InputEventMouseButton {Pressed: true, DoubleClick: false} e)
            {
                switch (e.ButtonIndex)
                {
                    case MouseButton.Left: // 左键交互，乘船。
                        
                        
                        
                        break;
                    case MouseButton.Right: // 右键查看信息。

                        break;
                }
            }
        };
    }


    public void LoginRightAreaInput(Area2D area2D)
    {
        
    }


    public void LoginBoatAreaInput(Area2D area2D)
    {
    }

}