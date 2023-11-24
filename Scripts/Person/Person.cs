using Godot;
using static Constants;

public partial class Person : Node2D
{
	public virtual PersonType PersonType { get; }

	public virtual Gender Gender { get; }

	public virtual bool CanDriveBoat { get; }
	
	public Container currentLocation;

	public bool CanMove(Container to) => to.CanMoveIn();

	public bool TryMove(Container to)
	{
		var result = false;
		if (currentLocation != to && to.TryMoveIn(this))
		{
			currentLocation?.MoveOut(this);
			currentLocation = to;
			result = true;
		}

		return result;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Hello World!");
	}

}
