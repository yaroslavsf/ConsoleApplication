# Console Apllication

## Justification
- To scale the app with new menu options: <br>
> Add your new option in Menu enum <br>
<img src="./Imgs/menu.png" alt="alt text" width="200"/> <br>
> Create your enum with operations <br>
<img src="./Imgs/operation.png" alt="alt text" width="200"/>

- Input of numbers <br>
Operations with numbers are assumed to be with integers only.
- Task 1 <br>
![alt text](./Imgs/task1.jpg)
The main functionallity is based on collections and operations upon them.
So method "Addieren" in first option of menu could have 2 meanings:
<br>a) 5 + 1 = 6 ❌
<br>b) calculate sum (<u>add</u> all numbers) ✅ <br>
I don't see the sense of implementing 1 operation from calculator in application that works with collections

- Task 2 <br>	
Current arhitecture allows to debug by tracing operations list `_interactionHandler`
![alt text](./Imgs/debug.png)


## My working notes
App has 3 user intractions: 				

1. Input <br>		

	- Menu option <br>		

	- Value (number/string/number of stars)	

2. Result output (list + additional info about modification)
*sometimes additional info can be called in different place from list	

3. Formatting output (ask for input, cleaning)


## Author
Yaroslav Zhyvotovskyi