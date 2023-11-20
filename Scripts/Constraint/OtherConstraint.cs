using Godot;
using System.Collections.Generic;
using System.Linq;
using static Constants;

public class OtherConstraint : IConstraint
{
	bool IConstraint.CheckConstraintViolated(IEnumerable<Person> people)
	{
		return people.Count() == 2
			&& people.Count(p => p.PersonType == PersonType.Other && p.Gender == Gender.Male) == 1
			&& people.Count(p => p.PersonType == PersonType.Brother && p.Gender == Gender.Male) == 1;
	}
}
