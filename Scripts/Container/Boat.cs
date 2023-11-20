using static Constants;

public partial class Boat : Container
{
	public override bool CanMoveIn() => PeopleInContainer.Count < MAX_BOAT_CAPACITY;

	public override bool TryMoveIn(Person person)
	{
		var result = false;
		if (PeopleInContainer.Count < MAX_BOAT_CAPACITY)
		{
			PeopleInContainer.Add(person);
			result = true;
		}

		return result;
	}
}
