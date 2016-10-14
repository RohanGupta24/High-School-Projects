/*Rohan Gupta Post AP Computer Science 17 March 2015
GrammarSolver.java
------------------------------------------------------
*/

import java.util.*;
public class GrammarSolver {
 
    private Map<String, List<String>> ruleMap;
    private Random rand;
    
    //A constructor that initializes a new grammar solver. The constuctor breaks apart each BNF grammar rule and stores them into a Map called ruleMap
    //Precondition: The parameter List<String> rules should not be null or empty. If it is null, then the method throws an IllegalArgumentException. If the grammar contains more than one line for the same non-terminal, then the method also throws an IllegalArgumentException.
    //Postcondition: The method does not return anything, but rather stores each grammar rule into ruleMap.
    public GrammarSolver(List<String> rules) {
        if (rules == null || rules.isEmpty())
            new IllegalArgumentException();
 
 
        ruleMap = new TreeMap<String, List<String>>();
        rand = new Random();
 
        for (String rule : rules) {
            String[] tokens = rule.split("::=");
 
            String nonTerminal = tokens[0];
 
            String[] terminalRules = tokens[1].split("\\|");
 
            List<String> terminalList = new ArrayList<String>();
 
            for (String terminal : terminalRules) {
                String newListItem = terminal;
                newListItem = newListItem.trim();
                terminalList.add(newListItem);
                terminalList.removeAll(Arrays.asList("", null));
            }
            this.ruleMap.put(nonTerminal, terminalList);
        }
 
        String temp = " ";
        for (String current : ruleMap.keySet()) {
            if (current == temp) {
                new IllegalArgumentException();
            }
            temp = current;
        }
    }
 
    //A method that returns true if the given symbol (the parameter) is a non-terminal in the grammar and false otherwise.
    //Precondition: The paramter, String symbol, should not be null or have a length of zero. If so, the method will throw IllegalArgumentException.
    //Postcondition: The method returns true or false (a boolean).
    public boolean contains(String symbol) {
        if (symbol == null || symbol.length() == 0)
            new IllegalArgumentException();
        return ruleMap.containsKey(symbol);
    }
    //A method that returns all non-terminal symbols of the grammar as a sorted set of strings.
    //Precondition: None. No parameter needed.
    //Postcondition: The method returns a Set<String> that is the keySet of the ruleMap.
    public Set<String> getSymbols() {
        return ruleMap.keySet();
    }
    
    //A method that uses the grammar to generate a random occurence of the given symbol (parameter) and that returns as a String. If the string passed is not a non-terminal in the grammar, assume that it is a terminal symbol and simply return it.
    //Precondition: If the parameter, symbol, is null or has a length of zero, then the method will throw an IllegalArgumentException. As a result, symbol should not have a length of zero or be null.
    //Postcondition: The method returns a string of a random occurence.
    public String generate(String symbol) {
        if (symbol.length() == 0 || symbol == null)
            new IllegalArgumentException();
        if (!ruleMap.containsKey(symbol))
            return symbol;
 
        List<String> terminals = ruleMap.get(symbol);
 
        String definiteTerminals = "";
        String chosenTerminal = terminals.get(Math.abs(rand.nextInt(terminals.size())));

        String[] terminalTokens = chosenTerminal.split(" ");
        if (terminalTokens.length > 1) {
            for (String current : terminalTokens) {
                if (ruleMap.containsKey(current)) {
                    definiteTerminals += generate(current);
                } else {
                    definiteTerminals += current;
                }
            }
        } else if (ruleMap.containsKey(chosenTerminal)){
            definiteTerminals += generate(chosenTerminal);
        } else {
            definiteTerminals += chosenTerminal + " ";
        }
 
        return definiteTerminals;
    }
}
