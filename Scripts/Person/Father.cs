using Godot;
using System;
using static Constants;

public partial class Father : Person
{
	public override PersonType PersonType => PersonType.Father;

	public override Gender Gender => Gender.Male;

	public override bool CanDriveBoat => true;
}
