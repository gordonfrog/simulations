package com.kaizenko.vendingmachine;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

//How will the USER interact with basic vending machine?
//What are the basic USER actions -- pay, select product, collect change
//What are the basic MACHINE actions -- dispense product, dispense change
//What are more advanced machine features -- inventory adjust, buy many, machine display
class VendingMachineTest {

	//VendingMachine machine = new VendingMachine();
	private VendingMachine machine;
	
	@BeforeEach
	public void setup() {
		machine = new VendingMachine(new PaymentProcessorImpl());
	}
	
	@AfterEach
	public void destroy() {
		machine = null;
	}
	
	@Test
	void releaseChange_WhenNoMoney_ExpectNoChange() {
		machine = mock(VendingMachine.class);
		when(machine.releaseChange()).thenReturn(0);
		int change = machine.releaseChange();
		assertEquals(change, 0);
		assertTrue (change == 0);
	}
	
	@Test
	void buyProduct_ExpectSoonMessage() {
		machine = mock(VendingMachine.class);
		Product p = new Product();
		when(machine.buyProduct(p)).thenReturn("Come back Soon!");
		String s = machine.buyProduct(p);
		assertEquals(s, "Come back Soon!");
		assertTrue (s == "Come back Soon!");
	}
	
	@Test
	void buyProduct_ExpectDelayMessage() {
		machine = mock(VendingMachine.class);
		Product p = new Product();
		when(machine.buyProduct(p)).thenReturn("Delay in shipping!");
		String s = machine.buyProduct(p);
		assertEquals(s, "Delay in shipping!");
		assertTrue (s == "Delay in shipping!");
	}
	
//	@Test
//	void releaseChange_WhenMoney_ExpectChange() {		
//		machine.insertMoney(25);
//		int change = machine.releaseChange();
//		//System.out.println(change);
//		assertEquals(change, 25);
//		assertTrue (change == 25);
//		//RELEASE CHANGE HACK TEST
//		change = machine.releaseChange();
//		assertEquals(change, 0);
//		assertTrue (change == 0);
//	}
//	
//	@Test
//	void releaseChange_When50_Expect50() {		
//		machine.insertMoney(50);
//		int change = machine.releaseChange();
//		assertEquals(change, 50);
//		assertTrue (change == 50);
//		//RELEASE CHANGE HACK TEST
//		change = machine.releaseChange();
//		assertEquals(change, 0);
//		assertTrue (change == 0);
//	}
//	
//	@Test
//	void buyProduct_WhenNoMoney_PressCoke_NoCoke() {
//		Product p = machine.pressCoke();
//		assertEquals(p.name, "InsufficientFUnds");
//	}
//	
//	@Test
//	void buyProduct_WhenInsert25_PressCoke_NoCoke() {
//		machine.insertMoney(25);
//		Product p = machine.pressCoke();
//		assertEquals(p.name, "InsufficientFUnds");
//	}
//	
//	@Test
//	void buyProduct_WhenInsert50_PressCoke_GetCoke() {
//		machine.insertMoney(50);
//		Product p = machine.pressCoke();
//		assertEquals(p.name, "coke");
//	}
//	
//	@Test
//	void buyProduct_WhenInsert75_PressCoke_GetCoke_ReleaseChange_Get25() {
//		machine.insertMoney(75);
//		Product p = machine.pressCoke();
//		assertEquals(p.name, "coke");
//		int change = machine.releaseChange();
//		assertEquals(change, 25);
//		assertTrue (change == 25);
//		//RELEASE CHANGE HACK TEST
//		change = machine.releaseChange();
//		assertEquals(change, 0);
//		assertTrue (change == 0);
//	}

}
