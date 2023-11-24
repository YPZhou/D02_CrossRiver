using Godot;

public partial class Messager : Control
{
	[Export]
	public Label Message;

	public static Messager Instance;

	private Callable Callable = default;

	public override void _EnterTree()
	{
		Instance = this;
	}

	public void _on_btn_ok_pressed()
	{
		Hide();
		if(Callable.Target != null)
			Callable.Call();
	}

	public void ShowMessage(string message, Callable callable = default)
	{
		Message.Text = message;
		Show();
		Callable = callable;
	}
}
