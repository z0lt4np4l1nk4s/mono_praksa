/*

The multiplication task
660 * 0.08875

*/

function multiply(a, b, numberOfDigits = 0)
{
    //return +(Math.round(a*b + 'e+' + numberOfDigits) + 'e-' + numberOfDigits);
    let res = a * b;
    for(let i = 16; i >= numberOfDigits; i--)
    {
        res = +res.toFixed(i);
    }
    return res;
}



/*

Write a function isPalindrome(str) that takes a string as an argument and returns true if the string is a palindrome and false otherwise. 
A palindrome is a word, phrase, number, or other sequences of characters that reads the same forward and backward, ignoring spaces, punctuation, and capitalization.

*/
function isPalindrome(str)
{
    let inputString = str.toLowerCase().split('').filter((s) => s >= 'a' && s <= 'z' || s >= '0' && s <= '9');
    let l = 0, r = inputString.length - 1;
    while(l <= r)
    {
        if(inputString[l] != inputString[r]) return false;
        l++;
        r--;
    }
    return true;
}



/*

Write a function removeDuplicates(arr) that takes an array of primitive types and returns a new array with all duplicate entries removed.

*/

function removeDuplicates(arr)
{
    return [... new Set(arr)];
}



/*

Write a program that prints the numbers from 1 to 100. But for multiples of three print “Fizz” instead of the number and for the multiples of five print “Buzz”. 
For numbers which are multiples of both three and five print “FizzBuzz”.

*/

function fizzBuzz()
{
    for(let i = 1; i <= 100; i++)
    {
        if(i % 3 === 0 && i % 5 === 0) console.log('FizzBuzz');
        else if (i % 3 === 0) console.log('Fizz');
        else if (i % 5 === 0) console.log('Buzz');
        else console.log(i);
    }
}



/*

Write a function fibonacci(n) that returns the nth number in the Fibonacci sequence. 
The Fibonacci sequence is a series of numbers where a number is found by adding up the two numbers before it. 
Starting with 0 and 1, the sequence goes 0, 1, 1, 2, 3, 5, 8, 13, 21, and so forth.

*/

fibArr = new Array(100, 0);

function fibonacci(n)
{
    if(n === 0) return 0;
    if(n === 1) return 1;
    if(fibArr[n]) return fibArr[n];
    return fibArr[n] = fibonacci(n - 1) + fibonacci(n-2);
}