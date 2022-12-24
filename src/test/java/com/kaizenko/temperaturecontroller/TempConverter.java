package com.kaizenko.temperaturecontroller;

public class TempConverter {

	public double ConvertCtoF(int i) {
//		if (i == 0) return 32;
//		if (i == 100) return 212;
//		if (i == -40) return -40;
		
		//multiply by 1.8 (or 9/5) and add 32
		return 1.8 * i + 32;
	}

}
