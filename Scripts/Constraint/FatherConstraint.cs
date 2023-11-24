using System.Linq;
using System.Collections.Generic;
using Godot;
using static Constants;

public class FatherConstraint : IConstraint
{
	bool IConstraint.CheckConstraintViolated(IEnumerable<Person> people)
	{
		return people.Count(p => p != null) == 2
			&& people.Count(p => p != null && p.PersonType == PersonType.Father && p.Gender == Gender.Male) == 1
			&& people.Count(p => p != null && p.PersonType == PersonType.Sister && p.Gender == Gender.Female) == 1;
	}

	string IConstraint.GetMessageForConstraintViolated()
	{
		return string.Empty;
	}
}
