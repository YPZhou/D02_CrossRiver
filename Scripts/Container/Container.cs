using Godot;
using System.Collections.Generic;
using System.Linq;

public partial class Container : Node
{
	public bool CheckConstraintsNotViolated()
	{
		return Constraints.Any(c => c.CheckConstraintViolated(PeopleInContainer));
	}

	public virtual bool CanMoveIn() => true;

	public virtual bool TryMoveIn(Person person)
	{
		PeopleInContainer.Add(person);
		return true;
	}

	public void MoveOut(Person person)
	{
		PeopleInContainer.Remove(person);
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
}
