using Godot;
using System;

public partial class main : Node2D
{	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("exit"))
		{	
			DisplayServer.WindowSetMode((DisplayServer.WindowMode)2);
		}
		
		if (Input.IsActionJustPressed("toggle_fullscreen"))
		{
			if ((int)DisplayServer.WindowGetMode() == 3)
			{
				DisplayServer.WindowSetMode((DisplayServer.WindowMode)2);
			}
			else
			{
				DisplayServer.WindowSetMode((DisplayServer.WindowMode)3);
			}
		}
	}
}
