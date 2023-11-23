
using Godot;

public static class Extension
{
    public static bool TryGetPerson(this Area2D area2D, out Person person)
    {
        foreach (var node in area2D.GetChildren())
        {
            if (node is Person p)
            {
                person = p;
                return true;
            }
        }

        person = default;
        return false;
    }
}