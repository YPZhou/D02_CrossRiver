using Godot;
using System;
using static Constants;

public partial class DialogBubble : Control
{
	
	[Export]
	public Label Message;
	[Export]
	public ColorRect Bubble;
	[Export]
	public ColorRect Arrow_L;
	[Export]
	public ColorRect Arrow_R;
	[Export]
	public ColorRect Arrow_D;

	private DialogBubbleState dialogBubbleState = DialogBubbleState.None;

	private SceneTreeTimer sceneTreeTimer;
	private int callCount;

	public static DialogBubble Instance;
	
	public override void _EnterTree()
	{
		Instance = this;
	}


	public void ShowBubble(string message, DialogBubbleState arrowState, Node2D node)
	{
		sceneTreeTimer = null;
		callCount++;
		Message.Text = message;
		dialogBubbleState = arrowState;
		
		SetPos(node);
		UpdateDialogBubble();
		HideDialogBubble(1.5f);
	}

	public void HideBubble()
	{
		Message.Text = string.Empty;
		dialogBubbleState = DialogBubbleState.None;
		UpdateDialogBubble();

	}

	public async void HideDialogBubble(float time = 1.0f)
	{
		if(sceneTreeTimer != null)
		{
			return;
		}
		int temp = callCount;
		sceneTreeTimer = GetTree().CreateTimer(time);
		await ToSignal(sceneTreeTimer, SceneTreeTimer.SignalName.Timeout);
		if(temp == callCount)
		{
			HideBubble();
		}
	}

	private void UpdateDialogBubble()
	{
		Arrow_L.Hide();
		Arrow_R.Hide();
		Arrow_D.Hide();
		Bubble.Hide();
		if(dialogBubbleState == DialogBubbleState.None)
			return;

		Bubble.Show();
		if(dialogBubbleState == DialogBubbleState.Left)
			Arrow_L.Show();
		else if(dialogBubbleState == DialogBubbleState.Right)
			Arrow_R.Show();
		else if(dialogBubbleState == DialogBubbleState.Down)
			Arrow_D.Show();
	}

	private void SetPos(Node2D node)
	{
		if(node == null)
			return;

		Vector2 v2 = node.GlobalPosition;
		float y = 0;
		if(dialogBubbleState == DialogBubbleState.Left)
		{
			Vector2 newV2 = new Vector2(128 + v2.X, v2.Y - 64);
			Bubble.Position = newV2;
		}
		else if(dialogBubbleState == DialogBubbleState.Right)
		{
			Vector2 newV2 = new Vector2(v2.X - 128 - Bubble.Size.X, v2.Y - 64);
			Bubble.Position = newV2;
		}

	}
}
