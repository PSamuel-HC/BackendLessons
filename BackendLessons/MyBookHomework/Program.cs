using MyBookHomework.Models;

try
{
    Console.WriteLine("My Book:");

    Book myBook = new Book(1, "Juan & Juanita");
    myBook.ShowDetails();

    myBook.Checkout();

    //Verifying changes
    Console.WriteLine("My Book after checkout: ");
    myBook.ShowDetails();

    //Verifying validation:
    Console.WriteLine("Validation: ");
    myBook.Checkout();
}

catch (InvalidOperationException ex)
{

    Console.WriteLine(ex.Message);
}
