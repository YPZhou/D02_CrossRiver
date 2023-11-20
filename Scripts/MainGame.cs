using Godot;
using static Constants;

public partial class MainGame : Node
{
	public override void _Ready()
	{
		gameState = GameState.LoadBoat;
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
