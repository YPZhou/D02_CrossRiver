using System;
using Godot;
using static Constants;

public partial class MainGame : Node
{

	public static MainGame Instance;

	public override void _EnterTree()
	{
		gameState = GameState.LoadBoat;
		Instance = this;
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
	
	
	
	
	
	// 选择人物--------------------------------begin
	private Person selectedPerson;
	
	public Person SelectedPerson 
	{
		get => selectedPerson;
		set
		{
			selectedPerson = value;
			SelectPerson(selectedPerson);
		}
	}

	public Action<Person> SelectPerson = delegate(Person person) {  };
	// 选择人物----------------------------------end
}
