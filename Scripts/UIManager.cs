
using Godot;

public partial class UIManager : CanvasLayer
{

    public static UIManager Instance;
    
    [Export]
    public PersonInfo PersonInfo;


    public override void _EnterTree()
    {
        Instance = this;
    }
}