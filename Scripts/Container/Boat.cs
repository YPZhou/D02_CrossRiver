using System.Linq;
using Godot;
using static Constants;

public partial class Boat : Container
{
	public bool CanMoveBoat()
	{
		return PeopleInContainer.Length > 0 && PeopleInContainer.Any(p => p?.CanDriveBoat ?? false);
	}

	public void MoveBoat()
	{
		if (State == BoatState.Left)
		{
			State = BoatState.Right;
			GD.Print("Right");
			boatSprite.Position = new Vector2(1100, boatSprite.Position.Y);

			foreach (var person in PeopleInContainer)
			{
				if (person != null)
				{
					// person.GlobalPosition = new Vector2(person.GlobalPosition.X + 600, person.GlobalPosition.Y);
					person.TryMove(MainGame.Instance.Right);
				}
			}
		}
		else
		{
			State = BoatState.Left;
			GD.Print("Left");
			boatSprite.Position = new Vector2(500, boatSprite.Position.Y);

			foreach (var person in PeopleInContainer)
			{
				if (person != null)
				{
					// person.GlobalPosition = new Vector2(person.GlobalPosition.X - 600, person.GlobalPosition.Y);
					person.TryMove(MainGame.Instance.Left);
				}
			}
		}
	}

	public BoatState State = BoatState.Left;

	[Export]
	Sprite2D boatSprite;
}
