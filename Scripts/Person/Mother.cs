using Godot;
using System;
using static Constants;

public partial class Mother : Person
{
	public override PersonType PersonType => PersonType.Mother;

	public override Gender Gender => Gender.Female;

	public override bool CanDriveBoat => true;
	
	
}
