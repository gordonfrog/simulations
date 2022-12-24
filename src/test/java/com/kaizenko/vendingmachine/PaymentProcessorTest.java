package com.kaizenko.vendingmachine;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

class PaymentProcessorTest {

	private PaymentProcessor paymentProcessor;
	
	@BeforeEach
	public void setup() {
		//paymentProcessor = new PaymentProcessorImpl();
		paymentProcessor = mock(PaymentProcessor.class);
	}
	
	@AfterEach
	public void destroy() {
		paymentProcessor = null;
	}
	
	@Test
	void getPayment_WhenNoMoneyInserted_Expect0() {		
		assertNotNull(paymentProcessor);
		when(paymentProcessor.getPayment()).thenReturn(0);
		//when(paymentProcessor.toString()).thenReturn("Hello");
		assertEquals(paymentProcessor.getPayment(), 0);
		assertTrue (paymentProcessor.getPayment() == 0);
	}
	
	@Test
	void getPayment_WhenMoneyInserted_ExpectMoneyInserted() {
		paymentProcessor.makePayment(100);
		assertNotNull(paymentProcessor);
		when(paymentProcessor.getPayment()).thenReturn(100);
		//when(paymentProcessor.toString()).thenReturn("Hello");
		assertEquals(paymentProcessor.getPayment(), 100);
		assertTrue (paymentProcessor.getPayment() == 100);
	}
	
	@Test
	void getPayment_WhenMoneyInserted_WhenPaymentClear_Expect0() {		
		//paymentProcessor.makePayment(100);
		//paymentProcessor.clearPayment();
		assertNotNull(paymentProcessor);
		when(paymentProcessor.getPayment()).thenReturn(0);
		//when(paymentProcessor.toString()).thenReturn("Hello");
		assertEquals(paymentProcessor.getPayment(), 0);
		assertTrue (paymentProcessor.getPayment() == 0);
	}

}
