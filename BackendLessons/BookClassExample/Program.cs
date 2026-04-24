using System;

// Run using command on terminal 'dotnet run'
public class Program
{
	static void Main()
	{
		Book harryPotter = new Book("Harry Potter and the Philosopger's stone", 1);
		// Checking isAvailable is true at first
		harryPotter.ShowDetails();
		// Change it
		harryPotter.Checkout();
		// Checking is now false
        harryPotter.ShowDetails();
	}
}
