using Godot;
using System;

public partial class Messager : Control
{
	[Export]
	public Label Message;

	private Callable Callable = default;

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
