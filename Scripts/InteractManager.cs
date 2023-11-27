using System;
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
	    LoginAreaInput(
		    area2D,
		    MainGame.Instance.Left,
		    () => MainGame.Instance.Boat,
		    () => MainGame.Instance.Boat.State == Constants.BoatState.Left
		    );

    }
    

    public void LoginRightAreaInput(Area2D area2D)
    {
	    LoginAreaInput(
		    area2D,
		    MainGame.Instance.Right,
		    () => MainGame.Instance.Boat,
		    () => MainGame.Instance.Boat.State == Constants.BoatState.Right
	    );
    }


    public void LoginBoatAreaInput(Area2D area2D)
    {
	    LoginAreaInput(
		    area2D,
		    MainGame.Instance.Boat,
		    () => MainGame.Instance.Boat.State == Constants.BoatState.Left
			    ? MainGame.Instance.Left
			    : MainGame.Instance.Right,
		    () => true
	    );
    }

    void LoginAreaInput(Area2D area2D, Container origin, Func<Container> GetTo, Func<bool> Condition)
    {
	    if (area2D == null)
	    {
		    return;
	    }
        
	    area2D.InputEvent += (viewport, @event, idx) =>
	    {
		    // 鼠标左键乘船。
		    if (Condition() && @event is InputEventMouseButton {Pressed: true, DoubleClick: false, ButtonIndex:MouseButton.Left})
		    {
			    // 获取点击的索引。
			    var index = origin.Areas.IndexOf(area2D);
			    // 根据索引找到对应的人物.
			    if (origin.TryGetPerson(index, out var person))
			    {
				    // 移动到船容器。
				    bool result = person.TryMove(GetTo());
					if(!result)
					{
						DialogBubble.Instance.ShowBubble("船满了", person.GlobalPosition.X < 800 ? Constants.DialogBubbleState.Left : Constants.DialogBubbleState.Right, person);
					}
			    }
		    }
            
		    if (@event is InputEventMouseButton {Pressed: true, DoubleClick: false, ButtonIndex:MouseButton.Right})
		    {
		    }
            
	    };
    }
    

}