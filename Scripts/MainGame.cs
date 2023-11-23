using System;
using Godot;
using static Constants;

public partial class MainGame : Node
{

	public static MainGame Instance;

	[Export]
	public Container Left { get; private set; }
	[Export]
	public Container Boat { get; private set; }
	[Export]
	public Container Right { get; private set; }

	public override void _EnterTree()
	{
		gameState = GameState.LoadBoat;
		Instance = this;
		
		for (var i = 0; i < Left.Areas.Count; ++i)
		{
			InteractManager.Instance.LoginLeftAreaInput(Left.Areas[i]);
		}
		
		for (var i = 0; i < Right.Areas.Count; ++i)
		{
			InteractManager.Instance.LoginRightAreaInput(Right.Areas[i]);
		}
		
		for (var i = 0; i < Boat.Areas.Count; ++i)
		{
			InteractManager.Instance.LoginBoatAreaInput(Boat.Areas[i]);
		}
	}

	public override void _Process(double delta)
	{
		switch (gameState)
		{
			case GameState.LoadBoat:
				// 玩家按下开船按钮，且满足开船条件，则gameState变为MoveBoat
				break;
			case GameState.MoveBoat:
				// 检查Left, Right, 和Boat是否满足约束条件
				// 如果三处地点均满足约束条件，则gameState变为LoadBoat
				// 否则gameState变为EroScene
				break;
			case GameState.EroScene:
				// 显示文案及CG，之后gameState变为LoadBoat
				break;
		}
	}

	GameState gameState;
	
	
}
