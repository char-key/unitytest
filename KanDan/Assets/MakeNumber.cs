using UnityEngine;
using System.Collections;
using System;

public class MakeNumber {

	// number to guess - should be between Range_min and Range_max
	// if negative, means it hasn't been randomized
	private int number = -1;
	
	// number of attempts
	private int _attempts = 0;
	public int Attempts
	{
		get
		{
			return this._attempts;
		}
		private set
		{
			this._attempts = value;
		}
	}
	
	// minimum range value
	private int _range_min = 0;
	public int Range_min
	{
		get
		{
			return this._range_min;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("Cannot set minimum range smaller than zero!!");
			}
			else if (value >= this.Range_max)
			{
				throw new ArgumentOutOfRangeException("Cannot set minimum range >= maximum");
			}
			this._range_min = value;
			makeNumber(); // reset the random number
		}
	}
	
	// maximum range value
	private int _range_max = 10;
	public int Range_max
	{
		get
		{
			return this._range_max;
		}
		set
		{
			if (value > 1000)
			{
				throw new ArgumentOutOfRangeException("Cannot set maximum range greater than 1000!!");
			}
			else if (value <= this.Range_min)
			{
				throw new ArgumentOutOfRangeException("Cannot set maximum range <= minimum");
			}
			this._range_max = value;
			makeNumber(); // reset random number
		}
	}
	
	
	private void makeNumber()
	{
		// http://stackoverflow.com/a/2706537		
		number = UnityEngine.Random.Range (this.Range_min, this.Range_max);	
		this.Attempts = 0; // reset number of attempts
		Debug.Log(">>>>>>>>>>>>>>>> " + number);
	}

	public int Guess(int guess_num)
	{
		if (number < 0)
		{
			// make a new random number
			makeNumber();
		}
		
		// increment number of attempts
		this.Attempts++;
		
		// How accurate is the guess?
		int diff = guess_num - number;
		
		if (diff == 0)
		{
			// reset the number since we've guessed it
			number = -1;
			// read Attempts to see how many guesses it took
			// BEFORE trying out a new guess
		}
		
		return diff;
	}
}
