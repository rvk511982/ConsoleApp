// See https://aka.ms/new-console-template for more information
using ConsolePractice;
using ConsolePractice.GeneralQuery;
using ConsolePractice.Indexers;
using ConsolePractice.Polymorphism;
using ConsolePractice.SpecialDataTypes;

// Console.WriteLine("Hello, World! Welcome to Console App in Visula Studio Code");
// Logic question - Given an array of ints, write a C# method to total all the values that are even numbers.
var evenNumberSum = Logical.TotalAllEvenNumbers([1, 2, 3, 4, 5, 6, 7]);
Console.WriteLine("Sum of All Even Numbers ==>> " + evenNumberSum);
var oddNumberSum = Logical.TotalAllOddNumbers([1, 2, 3, 4, 5, 6, 7]);
Console.WriteLine("Sum of All Odd Numbers ==>> " + oddNumberSum);

// Anagram without Using Built-in Reverse Function
var createAnagram = Logical.CreateAnagram("kanak");
Console.WriteLine("Anagram without Using Built-in Reverse Function ==>> " + createAnagram);

// Multiply two numbers without using *
var multiply = Logical.MultiplyWithoutStar(7, 8);
Console.WriteLine("Multiply two numbers without using * ==>> " + multiply);

// finds and returns the first k non-repeating characters from a string
var nonRepeat = Logical.GetFirstKNonRepeatedChars("Hello world!", 3);
Console.WriteLine("finds and returns the first k non-repeating characters from a string ==>> " + nonRepeat);

// Find distinct numbers in LINQ
var lstInput = new List<int>() { 1, 2, 3, 4, 5, 2, 3, 4, 4, 4, 5, 5, 5, 5, 5, 8, 9 };
LinqQueries.DistinctNumberFromList(lstInput);


// Filtering - Even numbers from given input
LinqQueries.FindOddOrEven(lstInput, true);

// Filtering - Odd Number from given input
LinqQueries.FindOddOrEven(lstInput, false);

// First, FirstOrDefault, Single and SingleOrDefault
LinqQueries.FirstSingleDefault("ramvinaykumar");

// Second highest salary
LinqQueries.SecondHighestSalary();

// Generic questions
var areEqual = GenericQueries<int>.AreEqual(4, 0);
Console.WriteLine("Input are equal  : >>> " + areEqual);

// AbstractClass abstractClass = new ConcreteClass();
// 	abstractClass.ConcreteMethod();

// var primeData = Logical.ReturnPrimeNumbers(100);
// Console.WriteLine("Prime Number are :>>> " + primeData);

var reverseString = Logical.ReverseString("Vinay"); // yaniv
Console.WriteLine("Reversed string is :>>> " + reverseString);

// var reverseStringLINQ = Logical.ReverseStringLinq("Vinay"); // yaniv
// Console.WriteLine("LINQ Reversed string is :>>> " + reverseStringLINQ);

// var reverseStringLOOP = Logical.ReverseStringLoop("Vinay"); // yaniv
// Console.WriteLine("LOOP Reversed string is :>>> " + reverseStringLOOP);

var reverseTheNumber = Logical.ReverseNumber(123); // 654321
Console.WriteLine("Reversed Number is :>>> " + reverseTheNumber);

// Example array
int[] numbers = { 3, 5, 7, 2, 8, -1, 4, 10, 12 };

// Call the method to find the largest number
int largestNumber = Logical.FindLargestNumber(numbers);

// Print the largest number
Console.WriteLine("The largest number in the array is: " + largestNumber);

GeneralQueries.ExchangeInteger();

Console.WriteLine(GeneralQueries.SwapNeighbourChar("TAPAN"));


GeneralQueries.FibonacciSeries(10);

var factorial = GeneralQueries.FactorialOfNumber(5);
Console.WriteLine("Factorial Of 5 Is " + factorial.ToString());

var text = "like for example $  you don't have $  network $  access $ dfas $ dfgdfg";
GeneralQueries.PreserveFirstAndRemoveAll(text);

string input = "Ball";
string result = GeneralQueries.ReverseWithoutChangingVowels(input);
Console.WriteLine(result); // Output: lalb

// Special Data Types:
SpecialDataTypes.NullableExample();
SpecialDataTypes.AnonymousExample();
SpecialDataTypes.DynamicExample();
SpecialDataTypes.TupleExample();
SpecialDataTypes.SpanMemoryTExample();
SpecialDataTypes.RecordsExample();

// C# Indexer 
Indexer emp = new Indexer(101, "Pranaya", "SSE", 10000, "Mumbai", "IT", "Male");
//Access the Employee Object using Indexer i.e. using Integer Index Position
Console.WriteLine("EID = " + emp[0]);
Console.WriteLine("Name = " + emp[1]);
Console.WriteLine("Job = " + emp[2]);
Console.WriteLine("Salary = " + emp[3]);
Console.WriteLine("Location = " + emp[4]);
Console.WriteLine("Department = " + emp[5]);
Console.WriteLine("Gender = " + emp[6]);
//Set the Employee Object using Indexer i.e. using Integer Index Position
emp[1] = "Kumar";
emp[3] = 65000;
emp[5] = "BBSR";
Console.WriteLine("========After Modification========");
//Access the Employee Object using Indexer i.e. using Integer Index Position
Console.WriteLine("EID = " + emp[0]);
Console.WriteLine("Name = " + emp[1]);
Console.WriteLine("Job = " + emp[2]);
Console.WriteLine("Salary = " + emp[3]);
Console.WriteLine("Location = " + emp[4]);
Console.WriteLine("Department = " + emp[5]);
Console.WriteLine("Gender = " + emp[6]);


// Polymorphism
Animal myDog = new Dog();
Animal myCat = new Cat();

// Call the overridden methods
myDog.MakeSound(); // Output: The dog says: bark
myCat.MakeSound(); // Output: The cat says: meow


Animal animal = new Animal();
animal.MakeSound();
Dog dog = new Dog();
Cat cat = new Cat();

dog.MakeSound();
cat.MakeSound();

Console.ReadLine();