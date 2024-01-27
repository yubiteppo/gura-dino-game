using Godot;
using System;

public partial class gura : Node2D
{
	private AnimatedSprite2D _gura;
	private float _floorLevel, _velocity, _fallAcceleration, _jumpImpulse;
	private Vector2 _position;
	private bool _isJumping;
	
	private void UpdateYPosition(float del)
	{
		_position.Y += del;
		_gura.Position = _position;
	}
	
	private void ResetPosition()
	{
		_gura.Position = new Vector2(0, _floorLevel);
	}
	
	private void Jump()
	{
		_velocity += _fallAcceleration;
		if (_gura.Position.Y + _velocity  > _floorLevel)
		{
			_isJumping = false;
			_velocity = _jumpImpulse;
			ResetPosition();
		}
		else
		{
			UpdateYPosition(_velocity);
		}
	}
	
	 //Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_gura = GetNode<AnimatedSprite2D>($"AnimatedSprite2D");
		_position = new Vector2(0, _gura.Position.Y);
		_floorLevel = _gura.Position.Y;
		_fallAcceleration = 1;
		_jumpImpulse = -22;
		_velocity = _jumpImpulse;
		_isJumping = false;
	}
	
	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionJustPressed("jump"))
		{
			_isJumping = true;
		}
		
		if (_isJumping)
		{
			Jump();
		}
	}
}
