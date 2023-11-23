
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
            if (MainGame.Instance.Boat.State != Constants.BoatState.Left)
                return;
            
            // 鼠标左键乘船。
            if (@event is InputEventMouseButton {Pressed: true, DoubleClick: false, ButtonIndex:MouseButton.Left})
            {
                var left = MainGame.Instance.Left;
                // 获取点击的索引。
                var index = left.Areas.IndexOf(area2D);
                // 根据索引找到对应的人物.
                if (left.TryGetPerson(index, out var person))
                {
                    // 移动到船容器。
                    person.TryMove(MainGame.Instance.Boat);
                }
            }
            
            if (@event is InputEventMouseButton {Pressed: true, DoubleClick: false, ButtonIndex:MouseButton.Right})
            {
            }
            
        };
    }
    

    public void LoginRightAreaInput(Area2D area2D)
    {
        if (area2D == null)
        {
            return;
        }
        
        area2D.InputEvent += (viewport, @event, idx) =>
        {
            if (MainGame.Instance.Boat.State != Constants.BoatState.Right)
                return;

            // 鼠标左键乘船。
            if (@event is InputEventMouseButton {Pressed: true, DoubleClick: false, ButtonIndex:MouseButton.Left})
            {
                var right = MainGame.Instance.Right;
                // 获取点击的索引。
                var index = right.Areas.IndexOf(area2D);
                // 根据索引找到对应的人物.
                if (right.TryGetPerson(index, out var person))
                {
                    // 移动到船容器。
                    person.TryMove(MainGame.Instance.Boat);
                }
            }
            
            if (@event is InputEventMouseButton {Pressed: true, DoubleClick: false, ButtonIndex:MouseButton.Right})
            {
            }
            
        };
    }


    public void LoginBoatAreaInput(Area2D area2D)
    {
        
        if (area2D == null)
        {
            return;
        }
        
		if (area2D.Name == "DriveBoat")
		{
			area2D.InputEvent += (viewport, @event, idx) =>
			{
				if (@event is InputEventMouseButton {Pressed: true, DoubleClick: false, ButtonIndex:MouseButton.Left})
				{
					MainGame.Instance.MoveBoat();
				}
			};
		}
		else
		{
			area2D.InputEvent += (viewport, @event, idx) =>
			{
				if (@event is InputEventMouseButton {Pressed: true, DoubleClick: false, ButtonIndex:MouseButton.Left})
				{
					var boat = MainGame.Instance.Boat;
					var index = boat.Areas.IndexOf(area2D);
					if (boat.TryGetPerson(index, out var person))
					{
						person.TryMove(MainGame.Instance.Boat.State == Constants.BoatState.Left
							? MainGame.Instance.Left
							: MainGame.Instance.Right);
					}
				}
				
				if (@event is InputEventMouseButton {Pressed: true, DoubleClick: false, ButtonIndex:MouseButton.Right})
				{
				}
				
			};
		}
    }


    

}