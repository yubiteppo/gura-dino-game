using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class cactus : Node2D
{
	private cactus_0 _cactus0;
	private cactus_1 _cactus1;
	private cactus_2 _cactus2;
	
	private List<general_cactus> _cactusList;
	
	private int _minVal, _maxVal;
	private float _moveAmount, _speedCap, _endPoint, _spawnPoint;
	private Vector2 _position, _originalPosition;
	
	private Random _random;
	
	private void Move()
	{
		// Only proceed if cactus list is populated, otherwise index out of bounds
		if (_cactusList.Count > 0)
		{
			for (int i = _cactusList.Count - 1; i >= 0; --i)
			{
				// Get the cactus at index i and relating data
				general_cactus currentCactus = _cactusList[i];
				float currentCactusPosition = currentCactus.GetXPosition();
				
				// Remove current cactus from list and delete from tree
				// when reaches endpoint
				if (currentCactusPosition <= _endPoint)
				{
					_cactusList.RemoveAt(i);
					currentCactus.QueueFree();
				}
				
				// If the cactus is at the respawn point and has not already spawned a child,
				// spawn the child. The child must be a duplicate of the parent node, or we will
				// delete the parent node and get object not found errors
				else if (currentCactusPosition <= _spawnPoint && !currentCactus.HasSpawnedCactus())
				{
					int whichCactus = _random.Next(0, 3);
					string whichCactusString = "./Cactus" + whichCactus.ToString();
					general_cactus dup = GetNode<general_cactus>(whichCactusString).DuplicateCactus();
					AddChild(dup);
					dup.SetXPosition(_random.Next(0, 1200));
					_cactusList.Add(dup);
					currentCactus.SetHasSpawnedCactusTrue();
					currentCactus.UpdateXPosition(_moveAmount);
				}
				
				// If the cactus has not reached either the spawn or end point, do nothing
				// but move the cactus
				else
				{
					currentCactus.UpdateXPosition(_moveAmount);
				}
			}
		}
		
		// If the cactus list has somehow become empty, add a duplicate of a randomly
		// chosen parent cactus
		else
		{
			int whichCactus = _random.Next(0, 3);
			string whichCactusString = "./Cactus" + whichCactus.ToString();
			general_cactus dup = GetNode<general_cactus>(whichCactusString).DuplicateCactus();
			AddChild(dup);
			_cactusList.Add(GetNode<general_cactus>(whichCactusString));
		}
	}
	
	// Increases the move amount by a fixed value
	public void IncreaseSpeed()
	{
		float speedDecrement = 1.0f;
		if (_moveAmount - speedDecrement >= _speedCap)
		{
			_moveAmount -= speedDecrement;
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Create random for rng
		_random = new();
		
		// Get cactus nodes from scene tree
		_cactus0 = GetNode<cactus_0>($"Cactus0");
		_cactus1 = GetNode<cactus_1>($"Cactus1");
		_cactus2 = GetNode<cactus_2>($"Cactus2");
		
		// Duplicate cactus 0 and add it as a part of the scene tree
		general_cactus dup0 = _cactus0.DuplicateCactus();
		AddChild(dup0);
		
		// Create cactus list and add duplicate cactus 0
		_cactusList = new();
		_cactusList.Add(dup0);
		
		// Set physics values
		_moveAmount = -12.5f;
		_speedCap = -35.0f;
		
		// Get position info
		_position = new Vector2(this.Position.X, this.Position.Y);
		_originalPosition = new Vector2(this.Position.X, this.Position.Y);
		
		// Set spawn and end points
		_endPoint = -(_originalPosition.X + 50);
		_spawnPoint = -900;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Move();		// Move every cactus in cactus list every frame
	}
}
