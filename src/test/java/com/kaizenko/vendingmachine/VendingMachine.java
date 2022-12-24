package com.kaizenko.vendingmachine;

import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class VendingMachine {
	
	//public int money = 0;
	public PaymentProcessor paymentProcessor;

	public VendingMachine(PaymentProcessor paymentP) {
		paymentProcessor = paymentP;
	}

	public int releaseChange() {
		int currentMoney = paymentProcessor.getPayment();
		paymentProcessor.clearPayment();
		return currentMoney;
//		int currentMoney = money;
//		money = 0;
//		return currentMoney;
	}

	public void insertMoney(int i) {
		paymentProcessor.makePayment(i);
		//System.out.println(paymentProcessor.getPayment());
		//money = i;
	}

	public Product pressCoke() {
		Product p = new Product();
		if (paymentProcessor.getPayment() >= 50) {
			p.name = "coke";
			paymentProcessor.makePayment(paymentProcessor.getPayment()-50);
		}
//		if (money >= 50) {
//			p.name = "coke";
//			money =money-50;
//		}
		else {
			p.name = "InsufficientFUnds";
		}
		return p;
	}

	public String buyProduct(Product p) {
		return null;
	}

}
