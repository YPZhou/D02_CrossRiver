using Godot;
using System.Linq;
using System.Collections.Generic;
using static Constants;

public class FatherConstraint : IConstraint
{
	bool IConstraint.CheckConstraintViolated(IEnumerable<Person> people)
	{
		return people.Count() == 2
			&& people.Count(p => p.PersonType == PersonType.Father && p.Gender == Gender.Male) == 1
			&& people.Count(p => p.PersonType == PersonType.Sister && p.Gender == Gender.Female) == 1;
	}
}
