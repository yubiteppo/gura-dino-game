using Godot;
using System;

public partial class gura : Node2D
{
	private AnimatedSprite2D _gura;
	private float _floorLevel, _velocity, _fallAcceleration, _jumpImpulse;
	private Vector2 _position;
	private bool _isJumping, _hasCollided;
	private Area2D _area;
	
	// Replaces Gura's position vector w/ new vector with
	// modified y value
	private void UpdateYPosition(float del)
	{
		_position.Y += del;
		_gura.Position = _position;
	}
	
	// Place Gura at initial location on screen
	private void ResetPosition()
	{
		_gura.Position = new Vector2(0, _floorLevel);
	}
	
	public void Reset()
	{
		ResetPosition();
		_hasCollided = false;
		_isJumping = false;
	}
	
	// Calculates and updates Gura's vertical position 
	// during a jump. This method should be called every 
	// frame in which Gura should be jumping, as it sets
	// her position for a single frame.
	private void Jump()
	{
		if (!_hasCollided)
		{
			_velocity += _fallAcceleration;
			if (_gura.Position.Y + _velocity  > _floorLevel)
			{
				_isJumping = false;
				_velocity = _jumpImpulse;
				ResetPosition();			// Not necessary, but ensures Gura will not fall through floor
			}
			else
			{
				UpdateYPosition(_velocity);
			}
		}
	}
	
	private void OnAreaEntered(Area2D area)
	{
		_hasCollided = true;
	}
	
	public bool HasCollided()
	{
		return _hasCollided;
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
		_area = GetNode<Area2D>($"AnimatedSprite2D/Area2D");
		_hasCollided = false;
		
		_area.AreaEntered += OnAreaEntered;
	}
	
	public override void _PhysicsProcess(double delta)
	{
		// Detect if jump has begun
		if (Input.IsActionJustPressed("jump"))
		{
			_isJumping = true;
		}
		
		// Determine position at this frame during jump based on
		// jump impulse and downward acceleration.
		if (_isJumping)
		{
			Jump();
		}
	}
}
