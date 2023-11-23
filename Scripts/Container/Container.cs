using Godot;
using System.Collections.Generic;
using System.Linq;
using Godot.Collections;

public partial class Container : Node
{
	public bool CheckConstraintsNotViolated()
	{
		return Constraints.Any(c => c.CheckConstraintViolated(PeopleInContainer));
	}

	public virtual bool CanMoveIn() => true;

	public virtual bool TryMoveIn(Person person)
	{
		var index = GetIndex();
		if (index != -1)
		{
			PeopleInContainer[index] = person;
			person.GlobalPosition = Areas[index].GlobalPosition;
			return true;
		}

		return false;

		/*var result = PeopleInContainer.Count < Capacity;
		if (result)
		{
			PeopleInContainer.Add(person);
			person.GlobalPosition = Areas[index].GlobalPosition;
		}
		return result;*/
	}

	public void MoveOut(Person person)
	{
		var index = System.Array.IndexOf(PeopleInContainer, person);
		if (index != -1)
		{
			PeopleInContainer[index] = null;
		}
	}

	protected Person[] PeopleInContainer { get; private set; }

	List<IConstraint> Constraints { get; } = new List<IConstraint>()
	{
		new MotherConstraint(),
		new FatherConstraint(),
		new BrotherConstraint(),
		new SisterConstraint(),
		new OtherConstraint(),
	};

	[Export]
	public Array<Area2D> Areas { get; private set; }

	public int Capacity => Areas.Count;


	public bool TryGetPerson(int index, out Person person)
	{
		if (index >= 0 && PeopleInContainer.Length > index)
		{
			person = PeopleInContainer[index];
			return person != null;
		}

		person = default;
		return false;

	}

	/// <summary>
	/// 尝试获取空对象的索引，用于插入对象。
	/// </summary>
	/// <returns></returns>
	public int GetIndex()
	{
		for (var i = 0; i < Capacity; ++i)
		{
			if (PeopleInContainer[i] == null)
			{
				return i;
			}
		}

		return -1;
	}


	public override void _EnterTree()
	{
		PeopleInContainer = new Person[Capacity];
	}
}
