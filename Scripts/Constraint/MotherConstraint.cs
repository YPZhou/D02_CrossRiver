using System.Collections.Generic;
using System.Linq;
using Godot;
using static Constants;

public class MotherConstraint : IConstraint
{
	bool IConstraint.CheckConstraintViolated(IEnumerable<Person> people)
	{
		return people.Count(p => p != null) == 2
			&& people.Count(p => p != null && p.PersonType == PersonType.Mother && p.Gender == Gender.Female) == 1
			&& people.Count(p => p != null && p.Gender == Gender.Male) == 1;
	}

	string IConstraint.GetMessageForConstraintViolated()
	{
		return string.Empty;
	}
}
