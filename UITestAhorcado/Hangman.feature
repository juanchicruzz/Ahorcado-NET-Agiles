Feature: Hangman
	juego del ahorcado


Scenario: loses the game
	Given the the player1 is JUAN and the player2 is FRANCO
	And the word2guess is ahorcado
	When the player guessed 7 letters wrong
	Then the player loses the game


Scenario: wins the game
	Given the the player1 is JUAN and the player2 is FRANCO
	And the word2guess is ahorcado
	When the player guesses all letters 
	Then the player wins the game

Scenario: restart the game
	Given the the player1 is JUAN and the player2 is FRANCO
	And the word2guess is ahorcado
	When the player enters 3 random letters
	And the player restarts the game
	Then the game is restarted


Scenario: guesses complete word
	Given the the player1 is JUAN and the player2 is FRANCO
	And the word2guess is <word>
	When the player guesses the complete word <word>
	Then the player wins the game
	Examples:
| word | 
| ahorcado     | 
| capricho     |
| ramificacion | 