using Godot;
using System;

public partial class gura : Node2D
{
	private AnimatedSprite2D _gura;
	private int _restYPosition, _jumpHeight;
	
	private void VerticalMoveUp()
	{
		for (int i = 0; i < 1000; ++i)
		{
			_gura.MoveLocalY(-0.01f);
		}
	}
	
	private void VerticalMoveDown()
	{
		for (int i = 0; i < 1000; ++i)
		{
			_gura.MoveLocalY(0.01f);
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_gura = GetNode<AnimatedSprite2D>($"AnimatedSprite2D");
		
		_jumpHeight = 100;
		_restYPosition = (int)_gura.Position[1] - _jumpHeight;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsKeyPressed(Key.Up))
		{
			VerticalMoveUp();
		}
		if (Input.IsKeyPressed(Key.Down))
		{
			VerticalMoveDown();
		}
	}
}
