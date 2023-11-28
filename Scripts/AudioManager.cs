using Godot;
using System;

public partial class AudioManager : Node
{
	[Export]
	public AudioStreamPlayer BGM;
	[Export]
	public AudioStreamPlayer SE;

	public override void _Ready()
	{
		PlayBGM("01. Mischievous Step");
	}

	public void PlayBGM(string name)
	{
		AudioStream audioStream = ResourceLoader.Load<AudioStream>("res://Assets/Audio/BGM/" + name + ".ogg");
		BGM.Stream = audioStream;
		BGM.Play();
	}

	public void StopBGM()
	{
		BGM.Stop();
	}

	public void PlaySE(string name)
	{
		AudioStream audioStream = ResourceLoader.Load<AudioStream>("res://Assets/Audio/SE/" + name + ".ogg");
		SE.Stream = audioStream;
		SE.Play();
	}
}
