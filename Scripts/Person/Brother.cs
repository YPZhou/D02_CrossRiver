using Godot;
using System;
using static Constants;

public partial class Brother : Person
{
	public override PersonType PersonType => PersonType.Brother;

	public override Gender Gender => Gender.Male;

	public override bool CanDriveBoat => true;
}
