# Description
Create a basic calculator program. It should work like this:

1. Ask the user for a math operation and store it in a `char` variable called `opr`. 
2. Ask the user for the first number, store it in a `float` variable called `first`.
3. Ask the user for the second number, store it in a `float` variable called `second`.
4. Apply the operator on the two numbers and display the result.

The entered operation will be of type `string` and the user will enter one of the four options: `+`, `-`, `/`, `*`.

You don't need to deal with cases where the user enters an invalid operation or an invalid number.

The result output must be in the following format otherwise the test cases might fail:
```
Console.WriteLine($"The result of '{first} {opr} {second}' is: {result}");
```
Here `first`, `second` and `result` are float values.

### Hints
> **Hint 1:** Use conditional if-else statements or the switch statement to check which operation the user has entered, and apply the operation on the two numbers based on that.
