
using System;
using Godot;
using GodotPlugins.Game;

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
            if (@event is InputEventMouseButton {Pressed: true, DoubleClick: false, ButtonIndex:MouseButton.Left})
            {
                // 鼠标左键乘船。
                if (!area2D.TryGetPerson(out var person))
                {
                    return;
                }

                MainGame.Instance.Left.MoveOut(person);
                MainGame.Instance.Boat.TryMoveIn(person);

            }
            
            if (@event is InputEventMouseButton {Pressed: true, DoubleClick: false, ButtonIndex:MouseButton.Right})
            {
            }
            
        };
    }
    

    public void LoginRightAreaInput(Area2D area2D)
    {
        
    }


    public void LoginBoatAreaInput(Area2D area2D)
    {
        
        if (area2D == null)
        {
            return;
        }
        
        area2D.InputEvent += (viewport, @event, idx) =>
        {
            if (@event is InputEventMouseButton {Pressed: true, DoubleClick: false, ButtonIndex:MouseButton.Left})
            {
                if (!area2D.TryGetPerson(out var person))
                {
                    return;
                }
                
                MainGame.Instance.Left.MoveOut(person);

                if (MainGame.Instance.Boat.State == Constants.BoatState.Left)
                {
                    MainGame.Instance.Left.TryMoveIn(person);
                }
                else
                {
                    MainGame.Instance.Right.TryMoveIn(person);
                }

            }
            
            if (@event is InputEventMouseButton {Pressed: true, DoubleClick: false, ButtonIndex:MouseButton.Right})
            {
            }
            
        };
        
    }


    

}