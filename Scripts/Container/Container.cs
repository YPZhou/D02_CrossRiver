using System.Collections.Generic;
using System.Linq;
using Godot;
using Godot.Collections;
using static Constants;

public partial class Container : Node
{
	public bool CheckConstraintsNotViolated()
	{
		return Constraints.All(c => !c.CheckConstraintViolated(PeopleInContainer));
	}

	public IEnumerable<IConstraint> GetViolatedConstraints()
	{
		return Constraints.Where(c => c.CheckConstraintViolated(PeopleInContainer));
	}

	public virtual bool CanMoveIn() => true;

	public virtual bool TryMoveIn(Person person)
	{
		var index = GetIndex();
		if (index != -1)
		{
			PeopleInContainer[index] = person;
			
			// 渐变
			//person.GlobalPosition = Areas[index].GlobalPosition;
			var tween = GetTree().CreateTween();
			tween.TweenProperty(person, "global_position", Areas[index].GlobalPosition, 0.15d);
			
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

	public bool HasAllPeople() => PeopleInContainer.Count(p => p != null) == 5
								&& PeopleInContainer.Count(p => p != null && p.PersonType == PersonType.Father) == 1
								&& PeopleInContainer.Count(p => p != null && p.PersonType == PersonType.Mother) == 1
								&& PeopleInContainer.Count(p => p != null && p.PersonType == PersonType.Brother) == 1
								&& PeopleInContainer.Count(p => p != null && p.PersonType == PersonType.Sister) == 1
								&& PeopleInContainer.Count(p => p != null && p.PersonType == PersonType.Other) == 1;

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
