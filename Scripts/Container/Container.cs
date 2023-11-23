using Godot;
using System.Collections.Generic;
using System.Linq;
using Godot.Collections;

public partial class Container : Node
{
	public bool CheckConstraintsNotViolated()
	{
		return Constraints.Any(c => c.CheckConstraintViolated(PeopleInContainer));
	}

	public virtual bool CanMoveIn() => true;

	public virtual bool TryMoveIn(Person person)
	{
		var result = PeopleInContainer.Count < Capacity;
		if (result)
		{
			PeopleInContainer.Add(person);
			var index = PeopleInContainer.Count - 1;
			Areas[index].AddChild(person);
			person.GlobalPosition = Areas[index].GlobalPosition;
		}
		return result;
	}

	public void MoveOut(Person person)
	{
		PeopleInContainer.Remove(person);
		person.GetParent().RemoveChild(person);
	}

	protected List<Person> PeopleInContainer { get; } = new List<Person>();

	List<IConstraint> Constraints { get; } = new List<IConstraint>()
	{
		new MotherConstraint(),
		new FatherConstraint(),
		new BrotherConstraint(),
		new SisterConstraint(),
		new OtherConstraint(),
	};

	[Export]
	public Array<Area2D> Areas { get; private set; }

	public int Capacity => Areas.Count;

}
