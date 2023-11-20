using Godot;
using System;
using static Constants;

public partial class Sister : Person
{
	public override PersonType PersonType => PersonType.Sister;

	public override Gender Gender => Gender.Female;

	public override bool CanDriveBoat => false;
}
