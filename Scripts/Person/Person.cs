using Godot;
using static Constants;

public abstract partial class Person : Node2D
{
	public virtual PersonType PersonType { get; }

	public virtual Gender Gender { get; }

	public virtual bool CanDriveBoat { get; }

	public bool CanMove(Container to) => to.CanMoveIn();

	public bool TryMove(Container from, Container to)
	{
		var result = false;
		if (to.TryMoveIn(this))
		{
			from.MoveOut(this);
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
