package com.kaizenko.vendingmachine;

public interface PaymentProcessor {
	void makePayment(int money);
	void clearPayment();
	int getPayment();

}
