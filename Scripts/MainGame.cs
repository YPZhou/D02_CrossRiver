using System;
using System.Linq;
using Godot;
using static Constants;

public partial class MainGame : Node
{

	public static MainGame Instance;

	[Export]
	public Container Left { get; private set; }
	[Export]
	public Boat Boat { get; private set; }
	[Export]
	public Container Right { get; private set; }
	
	
	public override void _EnterTree()
	{
		Instance = this;
		moveBoatClicked = false;
	}

	public override void _Ready()
	{
		gameState = GameState.LoadBoat;
		LoginAreasInput();
		InitPeople();
	}

	public override void _Process(double delta)
	{
		switch (gameState)
		{
			case GameState.LoadBoat:
				// 玩家按下开船按钮，且满足开船条件，则gameState变为MoveBoat
				if (moveBoatClicked && Boat.CanMoveBoat())
				{
					gameState = GameState.MoveBoat;
				}
				break;
			case GameState.MoveBoat:
				// 检查Left, Right, 和Boat是否满足约束条件
				// 如果三处地点均满足约束条件，则gameState变为LoadBoat
				// 否则gameState变为EroScene

				if (Left.CheckConstraintsNotViolated()
					&& Right.CheckConstraintsNotViolated()
					&& Boat.CheckConstraintsNotViolated())
				{
					Boat.MoveBoat();
					gameState = GameState.LoadBoat;					
				}
				else
				{
					gameState = GameState.EroScene;
				}

				break;
			case GameState.EroScene:
				// 显示文案及CG，之后gameState变为LoadBoat，并重置游戏至初始状态

				foreach (var constraint in Left.GetViolatedConstraints())
				{
					GD.Print($"左岸 条件{constraint}不满足，游戏失败！");
				}

				foreach (var constraint in Right.GetViolatedConstraints())
				{
					GD.Print($"右岸 条件{constraint}不满足，游戏失败！");
				}

				foreach (var constraint in Boat.GetViolatedConstraints())
				{
					GD.Print($"船上 条件{constraint}不满足，游戏失败！");
				}

				Boat.MoveBoat();
				gameState = GameState.LoadBoat;
				break;
		}

		moveBoatClicked = false;
	}

	GameState gameState;

	public void MoveBoat()
	{
		moveBoatClicked = true;
	}

	bool moveBoatClicked;

	void LoginAreasInput()
	{
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
		//注册开船按钮
		InteractManager.Instance.LoginBoatAreaInput(Boat.DriveBoat);
	}


	void InitPeople()
	{
		var people = GetNode("People");
		for (var i = 0; i < people.GetChildCount(); ++i)
		{
			var person = people.GetChild<Person>(i);
			person.TryMove(Left);
		}
	}

}
