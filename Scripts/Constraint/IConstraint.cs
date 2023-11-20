using System.Collections.Generic;

public interface IConstraint
{
	bool CheckConstraintViolated(IEnumerable<Person> people);
}
