using Godot;

public partial class DriveButton : Button
{
    
    public override void _Ready()
    {
        ButtonDown += () =>
        {
            MainGame.Instance.MoveBoat();
        };
    }

    public override void _Process(double delta)
    {
        Disabled = !MainGame.Instance.Boat.CanMoveBoat();
    }
}