using Godot;
using System;
using static Constants;

public abstract partial class Person : Node2D
{
	public virtual PersonType PersonType { get; }

	public virtual Gender Gender { get; }

	public virtual bool CanDriveBoat { get; } 

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Hello World!");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
