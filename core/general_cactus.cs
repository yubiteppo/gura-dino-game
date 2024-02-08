using Godot;
using System;

public partial class general_cactus : Node2D
{
	private bool _hasSpawnedCactus;
	private Vector2 _originalPosition;
	
	public void UpdateXPosition(float amount)
	{
		Vector2 currentPosition = this.Position;
		currentPosition.X += amount;
		this.Position = currentPosition;
	}
	
	public void SetXPosition(float x)
	{
		Vector2 currentPosition = this.Position;
		currentPosition.X = x;
		this.Position = currentPosition;
	}
	
	public float GetXPosition()
	{
		return this.Position.X;
	}
	
	public void Reset()
	{
		this.Position = new Vector2(_originalPosition.X, _originalPosition.Y);
		_hasSpawnedCactus = false;
	}
	
	public bool HasSpawnedCactus()
	{
		return _hasSpawnedCactus;
	}
	
	public void SetHasSpawnedCactusTrue()
	{
		_hasSpawnedCactus = true;
	}
	
	public general_cactus DuplicateCactus()
	{
		return (general_cactus)this.Duplicate();
	}
	
	public override void _Ready()
	{
		_hasSpawnedCactus = false;
		_originalPosition = new Vector2(this.Position.X, this.Position.Y);
	}
}
