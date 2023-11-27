public static class Constants
{
	public enum Gender
	{
		Male,
		Female,
	}

	public enum PersonType
	{
		Father,
		Mother,
		Brother,
		Sister,
		Other,
	}

	public enum GameState
	{
		LoadBoat,
		MoveBoat,
		EroScene,
	}
	
	
	public enum BoatState
	{
		Left,
		Right
	}

	public const int MAX_BOAT_CAPACITY = 2;

	public enum DialogBubbleState
	{
		None,
		Left,
		Right,
		Down,

	}
}
