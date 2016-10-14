/*Rohan Gupta, Post AP CS, Justin Morgan, Project #6: Anagram
-----------------------------------------------------------------
Anagrams.java - USes recursive backtracking in order to find anagrams (words or phrases made by rearranging the letters of another word or phrase) of a given word or phrase
Uses a dictionary to find all anagram phrases that match a given word or phrase

*/

import java.util.*;

public class Anagrams {
   private Set<String> dictionary;
   
   // precondition: [dictionary != null] throws new IllegalArgumentException, otherwise
   // postcondition: constructs an Anagrams object 
   public Anagrams(Set<String> dictionary) {
      if (dictionary == null) {
         throw new IllegalArgumentException("dictionary: " + dictionary);
      } else {
         this.dictionary = new TreeSet<String>(dictionary);
      }
   }
   
   // precondition: [phrase != null] throws new IllegalArgumentException, otherwise
   // postcondition: returns a Set of Strings containing the words able to be formed
   //       from the given phrase 
   public Set<String> getWords(String phrase) {
      if (phrase == null) {
         throw new IllegalArgumentException("phrase: " + phrase); 
      } else {
         LetterInventory letters = new LetterInventory(phrase);
         Set<String> choices = new TreeSet<String>();
         for (String word: dictionary) {
            if (letters.contains(word)) {
               choices.add(word);
            }
         }
         return choices;
      }
   }
   
   // precondition: [phrase != null] throws new IllegalArgumentException, otherwise
   // postcondition: prints all possible anagrams of the given phrase
   //       max words is equal to the total words in the set of words to possible words
   public void print(String phrase) {
      if (phrase == null) {
         throw new IllegalArgumentException("phrase :" + phrase);
      } else {
         print(new LetterInventory(phrase), getWords(phrase), new Stack<String>(), getWords(phrase).size());
      }
   }

   // precondition: [phrase != null] throws new IllegalArgumentException, otherwise
   //       [max >= 0] throws new IllegalArgumentException, otherwise
   // postcondition: prints all of the possile anagrams of the given phrase while 
   //       while only including max total words
   public void print(String phrase, int max) {
      if (phrase == null) {
         throw new IllegalArgumentException("phrase: " + phrase);
      } else if (max < 0) { 
         throw new IllegalArgumentException("max: " + max);
      } else {
         if (max == 0) { /* total max is equal to the maximum total words to choose from  */
            max = getWords(phrase).size();
         }
         print(new LetterInventory(phrase), getWords(phrase), new Stack<String>(), max); 
      }
   }  
   
   // postcondition: creates and prints anagrams of up to max words
   //       chooses words from passed in choices
   //       uses a LetterInventory to track the letters able to be used in
   //       constructing the anagrams
   //       anagrams are stored in the passed in chosen Stack
   private void print(LetterInventory letters, Set<String> choices, Stack<String> chosen, int max) {
      if (letters.isEmpty()) {
         System.out.println(chosen);
      }
      else if (chosen.size() < max){
         for (String choice : choices) {
            if (letters.contains(choice)) {
               LetterInventory left = new LetterInventory(letters);
               left.subtract(choice);
               
               chosen.push(choice);
               print(left, choices, chosen, max);
               chosen.pop();
            }
         }
      }
   }
}