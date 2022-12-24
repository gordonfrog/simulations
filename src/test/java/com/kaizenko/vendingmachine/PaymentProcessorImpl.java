package com.kaizenko.vendingmachine;

public class PaymentProcessorImpl implements PaymentProcessor {
	
	int money;

	@Override
	public void makePayment(int money) {
		//this.money = money;
	}

	@Override
	public void clearPayment() {
		//money = 0;
	}

	@Override
	public int getPayment() {
		return money;
	}

}
