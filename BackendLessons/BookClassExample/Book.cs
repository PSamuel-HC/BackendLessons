/* "Other objects shouldn't be able to inherit nothing from this class"
 So that's why is sealed*/
sealed class Book
{
    private int _id; // sensible information
    public string Title { get; set; }
    public bool IsAvailable { get; private set; } = true; // sensible information, should always start as true. Can be read outside, but only modified inside the class.

    public Book (string title, int id)
    {
        _id = id;
        Title = title;
    }

    public void Checkout()
    {
        IsAvailable = false;
    }

    public void ShowDetails()
    {
        Console.WriteLine(
            $"Book: {Title},\n" +
            $"Availability: {IsAvailable}"
            );
    }

}