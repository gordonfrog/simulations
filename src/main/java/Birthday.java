public class Birthday {

    public static void main (String[] argv)
    {
    	int ppl = 24;
    	System.out.println("---------------------------------------------------------------------------------------------------");
        System.out.println(ppl+" people - chance that 2 share the same birthday. (Probability with 24 people is roughly .5327)");
        System.out.println("--------------------------------------------SIMULATIONS--------------------------------------------");
    	
    	int simulations = 10;
    	for (int i=0; i<simulations; i++) { System.out.println ("		Simulation: "+i+"; Prob[shared bday with "+ppl+" people] = " + birthdayProblem (ppl)); }
    	System.out.println("--------------------------------------------SIMULATIONS--------------------------------------------");
    }


    static double birthdayProblem (int numPeople)
    {
        // Number of times to repeatedly create a random group of people:
        int numTrials = 10000;

        // We'll need to count how often we get a shared b'day.
        int numTrialSuccesses = 0;

        // Repeat and count.
        for (int n=0; n<numTrials; n++) {

            // Generate birthdays (random array)
            int[] birthdays = new int [numPeople];
            for (int i=0; i<birthdays.length; i++) {
                birthdays[i] = UniformRandom.uniform (1, 365);
            }

            // Check if any two match.
            boolean matchExists = false;
            for (int i=0; i<birthdays.length; i++) {
                for (int j=0; j<birthdays.length; j++) {
                    if ( (i != j) && (birthdays[i] == birthdays[j]) ) {
                        // Note: musn't forget the i!=j test above!
                        matchExists = true;
                    }
                }
            }
            
            if (matchExists) {
                numTrialSuccesses ++;
            }
            
        } //end-for-trials
        
        double prob = (double) numTrialSuccesses / (double) numTrials;
        return prob;
    }
    
}