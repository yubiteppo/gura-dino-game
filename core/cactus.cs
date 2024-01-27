using Godot;
using System;

public partial class cactus : Node2D
{
	private Sprite2D _cactus;
	private float _moveAmount;
	private Vector2 _position, _originalPosition;
	
	private void Move()
	{
		if (_cactus.Position.X < -2000)
		{
			_position = _originalPosition;
			_cactus.Position = _position;
		}
		else
		{
			_position.X += _moveAmount;
			_cactus.Position = _position;
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_cactus = GetNode<Sprite2D>($"Sprite2D");
		_moveAmount = -10;
		_position = new Vector2(_cactus.Position.X, _cactus.Position.Y);
		_originalPosition = new Vector2(_cactus.Position.X, _cactus.Position.Y);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GD.Print(_cactus.Position.X, " ", _cactus.Position.Y);
		Move();
	}
}
