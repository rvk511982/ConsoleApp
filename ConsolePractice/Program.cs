// See https://aka.ms/new-console-template for more information
using ConsolePractice;
using ConsolePractice.Codility;
using ConsolePractice.GeneralQuery;
using ConsolePractice.Indexers;
using ConsolePractice.InventoryManagementSystem;
using ConsolePractice.Polymorphism;
using ConsolePractice.SagaPattern.MessageBus;
using ConsolePractice.SagaPattern.Orchestrator;
using ConsolePractice.SagaPattern.Services;
using ConsolePractice.SpecialDataTypes;
using ConsolePractice.Test;
using static System.Runtime.InteropServices.JavaScript.JSType;
using InventoryService = ConsolePractice.SagaPattern.Services.InventoryService;

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

// factorial using recursion in C#:
Console.Write("Enter a number: ");
int number = int.Parse(Console.ReadLine());
long resultFact = Logical.Factorial(number);
Console.WriteLine($"Factorial of {number} is {resultFact}");

// Generate Pan Card
for (int i = 0; i < 5; i++)
{
    Logical.GeneratePANCard();
    Logical.GenerateUniquePANCard();
}

// positive negative
Logical.PositiveNegativeValue();

// Word Count and occurance of word
Logical.GetOccuranceOfWordsFromSentence("This is a test string. This is a test string. This is a test string.");

//Console.WriteLine("Positive negative output == >>" + posiResult);

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

// Department and Salary
AltemetricTest.GetDepartWiseSpentMoney();
AltemetricTest.GetDepartWiseSpentMoney_LINQ();

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


// Test query


var outputOfString = MyTest.KthLargestNumber();
Console.WriteLine("========KthLargestNumber========");
Console.WriteLine("The Output is ==>>" + outputOfString);

// Extracts the maximum numeric value from an alphanumeric string
Console.WriteLine("========Strat of Extracts the maximum numeric value from an alphanumeric string========");
//string alphanumericInput = "100klh564abc365bg";
string[] alphanumericInput = { "100klh564abc365bg", "1080klbvxh5684annbc3685bg", "12300klh54364abc334465bg", "1034320klhasdf5retrt64abc36rtwr5bg", "103430klh56534534abc3652345dfgfd5bg3454534hdffg7567758u76" };
foreach (var item in alphanumericInput)
{
    Console.WriteLine("========ExtractMaxNumericValue using Regex========");
    int maxValue = MyTest.ExtractMaxNumericValue(item);
    Console.WriteLine($"The maximum numeric value is: {maxValue}");

    Console.WriteLine("========ExtractMaxNumericValue using LINQ========");
    int maxValue_LINQ = MyTest.ExtractMaxNumericValue_LINQ(item);
    Console.WriteLine($"The maximum numeric value is using LINQ : {maxValue_LINQ}");

    Console.WriteLine("========ExtractMaxNumericValue using Span========");
    int maxValue_Span = MyTest.ExtractMaxNumericValue_Span(item);
    Console.WriteLine($"The maximum numeric value  is using SPAN : {maxValue_Span}");

    Console.WriteLine("========ExtractMaxNumericValue using Char========");
    int maxValue_Char = MyTest.ExtractMaxNumericValue_Char(item);
    Console.WriteLine($"The maximum numeric value is using char: {maxValue_Char}");
}
Console.WriteLine("========End of Extracts the maximum numeric value from an alphanumeric string========");

// Sorts a given string in descending lexicographical order
Console.WriteLine("========Sorts a given string in descending lexicographical order========");
string[] lexicographical = { "geeks", "cheers" };
foreach (var item in lexicographical)
{
    MyTest.SortStringInDescendingOrder(item);
    MyTest.SortStringInDescendingOrder_ArraySort(item);
    MyTest.SortStringInDescendingOrder_BubbleSort(item);
    MyTest.SortStringInDescendingOrder_ListSort(item);
    MyTest.SortStringInDescendingOrder_Span(item);
}
Console.WriteLine("========Sorts a given string in descending lexicographical order========");

// Lexicographical order
Console.WriteLine("========Lexicographical order========");
MyTest.LexicoGraphicalOrder();
Console.WriteLine("========Lexicographical order========");

// smallest positive integer
Console.WriteLine("========smallest positive integer========");
MyTest.SmallestPositiveInteger();
Console.WriteLine("========smallest positive integer========");

// minimum number of distinct letters of a string S, that can be constructed from P and Q
Console.WriteLine("========minimum number of distinct letters of a string S, that can be constructed from P and Q========");

Dictionary<string, string> minimumLetters = new Dictionary<string, string>();
minimumLetters.Add("abc", "bcd");
minimumLetters.Add("axxz", "yzwy");
minimumLetters.Add("bacad", "abada");
minimumLetters.Add("amz", "amz");
minimumLetters.Add("abcdef", "bcdefa");
foreach (var item in minimumLetters)
{
    MyTest.MinimumNumberOfDistinctLetters(item.Key, item.Value);
}
Console.WriteLine("========minimum number of distinct letters of a string S, that can be constructed from P and Q========");

// Inventory Management System
InventoryManagement inventory = new InventoryManagement();
//inventory.ShowInventory();

// 03-Feb-2025
//var operations = new[] { "WRITE Hello", "WRITE World", "UNDO" };
var operations = new[] { "WRITE Hello", "WRITE World", "UNDO", "WRITE Micro1", "WRITE Tiger", "UNDO" };
var documentVersioning = new DocumentVersioning();
documentVersioning.ProcessOperations(operations);

// Max Income Calculator
Console.WriteLine("Start of Max Income Calculator...");
//MaxIncomeCalculator.IncomeCalculator(new int[] { 4, 1, 2, 3 });
//MaxIncomeCalculator.IncomeCalculator(new int[] { 1, 2, 3, 3, 2, 1, 5 });
//MaxIncomeCalculator.IncomeCalculator(new int[] { 1000000000, 1, 2, 2, 1000000000, 1, 1000000000 });

MaxIncomeCalculator.MaxProfit(new int[] { 4, 1, 2, 3 });
MaxIncomeCalculator.MaxProfit(new int[] { 1, 2, 3, 3, 2, 1, 5 });
MaxIncomeCalculator.MaxProfit(new int[] { 1000000000, 1, 2, 2, 1000000000, 1, 1000000000 });

Console.WriteLine("End of Max Income Calculator...");

// Saga Pattern Sample
var messageBus = new InMemoryMessageBus();
var sagaOrchestrator = new OrderSagaOrchestrator(messageBus);
var orderService = new OrderService(sagaOrchestrator);
var paymentService = new PaymentService(messageBus);
var inventoryService = new InventoryService(messageBus);

// Subscribe services to message bus
messageBus.OnOrderCreated += paymentService.ProcessPayment;
messageBus.OnPaymentProcessed += sagaOrchestrator.HandlePaymentProcessedAsync;
messageBus.OnPaymentProcessed += inventoryService.UpdateInventory;
messageBus.OnInventoryUpdated += sagaOrchestrator.HandleInventoryUpdatedAsync;

// Start Saga
await orderService.CreateOrder(Guid.NewGuid(), 100.00m);







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