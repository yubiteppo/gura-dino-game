using Godot;
using System;

public partial class Score : Label
{
	private int _scoreValue, _incrementValue;
	private bool _isScorePaused;
	
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
	
	public int GetScore()
	{
		return _scoreValue;
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
		_incrementValue = 1;
		_scoreValue = 0;
		this.Text = _scoreValue.ToString();
		_isScorePaused = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Engine.GetProcessFrames() % 5 == 0)
		{
			IncrementScore();
		}
	}
}
