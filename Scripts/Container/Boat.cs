using System.Linq;
using Godot;
using static Constants;

public partial class Boat : Container
{
	public bool CanMoveBoat()
	{
		return PeopleInContainer.Count > 0 && PeopleInContainer.Any(p => p.CanDriveBoat);
	}

	public BoatState State = BoatState.Left;

}
