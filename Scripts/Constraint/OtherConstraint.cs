using System.Collections.Generic;
using System.Linq;
using Godot;
using static Constants;

public class OtherConstraint : IConstraint
{
	bool IConstraint.CheckConstraintViolated(IEnumerable<Person> people)
	{
		return people.Count(p => p != null) == 2
			&& people.Count(p => p != null && p.PersonType == PersonType.Other && p.Gender == Gender.Male) == 1
			&& people.Count(p => p != null && p.PersonType == PersonType.Brother && p.Gender == Gender.Male) == 1;
	}

	string IConstraint.GetMessageForConstraintViolated()
	{
		return string.Empty;
	}
}
