using Godot;
using System;
using static Constants;

public partial class Other : Person
{
	public override PersonType PersonType => PersonType.Other;

	public override Gender Gender => Gender.Male;

	public override bool CanDriveBoat => true;
}
