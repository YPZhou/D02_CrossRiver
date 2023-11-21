using Godot;
using System;

public partial class Title : Control
{

	public void _on_btn_start_game_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/main_scene.tscn");
	}

	public void _on_btn_exit_game_pressed()
	{
		GetTree().Quit();
	}
}
