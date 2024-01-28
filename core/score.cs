using Godot;
using System;

public partial class Score : Label
{
	private int _scoreValue, _incrementValue;
	private bool _isScorePaused;
	private int toggle;
	
	private void SetScoreAndScoreValue(int val)
	{
		_scoreValue = val;
		this.Text = _scoreValue.ToString();
	}
	
	private void ChangeScoreAndScoreValue(int delta)
	{
		_scoreValue += delta;
		this.Text = _scoreValue.ToString();
	}
	
	public void IncrementScore()
	{
		if (!_isScorePaused)
		{
			ChangeScoreAndScoreValue(_incrementValue);
		}
	}
	
	public void ResetScore()
	{
		SetScoreAndScoreValue(0);
	}
	
	public void SetScorePaused()
	{
		_isScorePaused = true;
	}
	
	public void SetScoreUnpaused()
	{
		_isScorePaused = false;
	}
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		toggle = 0;
		_incrementValue = 1;
		_scoreValue = 0;
		this.Text = _scoreValue.ToString();
		_isScorePaused = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (toggle == 1)
		{
			IncrementScore();
			toggle = 0;
		}
		else
		{
			toggle = 1;
		}
	}
}
