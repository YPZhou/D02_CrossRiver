using Godot;

public partial class PersonInfo : Control
{
    [Export] 
    public RichTextLabel TextLabel { get; private set; }


    public override void _Ready()
    {
        base._Ready();

        MainGame.Instance.SelectPerson += person =>
        {
            TextLabel.Text = $"{person.PersonType}";

        };

    }
}