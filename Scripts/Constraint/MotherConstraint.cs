using Godot;
using System.Collections.Generic;
using System.Linq;
using static Constants;

public class MotherConstraint : IConstraint
{
	bool IConstraint.CheckConstraintViolated(IEnumerable<Person> people)
	{
		return people.Count() == 2
			&& people.Count(p => p.PersonType == PersonType.Mother && p.Gender == Gender.Female) == 1
			&& people.Count(p => p.Gender == Gender.Male) == 1;
	}
}
