using Godot;
using System.Collections.Generic;
using System.Linq;

public partial class Container : Node
{
	public bool CheckConstraintsNotViolated()
	{
		return Constraints.Any(c => c.CheckConstraintViolated(PeopleInContainer));
	}

	List<Person> PeopleInContainer { get; } = new List<Person>();

	List<IConstraint> Constraints { get; } = new List<IConstraint>()
	{
		new MotherConstraint(),
		new FatherConstraint(),
		new BrotherConstraint(),
		new SisterConstraint(),
		new OtherConstraint(),
	};
}
