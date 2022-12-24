package com.kaizenko.temperaturecontroller;

import static org.junit.jupiter.api.Assertions.*;
import static org.assertj.core.api.Assertions.assertThat;
import org.junit.jupiter.api.Test;

class TemperatureControllerTest {
	private TempConverter tempConverter = new TempConverter();
	
	
	@Test
	void ConvertCtoF_When0CExpect32F() {
		
		double tempF = tempConverter.ConvertCtoF(0);
		System.out.println("tempF = "+tempF);
		assertEquals(tempF, 32);
		assertTrue (tempF == 32);
	}
	
	@Test
	void ConvertCtoF_When100CExpect212F() {
		double tempF = tempConverter.ConvertCtoF(100);
		System.out.println("tempF = "+tempF);
		assertEquals(tempF, 212);
		assertTrue (tempF == 212);
	}
	
	@Test
	void ConvertCtoF_WhenNeg40CExpectNeg40F() {
		double tempF = tempConverter.ConvertCtoF(-40);
		System.out.println("tempF = "+tempF);
		assertEquals(tempF, -40);
		assertTrue (tempF == -40);
	}
	
	@Test
	void ConvertCtoF_When25CExpect77F() {
		double tempF = tempConverter.ConvertCtoF(25);
		System.out.println("tempF = "+tempF);
		assertEquals(tempF, 77);
		assertTrue (tempF == 77);
	}

}
